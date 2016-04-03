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
}
