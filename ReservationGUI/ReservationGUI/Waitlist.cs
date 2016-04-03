using System;
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

        public void addReservation(string partySize, string name, string specialReq, string phoneNum, int month, int day, int hour, int minute)
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
                else Console.WriteLine("Party {0} cannot be checked in; more than 1 hour out.", name);
            }
            else
            {
                Console.WriteLine("Could not find party under name {0}.", name);
            }

        }

        public void addWalkIn(int partySize, String name, String specialReq, int phoneNum)
        {
            walkIns.AddLast(new Party(partySize, name, specialReq, ));
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
            if (!tableList[tableNum].getInUse())
            {
                Party temp = getNextParty();
                tableList[tableNum].seat(temp);
            }
        }

        public void resetTable(int tableNum)
        {
            if (tableList[tableNum].getInUse())
            {
                Party temp = tableList[tableNum].leave();
                pastReservations.Add(temp);
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

    class unitTest
    {
        public static void main(string[] args)
        {
            Waitlist wl = new Waitlist(16);
            wl.addWalkIn(3, "Oney", "", 89);
            wl.addWalkIn(2, "SOmebody", "", 5);
            wl.seatNextParty(5);
            wl.seatNextParty(3);
            wl.resetTable(3);
            wl.resetTable(5);
            wl.ToManagement();
        }
       
    }
}
