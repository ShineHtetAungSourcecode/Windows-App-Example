using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        double mytotal = 0;
        double totalpaytooffice = 0;
        public Form1()
        {
            InitializeComponent();
            loadListview();
           
        }

        private void loadListview()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("MeterID", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("Type", 100, HorizontalAlignment.Center);
            
            display.View = View.Details;
            display.Columns.Add("MeterID", 100, HorizontalAlignment.Center);
            display.Columns.Add("Type", 100, HorizontalAlignment.Center);
            
            listViewCalc.View = View.Details;
            listViewCalc.Columns.Add("Meter ID", 100, HorizontalAlignment.Center);
            listViewCalc.Columns.Add("Meter Type", 100, HorizontalAlignment.Center);
            listViewCalc.Columns.Add("Meter Unit", 100, HorizontalAlignment.Center);
            listViewCalc.Columns.Add("Amount Pay to Office", 100, HorizontalAlignment.Center);
            listViewCalc.Columns.Add("Non-PO Charges", 100, HorizontalAlignment.Center);
            listViewCalc.Columns.Add("PO Charges", 100, HorizontalAlignment.Center);
            listViewCalc.Columns.Add("Total Charges", 100, HorizontalAlignment.Center);
        }

       
        private string MeterType(string meterID)
        {
            // Check meter ID format and defind Type
            bool ans;
            Regex r=new Regex(@"XN-\d{5,}");
            ans = r.IsMatch(meterID);
            if (ans == true)
            {
                return "Power";
            }
            else
            {
                Regex r1 = new Regex(@"\w+-\d{5,}");
                ans = r1.IsMatch(meterID);
                if (ans == true)
                {
                    return "Meter";
                }
                else
                {
                    MessageBox.Show("Incorrect Meter ID!!","Warning",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                    return "Error!!!!";
                }
            }

            //return "Power"; // Return here
        }

        private void register_Click(object sender, EventArgs e)
        {
            
               //Sample - how to reterive data from listview [s]
            string _meterID = "";
            foreach (ListViewItem _item in listView1.Items)
            {
                //MessageBox.Show(_item.Text + " - " + _item.SubItems[1].Text);
                //_meterID = _meterID==""?_item.Text: _meterID + "~" + _item.Text;

                if (_meterID == "")
                {
                   _meterID = _item.Text;
                }
                else 
                {
                   _meterID = _meterID + "~" + _item.Text;
                }
            }
            //return; // it will stop here
            
            //Sample - how to reterive data from listview [e]

            string RName = name.Text;
            string RNrc = nrc.Text;
            string Rph = phno.Text;
            string Radd = address.Text;
            //string Rid = meterid.Text;
            string Rid = _meterID;
            //string Rtype = metertype.Text;
            string RTsp = tsp.Text;

            DateTime dt = date.Value;
            int day = dt.Day;
            int month = dt.Month;
            int year = dt.Year;
            try
            {
                Date d = new Date(month, day, year);
                Customer c = new Customer(RName, RNrc, Rph, Radd, RTsp,d, Rid);
                DataAccess da = new DataAccess();
                if (da.Saving(c))
                {
                    MessageBox.Show("Registration complete...", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Can't Process!! This Name or Meter ID is already registered!!!!!", "Error Mssage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(InvalidUnitException exp)
            {
                MessageBox.Show(exp.Message, "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            catch (InvalidNrcException exp)
            {
                MessageBox.Show(exp.Message, "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            catch (InvalidPhnoException exp)
            {
                MessageBox.Show(exp.Message, "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            catch(InvalidAddressException exp)
            {
                MessageBox.Show(exp.Message, "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            catch (InvalidTspException exp)
            {
                MessageBox.Show(exp.Message, "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            catch(InvalidIdException exp)
            {
                MessageBox.Show(exp.Message, "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            catch(InvalidTypeException exp)
            {
                MessageBox.Show(exp.Message, "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            
        }

        
        private void simplesearch_Click(object sender, EventArgs e)
        {
            display.Items.Clear();
            //string ans = searchname.Text;
            DataAccess da = new DataAccess();
            Customer cu=da.Search_Customer(searchname.Text);
            
            if (cu != null)
            {                
               //MessageBox.Show( cu.Name + "," + cu.Nrc + "," + cu.Phno + "," + cu.Address + "," + cu.Township);
                txtSearchCustName.Text = cu.Name;
                txtSearchCustNrc.Text = cu.Nrc;
                txtSearchCustPhno.Text = cu.Phno;
                txtSearchCustAdd.Text = cu.Address;
                txtSearchCustTsp.Text = cu.Township;
                txtSearchCustdate.Text = cu.Date.ToString();

                string[] _MeteridList = cu.Meterid.Split('~');

                foreach (string meterid in _MeteridList)
                {
                      string[] liststring = {meterid,MeterType(meterid)};
                      ListViewItem listViewItem = new ListViewItem(liststring);
                      display.Items.Add(listViewItem);
                }
            }
            else {
                MessageBox.Show("No Result!!! Check Your Spelling such as  Capital Letters, Small Letters and Space etc..","Display",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            
            if (meterid.Text != "")
            {
                string[] liststring = { meterid.Text, MeterType(meterid.Text)};
                ListViewItem listViewItem = new ListViewItem(liststring);
                listView1.Items.Add(listViewItem);
                meterid.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.RemoveAt(listView1.Items.IndexOf(item));
            }
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            //try
            //{
            double totalamt = 0;
                foreach (ListViewItem item in listViewCalc.SelectedItems)
                {
                    double discount;
                    //double ans;
                        try
                        {
                        item.SubItems[2].Text = txtCalcMeterUnit.Text;
                        item.SubItems[3].Text = AmtPayToOffice(txtCalcMeterUnit.Text, txtCalcMeterType.Text).ToString();
                        item.SubItems[4].Text = "1000";
                        item.SubItems[5].Text = GetPOCharges(double.Parse(item.SubItems[3].Text)).ToString();
                        double _PoNonPo = double.Parse(item.SubItems[4].Text) + double.Parse(item.SubItems[5].Text);
                        item.SubItems[6].Text = _PoNonPo.ToString();
                        totalamt = totalamt + _PoNonPo;
                        mytotal += totalamt;
                    
                        if (listViewCalc.Items.Count >= 3)
                        {
                            discount = mytotal * 0.03;
                            txtDiscount.Text = discount.ToString();
                        }
                        else
                        {
                            discount = 0;
                            txtDiscount.Text = discount.ToString();
                        }
                        txtActualAmount.Text = (mytotal - discount).ToString();
                        txtTotalAmount.Text = mytotal.ToString();
                        //totalpaytooffice += int.Parse(AmtPayToOffice(txtCalcMeterUnit.Text, txtCalcMeterType.Text).ToString());
                        //txt_tapto.Text = totalpaytooffice.ToString();
                        //ans = double.Parse(txt_tapto.Text) + double.Parse(txtActualAmount.Text);
                        //txt_alltotalcharges.Text = ans.ToString();
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Wring Meter Unit!! Click Clear Button and Try Again!!", "Warning!!!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        }
                        catch (OverflowException)
                        {
                            MessageBox.Show("Wring Meter Unit!! Click Clear Button and Try Again!!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                }

                txtCalcMeterUnit.Text = "";
                //////Sample - how to reterive data from listview [s]
                ////DataAccess da = new DataAccess();
                ////List<Customer> _LsCustomer = da.Display();
                ////List<Customer> _ResultCu = null;

                ////foreach (ListViewItem _item in listViewCalc.Items)
                ////{
                ////   // MessageBox.Show(_item.SubItems[1].Text);

                ////    foreach (Customer cu in _LsCustomer)
                ////    {
                ////        string[] Listmeterid = cu.Meterid.Split('~');
                ////        foreach (string meterid in Listmeterid)
                ////        {
                ////            if (_item.SubItems[1].Text == meterid)
                ////            {
                ////                _ResultCu.Add(cu);
                ////                break;
                ////            }
                ////        }
                ////    }

                ////}
            //}
            //catch (InvalidUnitCalcException exp)
            //{
            //    MessageBox.Show(exp.Message, "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //}
        }

        private double GetPOCharges(double _AmtPayToOffice)
        {
            double _return = 0;
            if (_AmtPayToOffice >= 200000)
            {
                _return = (_AmtPayToOffice * 0.002);
            }
            else
            {
                _return = (_AmtPayToOffice*0);
            }
            return _return;
        }

        private void promotionsearch_Click_1(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
                dataGridView1.Rows.Clear();
                foreach (Customer cu in da.DisplayPromo())
                {
                    if (da.Promotion1(cu) == true && cu.Township == "Sanchaung")
                    {
                        string[] row = { cu.Name, cu.Meterid, cu.Nrc, cu.Phno, cu.Address, cu.Township, cu.Date.ToString() };
                        dataGridView1.Rows.Add(row);
                    }
                    
                }
        }

        private void displayforall_Click_1(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            dataGridView2.Rows.Clear();
            List<Customer> ans = da.Display();
            foreach (Customer p in ans)
            {
                string[] row = { p.Name, p.Nrc, p.Phno, p.Address,p.Township,p.Date.ToString(), p.Meterid };
                dataGridView2.Rows.Add(row);
            }
        }

        private void clear1_Click(object sender, EventArgs e)
        {
            name.Text = "";
            nrc.Text = "";
            phno.Text = "";
            address.Text = "";
            tsp.Text = "";
            meterid.Text = "";
            listView1.Items.Clear();
        }

        private void clr_Click(object sender, EventArgs e)
        {
            searchname.Text = "";
            txtSearchCustName.Text ="";
            txtSearchCustNrc.Text = "";
            txtSearchCustPhno.Text = "";
            txtSearchCustdate.Text = "";
            txtSearchCustAdd.Text = "";
            txtSearchCustTsp.Text = "";
            display.Items.Clear();
        }


        private double AmtPayToOffice(string _MeterUnit,string _MeterType)
        {
            double amt=0;
            //Calculate Amt Pay to office +-*/Unittextbox
            double ans = double.Parse(_MeterUnit);

            if (_MeterType == "Meter")
            {
                if (ans <= 100)
                {
                    amt = ans * 35;
                }
                else if (ans > 100)
                {
                    amt = ans * 50;
                }
            }
            else if (_MeterType == "Power")
            {
                if (ans <= 500)
                {
                    amt = ans * 75;
                }
                else if (ans > 500)
                {
                    amt = ans * 100;
                }
            }
            return amt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            
            if (tabControl1.SelectedTab.Name == "tabPage3")
            {
                DataAccess da = new DataAccess();
                List<Customer> lsCu = da.Display();
                cboName.DataSource = lsCu;
                cboName.DisplayMember = "Name";
                cboName.ValueMember = "Name";
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
                listViewCalc.Items.Clear();
                DataAccess da = new DataAccess();
           try
            {
                Customer cu = da.Search_Customer(cboName.Text);
                //string[] liststring = { cu.Meterid };
                //ListViewItem listViewItem = new ListViewItem(liststring);
                //listViewCalc.Items.Add(listViewItem);

                string[] _MeteridList = cu.Meterid.Split('~');
                foreach (string meterid in _MeteridList)
                {
                    string[] liststring = { meterid, MeterType(meterid), "", "", "", "", "" };
                    ListViewItem listViewItem = new ListViewItem(liststring);
                    listViewCalc.Items.Add(listViewItem);
                }
            }
           catch (NullReferenceException)
           {
               MessageBox.Show("No Customer is registered!!!You can't Calculate!!", "Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
           }
            
        }

        private void listViewCalc_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewCalc.SelectedItems)
            {
                //MessageBox.Show(item.SubItems[0].Text);
                txtCalcMeterID.Text = item.SubItems[0].Text;
                txtCalcMeterType.Text = item.SubItems[1].Text;
                //txt_alltotalcharges.Text = txt_tapto.Text + txtActualAmount.Text;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mytotal = 0;
            txtCalcMeterID.Text = "";
            txtCalcMeterType.Text = "";
            listViewCalc.Items.Clear();
            txtDiscount.Text = "";
            txtTotalAmount.Text = "";
            txtActualAmount.Text = "";
            txtCalcMeterUnit.Text = "";
        }


        //private void remove_Click(object sender, EventArgs e)
        //{
        //    foreach (ListViewItem item in listViewCalc.SelectedItems)
        //    {
        //        listViewCalc.Items.RemoveAt(listViewCalc.Items.IndexOf(item));
        //    }
        //}
        // update by searching for text in subitems.
 // find a reference for the listviewitem with specific text in any of it's subitems.
 //ListViewItem lvi = listView1.FindItemWithText("4th");
 //if (lvi != null)
 //{
 //// Using the reference, update the value.
 //lvi.SubItems[0].Text = "Updated by reference (" + i.ToString() + ")";
 //i++;
 //}
    }
}