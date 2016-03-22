using System;
using System.Collections;
using System.Collections.Generic;
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
        private int phoneNum;
        private int tableNum;
        private DateTime arrivalTime;
        private DateTime seatedTime;
        private DateTime reservationTime;
        private DateTime leaveTime;

        public Party(int partySize, String name, String specialReq, int phoneNum)
        {
            this.name = name;
            this.partySize = partySize;
            this.specialReq = specialReq;
            this.phoneNum = phoneNum;
        }

        public Party(int partySize, String name, String specialReq, int phoneNum, DateTime reservationTime)
        {
            this.name = name;
            this.partySize = partySize;
            this.specialReq = specialReq;
            this.phoneNum = phoneNum;
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
            return phoneNum;
        }

        public void setPhoneNum(int phoneNum)
        {
            this.phoneNum = phoneNum;
        }

        public void arrive()
        {
            arrivalTime = DateTime.Now;
        }

        public String getArrivalTime()
        {
            return arrivalTime.ToString("t");
        }

        public void seat(int num)
        {
            seatedTime = DateTime.Now;
            tableNum = num;
        }

        public String getSeatedTime()
        {
            return seatedTime.ToString("t");
        }

        public void leave()
        {
            leaveTime = DateTime.Now;
        }

        public String getLeaveTime()
        {
            return leaveTime.ToString("t");
        }

        public DateTime getResTime()
        {
            return reservationTime;
        }


    }

    class ReservationSystem
    {
        private Table[] tableList;
        private LinkedList<Party> reservationsPresent;
        private LinkedList<Party> walkIns;
        private ArrayList reservations;

        public ReservationSystem(int num)
        {
            reservationsPresent = new LinkedList<Party>();
            walkIns = new LinkedList<Party>();
            reservations = new ArrayList();
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

        public void leave()
        {
            this.partySeated = null;
            inUse = false;
        }

        public void clean()
        {
            if(!inUse) ableToBeSeated = true;
        }


    }
}
