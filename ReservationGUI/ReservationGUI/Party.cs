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
        private int partyType;
        private string tableNum;
        private DateTime arrivalTime;
        private DateTime seatedTime;
        private DateTime reservationTime;
        private DateTime leaveTime;

        // Walk-In Constructor
        public Party(string partySize, string name, string specialReq, string pagerNum, int partyType)
        {
            this.name = name;
            this.partySize = partySize;
            this.specialReq = specialReq;
            this.pagerNum = pagerNum;
            this.partyType = partyType;
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
