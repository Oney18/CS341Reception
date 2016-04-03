using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationGUI
{
    class Table
    {
        private bool inUse;
        private int peopleSeated;
        private bool ableToBeSeated;
        private Party partySeated;
        private int tableNum;
        static public int SIZE_OF_TABLE = 4;

        //Constrcutor for the table
        public Table(int num)
        {
            this.tableNum = num;
            inUse = false;
            ableToBeSeated = true;
            partySeated = null;
        }

        //Seats a given party to the table
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

        //Resets the table for use, updates party status
        public Party leave()
        {
            Party temp = partySeated;
            temp.leave();
            partySeated = null;
            inUse = false;
            return temp;
        }

        public void clean()
        {
            if (!inUse) ableToBeSeated = true;
        }

        public bool getAbleToBeSeated()
        {
            return ableToBeSeated;
        }

        public bool getInUse()
        {
            return inUse;
        }


    }
}
