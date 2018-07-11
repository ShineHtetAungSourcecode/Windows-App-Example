using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class DataAccess
    {

        public bool Saving(Customer cu1)
        {
            bool ans;
            if (!IsContain(cu1.Name) && !IsContainID(cu1.Meterid))
            {

                string path = Application.StartupPath + @"\customerdata.txt";
                FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(cu1);
                sw.Close();
                fs.Close();
                ans = true;

            }
            else
            {
                ans = false;
            }

            return ans;

        }
        public bool IsContain(string name)
        {
            List<Customer> ans = Display();
            bool answer = false;
            foreach (Customer c in ans)
            {
                if (c.Name == name)
                {
                    answer = true;
                }
            }

            return answer;
        }

        public bool IsContainID(string id)
        {
            List<Customer> ans = Display();
            bool answer = false;
            foreach (Customer c in ans)
            {
                if (c.Meterid== id)
                {
                    answer = true;
                }
            }

            return answer;
        }
        public Customer Search_Customer(string custName)
        {
            string path = Application.StartupPath + @"\customerdata.txt";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string sub1;
            Customer cu;
            //cu = Search_Customer(txtsearchname.txt);
            //if (cu != null)
            //{
            //cu.Name}
            //else { 
            //    // no data
            //}
            while ((sub1 = sr.ReadLine()) != null)
            {
                string[] arr = sub1.Split('|');
                if(arr[0]==custName)
                {
                    String dob = arr[5];
                    string[] arr1 = dob.Split(':');
                    int month = int.Parse(arr1[0]);
                    int day = int.Parse(arr1[1]);
                    int year = int.Parse(arr1[2]);
                    Date date = new Date(month, day, year);
                    cu = new Customer(arr[0], arr[1], arr[2], arr[3], arr[4], date, arr[6]);
                    sr.Close();
                    fs.Close();
                    return cu;
                }
            }

            sr.Close();
            fs.Close();
            return null;
            
        }

        public List<Customer> Display()
        {
            List<Customer> ans = new List<Customer>();
            string path = Application.StartupPath + @"\customerdata.txt";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string sub1;
            Customer cu;
            while ((sub1 = sr.ReadLine()) != null)
            {
                string[] arr = sub1.Split('|');
                String dob = arr[5];
                string[] arr1 = dob.Split(':');
                int month = int.Parse(arr1[0]);
                int day = int.Parse(arr1[1]);
                int year = int.Parse(arr1[2]);


                Date date = new Date(month, day, year);
                cu = new Customer(arr[0], arr[1], arr[2], arr[3], arr[4], date, arr[6]);
                ans.Add(cu);
                
            }
            sr.Close();
            fs.Close();

            return ans;
        }

        public List<Customer> DisplayPromo()
        {
            List<Customer> ans = new List<Customer>();
            string path = Application.StartupPath + @"\customerdata.txt";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string sub1;
            Customer cu;
            while ((sub1 = sr.ReadLine()) != null)
            {
                string[] arr = sub1.Split('|');
                String dob = arr[5];
                string[] arr1 = dob.Split(':');
                int month = int.Parse(arr1[0]);
                int day = int.Parse(arr1[1]);
                int year = int.Parse(arr1[2]);
                string mi = arr[6];
                string[] arrt =mi.Split('~');

                if(arrt.Length>1)
                {
                    int i=0;
                    while(arrt.Length>i){
                    arr[6] = arrt[i];
                    Date date = new Date(month, day, year);
                    cu = new Customer(arr[0], arr[1], arr[2], arr[3], arr[4], date, arr[6]);
                    ans.Add(cu);
                   // sr.Close();
                    //fs.Close();
                    i++;
                    }
                }
                else
                {
                    Date date = new Date(month, day, year);
                    cu = new Customer(arr[0], arr[1], arr[2], arr[3], arr[4], date, arr[6]);
                    ans.Add(cu);
                    //sr.Close();
                //    fs.Close();
                }
            //    for(int i=0, arrt.Length>=i , i++){
            //        arr[6]=arrt[i];
            //        Date date = new Date(month, day, year);
            //    cu = new Customer(arr[0], arr[1], arr[2], arr[3], arr[4], date, arr[6]);
            //    ans.Add(cu);
            //sr.Close();
            //fs.Close();
                //}

            }
            sr.Close();
            fs.Close();

            return ans;
        }
        public bool Promotion1(Customer cu)
        {
            bool ans;
            DateTime ct = DateTime.Now;
            int sy = cu.Date.Year;
            int cy = ct.Year;
            int sm = cu.Date.Month;
            int cm = ct.Month;
            int sd = cu.Date.Day;
            int cd = ct.Day;
            int y = cy - sy;
            if (y >= 2)
            {
                ans = true;
            }
            else if (y <= 0)
            {
                ans = false;
            }
            else
            {
                if (sm < cm)
                {
                    ans = true;
                }
                    else if(sm==cm)
                {
                    if (sd <= cd)
                    {
                        ans = true;
                    }
                    else
                    {
                        ans = false;
                    }
                }
                else
                {
                    ans =false;
                }
            }
            return ans;
        }
        //public List<Customer> searchpromo()
        //{
        //    //List<Customer> res = Display();
        //    //List<Customer> ansr = new List<Customer>();
        //    //DateTime ct = DateTime.Now;
        //    //bool ans;
        //    //foreach (Customer cu in res)
        //    //{
        //    //    int sy = cu.Date.Year;
        //    //    int cy = ct.Year;
        //    //    int sm = cu.Date.Month;
        //    //    int cm = ct.Month;
        //    //    int y = cy - sy;
        //    //    if (y >= 2)
        //    //    {
        //    //        ans = true;
        //    //    }
        //    //    else if (y <= 0)
        //    //    {
        //    //        ans = false;
        //    //    }
        //    //    else
        //    //    {
        //    //        if (sm >= cm)
        //    //        {
        //    //            ans = false;
        //    //        }
        //    //        else
        //    //        {
        //    //            ans = true;
        //    //        }
        //    //    }
        //    //    return ans;
        //    //}

        //    //return ansr;
        //}
    }
}

