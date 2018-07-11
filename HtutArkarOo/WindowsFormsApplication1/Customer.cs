using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    class Customer
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                Regex r = new Regex(@"(\w+\s)+|(\w+)");
                bool ans = r.IsMatch(value);
                if (ans)
                {
                    name = value;
                }
                else
                {
                    throw new InvalidUnitException("Invalid Name!!");
                }
            }
        }

        private string nrc;
        public string Nrc
        {
            get
            {
                return nrc;
            }
            set
            {
                Regex r = new Regex(@"(\d{2}/\w+\(\w\)\d{6})|(\d/\w+\(\w\)\d{6})");
                bool ans = r.IsMatch(value);
                if (ans)
                {
                    nrc = value;
                }
                else
                {
                    throw new InvalidNrcException("Invalid Nrc!!!!");
                }
            }
        }
        private string phno;
        public string Phno
        {
            get
            {
                return phno;
            }
            set
            {
                Regex r = new Regex(@"(09-\d{7,9})|(01-\d{6})");
                bool ans = r.IsMatch(value);
                if (ans)
                {
                    phno = value;
                }
                else
                {
                    throw new InvalidPhnoException("Invalid Phone Number!!");
                }
            }
        }

        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value != String.Empty)
                {
                    address = value;
                }
                else
                {
                    throw new InvalidAddressException("Invalid Address!!");
                }
            }
        }

        private string township;
        public string Township
        {
            get
            {
                return township;
            }
            set{
                if(value!=String.Empty)
                {
                   township=value;
                }
                else
                {
                    throw new InvalidTspException("Invalid Township!");
                }
            }
        }

        private string meterid;
        public string Meterid
        {
            get
            {
                return meterid;
            }
            set
            {
                Regex r = new Regex(@"(\w+-\d{5,})");
                bool ans = r.IsMatch(value);
                if (ans)
                {
                    meterid = value;
                }
                else
                {
                    throw new InvalidIdException("Invalid Meter Id Number!!!");
                }
            }
        }

        private Date date;
        internal Date Date
        {
            get {
                     return date;
                }
            set { 
                  date = value; 
                }
        }
        public Customer(string name, string nrc, string phno, string address,string township,Date date,string meterid)
        {
            Name = name;
            Nrc = nrc;
            Phno = phno;
            Address = address;
            Date = date;
            Meterid = meterid;
            Township = township;
        }

        public override string ToString()
        {
            return String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", name, nrc, phno, address,township,date,meterid);
        }
    }
}
