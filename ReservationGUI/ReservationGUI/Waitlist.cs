using Dropbox.Api;
using Dropbox.Api.Files;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ReservationGUI
{
    class Waitlist
    {
        private Table[] tableList;
        private LinkedList<Party> walkIns;
        private ArrayList takeOut;
        private ArrayList reservations;
        private ArrayList pastParties;
        private LinkedList<int> tablesSeated;
        private DropboxClient dropbox;

        private Party partyToSend; //hacky fixes to Tasks not wanting params
        private Party partyToLeave;
        private Party prevTakeout;
        private string prevWait;

        //private Thread waitCheck; //runs the task of looking for waitstaff's reports

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

            //DO NOT MODIFY THIS LINE
            dropbox = new DropboxClient("y6msKo4rz3AAAAAAAAAACGNSf5KM4CZh-mw4McAEU-3dStDkeEeTHWvELs2br12K");

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
        public void addTakeOut(string name, string phoneNum, int pickUpHour, int pickUpMin)
        {
            DateTime pickUpTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, pickUpHour, pickUpMin, 0);
            Party temp = new Party(name, phoneNum, pickUpTime);

            takeOut.Add(temp);
            if (takeOut.Count == 1) //initial takeout!
            {
                prevTakeout = temp;

                try
                {
                    var download = Task.Run(downloadWaitStaff);
                    download.Wait();
                }
                catch (AggregateException)
                {
                    //no previous file
                }

                var task = Task.Run(toWaitStaffTogo);
                task.Wait();

            }
            
        }

        /** 
         *  Sends a togo order to Waitstaff
         **/
        public async Task toWaitStaffTogo()
        {
            using (var mem = new MemoryStream(Encoding.UTF8.GetBytes(prevWait + prevTakeout.waitstaffOutputTogo())))
            {
                var updated = await dropbox.Files.UploadAsync(
                    "/CS 341/Waitstaff/recWait.txt",
                    WriteMode.Overwrite.Instance, true, body: mem);
            }
        }

        public ArrayList getReservations()
        {
            return reservations;
        }

        /**
         *  Checks in the given party based on name
         *
         *  Only allows parties that are within one hour to be checked in
         **/
        public void checkIn(string name, int num)
        {
            Party partyToCheck = null;

            foreach (Party res in reservations) //finds the party
            {
                if (res.getName().Equals(name))
                {
                    partyToCheck = res;
                    res.arrive(""+num);
                    break;
                }
            }

            if (partyToCheck != null)
            {
                walkIns.AddFirst(partyToCheck);   //delete for actual use: line used to show how would work
                reservations.Remove(partyToCheck);//delete for actual use: used to show how would work

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

        public Table[] getTables()
        {
            return tableList; 
        }


        /**
         * Removes a party from the takeout list based on the name inputted
         **/
        public void removeTakeOut()
        {
            if(takeOut.Count > 0)
            takeOut.RemoveAt(0);

            if(takeOut.Count > 0)
            {
                prevTakeout = (Party) takeOut[0];

                try
                {
                    var download = Task.Run(downloadWaitStaff);
                    download.Wait();
                }
                catch (AggregateException)
                {
                    //no previous file
                }

                var task = Task.Run(toWaitStaffTogo);
                task.Wait();

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
         *  Returns the next party to be seated
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

        public ArrayList getTakeout()
        {
            return this.takeOut;
        }


        /**
         *  Seats the next party at the indicated table
         **/
        public string seatNextParty(int tableNum)
        {
            string partyName = "";
            if (!tableList[tableNum].getInUse()) //checks to make sure not already being used
            {                
                Party temp = getNextParty();
                partyName = temp.getName();
                tableList[tableNum].seat(temp);
                tablesSeated.AddLast(tableNum);

                partyToSend = temp;
                prevWait = "";

                try
                {
                    var download = Task.Run(downloadWaitStaff);
                    download.Wait();
                }
                catch (AggregateException)
                {
                    //no previous file
                }

                var task = Task.Run(toWaitStaff);
                task.Wait();
                

            }
            return partyName;
        }


        /**
         *  Sends a .txt file to WaitStaff with party info
         **/
        public async Task toWaitStaff()
        {
            using (var mem = new MemoryStream(Encoding.UTF8.GetBytes(prevWait + partyToSend.waitstaffOutput())))
            {
                var updated = await dropbox.Files.UploadAsync(
                    "/CS 341/Waitstaff/recWait.txt",
                    WriteMode.Overwrite.Instance, true, body: mem);
            }
        }

        /**
         *  Downloads the textfile we sent to waitstaff if it exists, causes exception if otherwise
         **/
         public async Task downloadWaitStaff()
        {
            using (var response = await dropbox.Files.DownloadAsync("/CS 341/Waitstaff/recWait.txt"))
            {
               prevWait = await response.GetContentAsStringAsync();
            }
        }


        /**
         *  Resets the table value and adds party to the list to be output to management
         **/
        public void resetTable(int tableNum)
        {
            if (tableList[tableNum].getInUse()) //checks to make sure table is in use
            {
                partyToLeave = tableList[tableNum].leave();
                var task = Task.Run(toManagement);
                task.Wait();
                tablesSeated.Remove(tableNum);
            }
        }


        /**
         *  Gives the estimated waiting time for a party
         **/
        public string getWaitTime(int guestNum)
        {
            foreach (Table t in tableList) //finds an empty table 
            {
                if (!t.getInUse())
                {
                    if (guestNum > 4)
                    {
                        return "5 Minutes";
                    }
                    else
                    {
                        return "None";
                    }
                }
            }

            //no empty tables, need to estimate based on first table seated
            int amtWaiting = walkIns.Count();
            int cyles = amtWaiting / 16; //represents amount of cyles of people neding to be seated
            amtWaiting = amtWaiting % 16;

            return (tableList[amtWaiting].getParty().getSeatTime().AddMinutes((cyles + 1) * 45) - DateTime.Now).ToString();
        }

        public LinkedList<Party> getWalkIns()
        {
            return walkIns;
        }

        /**
         *  Puts management file onto dropbox
         **/
        public async Task toManagement()
        {
            string manString = "Day,Time_In,Time_Seated,Time_Left_Table,Table_Number\r\n";


            var results = await dropbox.Files.SearchAsync("/CS 341/Management", "ReceptionManagement.txt");

            if (results.Matches.Count > 0) //checks to see if we need to append or create
            {
                using (var response = await dropbox.Files.DownloadAsync("/CS 341/Management/ReceptionManagement.txt"))
                {
                    manString = await response.GetContentAsStringAsync();
                }
            }

            //create the file
            manString += partyToLeave.managementOutput() + "\r\n";

            using (var mem = new MemoryStream(Encoding.UTF8.GetBytes(manString)))
            {
                var updated = await dropbox.Files.UploadAsync(
                    "/CS 341/Management/ReceptionManagement.txt",
                    WriteMode.Overwrite.Instance, body: mem);
            }
        }


        /**
         *  Downloads the report from waitstaff, if DNE then throws exception on the task
         **/
        public async Task waitstaffNumCheck()
        {
            using (var response = await dropbox.Files.DownloadAsync("/CS 341/Reception/waitRecNumber.txt"))
            {
                resetTable(Convert.ToInt32(await response.GetContentAsStringAsync()));
            }

            await dropbox.Files.DeleteAsync("/CS 341/Reception/waitRecNumber.txt");
        }

    }
}
