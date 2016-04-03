using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem
{
    class Party
    {
        private int partySize;
        private String name;
        private String specialReq;
        private int pagerNum;
        private int tableNum;
        private DateTime arrivalTime;
        private DateTime seatedTime;
        private DateTime reservationTime;
        private DateTime leaveTime;

        public Party(int partySize, String name, String specialReq, int pagerNum)
        {
            this.name = name;
            this.partySize = partySize;
            this.specialReq = specialReq;
            this.pagerNum = pagerNum;
        }

        public Party(int partySize, String name, String specialReq, int pagerNum, DateTime reservationTime)
        {
            this.name = name;
            this.partySize = partySize;
            this.specialReq = specialReq;
            this.pagerNum = pagerNum;
            this.reservationTime = reservationTime;
        }

        public int getPartySize()
        {
            return partySize;
        }

        public String getName()
        {
            return name;
        }

        public String getSpecialReq()
        {
            return specialReq;
        }

        public int getPhoneNum()
        {
            return pagerNum;
        }

        public void setPhoneNum(int phoneNum)
        {
            this.pagerNum = phoneNum;
        }

        public void arrive()
        {
            arrivalTime = DateTime.Now;
        }

        public void seat(int num)
        {
            seatedTime = DateTime.Now;
            tableNum = num;
        }

        public void leave()
        {
            leaveTime = DateTime.Now;
        }

        public DateTime getResTime()
        {
            return reservationTime;
        }

        public string managementOutput()
        {
            string temp = "";
            temp += (arrivalTime.ToString("ddd", CultureInfo.CreateSpecificCulture("en-US")).ToUpper());
            temp += ",";
            temp += arrivalTime.ToString("MM", CultureInfo.CreateSpecificCulture("en-US")) + arrivalTime.ToString("mm", CultureInfo.CreateSpecificCulture("en-US"));
            temp += ",";
            temp += seatedTime.ToString("MM", CultureInfo.CreateSpecificCulture("en-US")) + seatedTime.ToString("mm", CultureInfo.CreateSpecificCulture("en-US"));
            temp += ",";
            temp += leaveTime.ToString("MM", CultureInfo.CreateSpecificCulture("en-US")) + leaveTime.ToString("mm", CultureInfo.CreateSpecificCulture("en-US"));
            temp += ",";
            temp += tableNum;

            return temp;
        }

    }

    class ReservationSystem
    {
        private Table[] tableList;
        private LinkedList<Party> reservationsPresent;
        private LinkedList<Party> walkIns;
        private ArrayList reservations;
        private ArrayList pastReservations;

        public ReservationSystem(int num)
        {
            reservationsPresent = new LinkedList<Party>();
            walkIns = new LinkedList<Party>();
            reservations = new ArrayList();
            pastReservations = new ArrayList();
            tableList = new Table[num];
            for(int i = 0; i < num; i++)
            {
                tableList[i] = new Table(i);
            }
        }

        public void addReservation(int partySize, String name, String specialReq, int phoneNum, int month, int day, int hour, int minute)
        {
            DateTime reservationTime = new DateTime(DateTime.Now.Year, month, day, hour, minute, 0);
            reservations.Add(new Party(partySize, name, specialReq, phoneNum, reservationTime));
        }

        public void checkIn(String name)
        {
            Party partyToCheck = null;

            foreach (Party res in reservations)
            {
                if (res.getName().Equals(name))
                {
                    partyToCheck = res;
                    break;
                }
            }

            if (partyToCheck != null)
            {
                if (Int32.Parse(partyToCheck.getResTime().Subtract(DateTime.Now).ToString().Substring(3, 2)) <= 15)
                {
                    reservationsPresent.AddLast(partyToCheck);
                    reservations.Remove(partyToCheck);
                }
                else Console.WriteLine("Party {0} cannot be checked in; more than 15 minutes out.", name);
            }
            else
            {
                Console.WriteLine("Could not find party under name {0}.", name);
            }

        }

        public void addWalkIn(int partySize, String name, String specialReq, int phoneNum)
        {
            walkIns.AddLast(new Party(partySize, name, specialReq, phoneNum));
        }

        public Party getNextParty()
        {
            if (reservationsPresent.Count() > 0)
            {
                Party temp = reservationsPresent.First();
                reservationsPresent.RemoveFirst();
                return temp;
            }
            else if (walkIns.Count() > 0)
            {
                Party temp = walkIns.First();
                walkIns.RemoveFirst();
                return temp;
            }
            return null;
        }

        public void seatNextParty(int tableNum)
        {
            if(tableList[tableNum].getAbleToBeSeated())
            {
                Party temp = getNextParty();
                tableList[tableNum].seat(temp);
            }
        }

      

        public void ToManagement()
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\ReceptionFiles\ReceptionManagement.txt"))
            {
                foreach (Party party in pastReservations)
                {
                    file.WriteLine(party.managementOutput());
                }
            }
        }


    }

    class Table
    {
        private bool inUse;
        private int peopleSeated;
        private bool ableToBeSeated;
        private Party partySeated;
        private int tableNum;
        static public int SIZE_OF_TABLE = 4;

        public Table(int num)
        {
            this.tableNum = num;
            inUse = false;
            ableToBeSeated = true;
            partySeated = null;
        }

        public void seat(Party p)
        {
            if (ableToBeSeated)
            {
                this.partySeated = p;
                p.seat(this.tableNum);
                inUse = true;
                ableToBeSeated = false;
            }
        }

        public Party leave()
        {
            Party temp = partySeated;
            partySeated = null;
            inUse = false;
            return temp;
        }

        public void clean()
        {
            if(!inUse) ableToBeSeated = true;
        }

        public bool getAbleToBeSeated()
        {
            return ableToBeSeated;
        }


    }
}
