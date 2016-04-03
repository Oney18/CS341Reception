﻿using System;
using System.Collections;
using System.Collections.Generic;
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
        private ArrayList reservations;
        private ArrayList pastReservations;

        /**
         *  Ctor for the waitlist
         *  
         *  Inpout: Amount of tables in the restaraunt
         **/
        public Waitlist(int num)
        {
            reservationsPresent = new LinkedList<Party>();
            walkIns = new LinkedList<Party>();
            reservations = new ArrayList();
            pastReservations = new ArrayList();
            tableList = new Table[num];
            for (int i = 0; i < num; i++)
            {
                tableList[i] = new Table(i);
            }
        }


        /**
         *  Constructor for adding a reservation for the day
         **/
        public void addReservation(int partySize, String name, String specialReq, int phoneNum, int hour, int minute)
        {
            DateTime reservationTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0);
            reservations.Add(new Party(partySize, name, specialReq, phoneNum, reservationTime));
        }


        /**
         *  Checks in the given party based on name
         *
         *  Only allows parties that are within one hour to be checked in
         **/
        public void checkIn(String name)
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
                    reservationsPresent.AddLast(partyToCheck);
                    reservations.Remove(partyToCheck);
                }
                else Console.WriteLine("Party {0} cannot be checked in; more than 1 hour out.", name); //too far out to check in
            }
            else
            {
                Console.WriteLine("Could not find party under name {0}.", name); //could not find reservation
            }

        }


        /**
         *  Constructor for adding a walk-in party
         **/
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
                pastReservations.Add(temp);
            }
        }


        /**
         *  Creates a file under C:\Reception files to be outputted to Management
         * 
         *  Needs to be put into dropbox
         **/
        public void ToManagement()
        {

            if (!System.IO.Directory.Exists(@"C:\ReceptionFiles")) //Create the directory if it is not there
            {
                System.IO.Directory.CreateDirectory(@"C:\ReceptionFiles");
            }

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
}
