using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem
{
    class unitTest
    {
        public static void Main()
        {
            Waitlist ws = new Waitlist(16);
            ws.addWalkIn("3", "Oney", "food", "5");
            ws.addWalkIn("2", "Somebody", "more food", "6");
            ws.seatNextParty(5);
            ws.seatNextParty(9);
            ws.resetTable(5);
            ws.resetTable(9);
            ws.ToManagement();
        }

    }

    class Waitlist
    {
        private Table[] tableList;
        private LinkedList<Party> walkIns;
        private ArrayList takeOut;
        private ArrayList reservations;
        private ArrayList pastParties;
        private LinkedList<int> tablesSeated;

        /**
         *  Ctor for the waitlist
         *  
         *  Input: Amount of tables in the restaraunt
         **/
        public Waitlist(int num)
        {
            walkIns = new LinkedList<Party>();
            takeOut = new ArrayList();
            reservations = new ArrayList();
            pastParties = new ArrayList();
            tablesSeated = new LinkedList<int>();
            tableList = new Table[num];
            for (int i = 0; i < num; i++)
            {
                tableList[i] = new Table(i);
            }

            if (!Directory.Exists(@"C:\ReceptionFiles")) //Create the directory if it is not there
            {
                Directory.CreateDirectory(@"C:\ReceptionFiles");
            }
        }


        /**
         * Constructor for adding a reservation
         **/
        public void addReservation(string partySize, string name, string specialReq, string phoneNum, int hour, int minute)
        {
            DateTime reservationTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0);
            reservations.Add(new Party(partySize, name, specialReq, phoneNum, reservationTime));
        }


        /**
         *  Constructor for adding in a takeout order
         **/
        public void addTakeOut(string name, string phoneNum)
        {
            takeOut.Add(new Party(name, phoneNum));
        }


        /**
         *  Checks in the given party based on name
         *
         *  Only allows parties that are within one hour to be checked in
         **/
        public void checkIn(string name)
        {
            Party partyToCheck = null;

            foreach (Party res in reservations) //finds the party
            {
                if (res.getName().Equals(name))
                {
                    partyToCheck = res;
                    break;
                }
            }

            if (partyToCheck != null)
            {
                if ((partyToCheck.getResTime() - DateTime.Now).TotalHours <= 0) //within 1 hour before res time
                {
                    walkIns.AddFirst(partyToCheck);
                    reservations.Remove(partyToCheck);
                }
            }
            else
            {
                Console.WriteLine("Could not find party under name {0}.", name); //could not find reservation
            }

        }


        /**
         * Removes a party from the takeout list based on the name inputted
         **/
        public void removeTakeOut(string name)
        {
            foreach (Party p in takeOut)
            {
                if (p.getName().Equals(name))
                {
                    takeOut.Remove(p);
                }
            }
        }


        /**
         *  Constructor for adding a walk-in party
         **/
        public void addWalkIn(string partySize, string name, string specialReq, string pagerNum)
        {
            walkIns.AddLast(new Party(partySize, name, specialReq, pagerNum));
        }


        /**
         *  Returns the enxt party to be seated
         **/
        public Party getNextParty()
        {
            if (walkIns.Count() > 0)
            {
                Party temp = walkIns.First();
                walkIns.RemoveFirst();
                return temp;
            }
            return null;
        }


        /**
         *  Seats the next party at the indicated table
         **/
        public void seatNextParty(int tableNum)
        {
            if (!tableList[tableNum].getInUse()) //checks to make sure not already being used
            {
                Party temp = getNextParty();
                tableList[tableNum].seat(temp);
                tablesSeated.AddLast(tableNum);
            }
        }


        /**
         *  Resets the table value and adds party to the list to be output to management
         **/
        public void resetTable(int tableNum)
        {
            if (tableList[tableNum].getInUse()) //checks to make sure table is in use
            {
                Party temp = tableList[tableNum].leave();
                pastParties.Add(temp);
                tablesSeated.Remove(tableNum);
            }
        }


        /**
         *  Gives the estimated waiting time for a party
         **/
        public string getWaitTime()
        {
            foreach (Table t in tableList) //finds an empty table 
            {
                if (!t.getInUse())
                {
                    return "None";
                }
            }

            //no empty tables, need to estimate based on first table seated
            int amtWaiting = walkIns.Count();
            int cyles = amtWaiting / 16; //represents amount of cyles of people neding to be seated
            amtWaiting = amtWaiting % 16;

            return (tableList[amtWaiting].getParty().getSeatTime().AddMinutes((cyles + 1) * 45) - DateTime.Now).ToString();
        }


        /**
         *  Creates a file under C:\Reception files to be outputted to Management
         * 
         *  Needs to be put into dropbox
         **/
        public void ToManagement()
        {
            using (StreamWriter file =
            File.AppendText(@"C:\ReceptionFiles\ReceptionManagement.txt"))
            {
                foreach (Party party in pastParties)
                {
                    file.WriteLine(party.managementOutput());
                }
            }
        }

        /*
         * cleanReportFromWaitstaff
         * 
         * Reads through the file from Wait Staff (recWait.txt currently) in order to reset tables
         * reads through each line looking for a number, then resets any table that is deemed clean by Wait Staff
         * 
         * currently does not catch File Does Not Exist errors - can cause crash!!!
         */
        public void cleanReportFromWaitstaff()
        {
            foreach (string line in File.ReadLines(@"C:\ReceptionFiles\recWait.txt"))
            {
                if (line.Contains("0") ||
                   line.Contains("1") ||
                   line.Contains("2") ||
                   line.Contains("3") ||
                   line.Contains("4") ||
                   line.Contains("5") ||
                   line.Contains("6") ||
                   line.Contains("7") ||
                   line.Contains("8") ||
                   line.Contains("9") ||
                   line.Contains("10") ||
                   line.Contains("11") ||
                   line.Contains("12") ||
                   line.Contains("13") ||
                   line.Contains("14") ||
                   line.Contains("15") ||
                   line.Contains("16"))
                {
                    int tableNum = Int32.Parse(line);
                    resetTable(tableNum);
                }
            }
        }

    }

    class Table
    {
        private bool inUse;
        private int peopleSeated;
        private Party partySeated;
        private int tableNum;
        static public int SIZE_OF_TABLE = 4;

        //Constrcutor for the table
        public Table(int num)
        {
            this.tableNum = num;
            inUse = false;
            partySeated = null;
        }

        //Seats a given party to the table
        public void seat(Party p)
        {
            if (!inUse)
            {
                this.partySeated = p;
                p.seat(this.tableNum);
                inUse = true;
            }
        }

        //Resets the table for use, updates party status
        public Party leave()
        {
            Party temp = partySeated;
            temp.leave();
            partySeated = null;
            inUse = false;
            return temp;
        }

        public bool getInUse()
        {
            return inUse;
        }

        /**
         *  Returns the party seated at the table
         **/
        public Party getParty()
        {
            return partySeated;
        }


    }

    class Party
    {
        private string partySize;
        private string name;
        private string specialReq;
        private string pagerNum;
        private string phoneNum;
        private bool isSeated = false;
        public string tableNum;
        public DateTime arrivalTime;
        public DateTime seatedTime;
        private DateTime reservationTime;
        public DateTime leaveTime;

        // Walk-In Constructor
        public Party(string partySize, string name, string specialReq, string pagerNum)
        {
            this.name = name;
            this.partySize = partySize;
            this.specialReq = specialReq;
            this.pagerNum = pagerNum;
            this.arrivalTime = DateTime.Now;
        }

        //Reservation Constructor
        public Party(string partySize, string name, string specialReq, string phoneNum, DateTime reservationTime)
        {
            this.name = name;
            this.partySize = partySize;
            this.specialReq = specialReq;
            this.phoneNum = phoneNum;
            this.reservationTime = reservationTime;
        }

        //Takeout Constructor
        public Party(string name, string phoneNum)
        {
            this.name = name;
            this.phoneNum = phoneNum;
        }

        public string getPartySize()
        {
            return partySize;
        }

        public string getName()
        {
            return name;
        }

        public string getSpecialReq()
        {
            return specialReq;
        }

        public string getPagerNum()
        {
            return pagerNum;
        }

        public string getPhoneNum()
        {
            return phoneNum;
        }

        public bool getIsSeated()
        {
            return isSeated;
        }

        /**
         *  Called when a reservation arrives in restaurant
         *  Input is pager number given to the party
         **/
        public void arrive(string pagerNum)
        {
            arrivalTime = DateTime.Now;
            this.pagerNum = pagerNum;
        }

        public void seat(int num)
        {
            seatedTime = DateTime.Now;
            tableNum = num.ToString();
        }

        public void leave()
        {
            leaveTime = DateTime.Now;
        }

        public DateTime getResTime()
        {
            return reservationTime;
        }

        public DateTime getSeatTime()
        {
            return seatedTime;
        }


        /**
         *  Outputs a string describing the associated times/tableNum with each party
         **/
        public string managementOutput()
        {
            string temp = "";
            temp += (arrivalTime.ToString("ddd", CultureInfo.CreateSpecificCulture("en-US")).ToUpper());
            temp += ",";
            temp += arrivalTime.ToString("HH", CultureInfo.CreateSpecificCulture("en-US")) + arrivalTime.ToString("mm", CultureInfo.CreateSpecificCulture("en-US"));
            temp += ",";
            temp += seatedTime.ToString("HH", CultureInfo.CreateSpecificCulture("en-US")) + seatedTime.ToString("mm", CultureInfo.CreateSpecificCulture("en-US"));
            temp += ",";
            temp += leaveTime.ToString("HH", CultureInfo.CreateSpecificCulture("en-US")) + leaveTime.ToString("mm", CultureInfo.CreateSpecificCulture("en-US"));
            temp += ",";
            temp += tableNum;

            return temp;
        }

    }
}
