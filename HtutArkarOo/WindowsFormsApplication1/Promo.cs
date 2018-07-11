//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WindowsFormsApplication1
//{
//    class Promo
//    {
//        public bool Promotion(Customer cu)
//        {
//            bool ans;
//            DateTime ct = DateTime.Now;
//            int sy = cu.Date.Year;
//            int cy = ct.Year;
//            int sm = cu.Date.Month;
//            int cm = ct.Month;
//            int y = cy - sy;
//            if (y >= 2)
//            {
//                ans = true;
//            }
//            else if (y <= 0)
//            {
//                ans = false;
//            }
//            else
//            {
//                if (sm >= cm)
//                {
//                    ans = false;
//                }
//                else
//                {
//                    ans = true;
//                }
//            }
//            return ans;
//        }
//        //public List<Customer> searchpromo()
//        //{
//        //    List<Customer> res = Display();
//        //    List<Customer> ansr = new List<Customer>();
//        //    DateTime ct = DateTime.Now;
//        //    bool ans;
//        //    foreach (Customer cu in res)
//        //    {
//        //        int sy = cu.Date.Year;
//        //        int cy = ct.Year;
//        //        int sm = cu.Date.Month;
//        //        int cm = ct.Month;
//        //        int y = cy - sy;
//        //        if (y >= 2)
//        //        {
//        //            ans = true;

//        //        }
//        //        else if (y <= 0)
//        //        {
//        //            ans = false;
//        //        }
//        //        else
//        //        {
//        //            if (sm >= cm)
//        //            {
//        //                ans = false;
//        //            }
//        //            else
//        //            {
//        //                ans = true;
//        //            }
//        //        }
//        //        return ans;
//        //    }

//        //    return ansr;
//        //}
//    }
//}
