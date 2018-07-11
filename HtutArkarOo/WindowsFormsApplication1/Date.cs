using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Date
    {
        int day;

        public int Day
        {
            get { return day; }
            set
            {
                if (value >= 1 && value <= 31)
                {
                    day = value;
                }
                else
                {
                    day = 1;
                }
            }
        }
        int month;

        public int Month
        {
            get { return month; }
            set
            {
                if (value >= 1 && value <= 12)
                {

                    month = value;
                }
                else
                {
                    month = 1;
                }
            }
        }
        int year;

        public int Year
        {


            get { return year; }
            set
            {
                DateTime dt = DateTime.Now;

                if (value >= 1 && value <= dt.Year)
                {

                    year = value;
                }
                else
                {
                    year = 0001;
                }
            }
        }
        public Date(int month, int day, int year)
        {
            Day = day;
            Month = month;
            Year = year;

        }
        public override string ToString()
        {
            return String.Format("{0}:{1}:{2}",Month,Day,Year);

        }
    }
}
