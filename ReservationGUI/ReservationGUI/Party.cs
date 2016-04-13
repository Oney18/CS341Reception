using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationGUI
{
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
        private DateTime pickUpTime;

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
        public Party(string name, string phoneNum, DateTime pickUptime)
        {
            this.name = name;
            this.phoneNum = phoneNum;
            this.pickUpTime = pickUptime;
        }

        public DateTime getArrivalTime()
        {
            return arrivalTime;
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

        public void setIsSeated(bool seated)
        {
            isSeated = seated;
        }

        public bool isBigParty()
        {
            if (Int32.Parse(partySize) > 4)
            {
                return true;
            }
            else
            {
                return false;
            }
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
         *  Creates the message to put to waitstaff
         **/
        public string waitstaffOutput()
        {
            string temp = "";

            temp += tableNum + "\n";
            temp += partySize + "\n";
            temp += specialReq + "\n";

            return temp;
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
