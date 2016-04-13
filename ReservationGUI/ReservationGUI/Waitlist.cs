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

        private Party partyToSend; //hacky fix to Tasks not wanting params
        private Party partyToLeave;

        private Thread waitCheck;

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

            //DO NOT MODIFY THIS LINE
            dropbox = new DropboxClient("y6msKo4rz3AAAAAAAAAACGNSf5KM4CZh-mw4McAEU-3dStDkeEeTHWvELs2br12K");

            waitCheck = new Thread(waitCheckThread);
            waitCheck.Start();
        }


        /**
         * This thread will house the task to check the waitstaff input
         **/
        private void waitCheckThread()
        {
            while (true)
            {
                try
                {
                    var task = Task.Run(waitstaffCheck);
                    task.Wait();
                    task.Dispose();                   
                }
                catch (AggregateException ae)
                {
                    
                    //who cares, try again 
                }
                Thread.Sleep(20000); //sleep for 20 seconds
            }

        }


        /**
         * As a result of creating an infinithread, this method MUST be called when the user wants to terminate the program
         **/
        public void killThread()
        {
            waitCheck.Abort();
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
            takeOut.Add(new Party(name, phoneNum, pickUpTime));
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

                partyToSend = temp;
                var task = Task.Run(toWaitStaff);
                task.Wait();

            }
        }


        /**
         *  Sends a .txt file to WaitStaff with party info
         **/
        public async Task toWaitStaff()
        {
            using (var mem = new MemoryStream(Encoding.UTF8.GetBytes(partyToSend.waitstaffOutput())))
            {
                var updated = await dropbox.Files.UploadAsync(
                    "/CS 341/Waitstaff/recWait.txt",
                    WriteMode.Overwrite.Instance, true, body: mem);
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
            string manString = "Day,Time_In,Time_Seated,Time_Left_Table,Table_Number\n";


            var results = await dropbox.Files.SearchAsync("/CS 341/Management", "ReceptionManagement.txt");

            Console.WriteLine(results.Matches.Count);

            if (results.Matches.Count > 0) //checks to see if we need to append or create
            {
                using (var response = await dropbox.Files.DownloadAsync("/CS 341/Management/ReceptionManagement.txt"))
                {
                    manString = await response.GetContentAsStringAsync();
                }

                await dropbox.Files.DeleteAsync("/CS 341/Management/ReceptionManagement.txt");
            }

            //create the file
            manString += partyToLeave.managementOutput() + "\n";

            using (var mem = new MemoryStream(Encoding.UTF8.GetBytes(manString)))
            {
                var updated = await dropbox.Files.UploadAsync(
                    "/CS 341/Management/ReceptionManagement.txt",
                    WriteMode.Overwrite.Instance, body: mem);
            }
        }


        /**
         *  Downloads the report from 
         **/
        public async Task waitstaffCheck()
        {
            using (var response = await dropbox.Files.DownloadAsync("/CS 341/Reception/waitRecNumber.txt"))
            {
                resetTable(Convert.ToInt32(await response.GetContentAsStringAsync()));
            }

            await dropbox.Files.DeleteAsync("/CS 341/Reception/waitRecNumber.txt");
        }

    }
}
