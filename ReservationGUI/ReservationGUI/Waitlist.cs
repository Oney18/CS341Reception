﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationGUI
{
    class Waitlist
    {
        private Table[] tableList;
        private LinkedList<Party> reservationsPresent;
        private LinkedList<Party> walkIns;
        private ArrayList takeOut;
        private ArrayList reservations;
        private ArrayList pastParties;

        /**
         *  Ctor for the waitlist
         *  
         *  Input: Amount of tables in the restaraunt
         **/
        public Waitlist(int num)
        {
            reservationsPresent = new LinkedList<Party>();
            walkIns = new LinkedList<Party>();
            takeOut = new ArrayList();
            reservations = new ArrayList();
            pastParties = new ArrayList();
            tableList = new Table[num];
            for (int i = 0; i < num; i++)
            {
                tableList[i] = new Table(i);
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
                reservationsPresent.AddLast(partyToCheck);
                reservations.Remove(partyToCheck);
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
            foreach(Party p in takeOut)
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


        /**
         *  Seats the next party at the indicated table
         **/
        public void seatNextParty(int tableNum)
        {
            if (!tableList[tableNum].getInUse()) //checks to make sure not already being used
            {
                Party temp = getNextParty();
                tableList[tableNum].seat(temp);
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
            }
        }


        /**
         *  Creates a file under C:\Reception files to be outputted to Management
         * 
         *  Needs to be put into dropbox
         **/
        public void ToManagement()
        {

            if (!Directory.Exists(@"C:\ReceptionFiles")) //Create the directory if it is not there
            {
                Directory.CreateDirectory(@"C:\ReceptionFiles");
            }

            using (StreamWriter file =
            new StreamWriter(@"C:\ReceptionFiles\ReceptionManagement.txt"))
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
                if(line.Contains("0") ||
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
}
