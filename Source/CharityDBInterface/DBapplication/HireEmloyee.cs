using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DBapplication
{

  

    public partial class HireEmloyee : Form
    {
        int HeadId;
        Controller contollerObject = new Controller();
        public HireEmloyee(int Id)
        {
            HeadId = Id;
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            DataTable dt = contollerObject.SelectDep();
            DepName.DataSource = dt;
            DepName.DisplayMember = "Dep_Name";
            DepName.ValueMember = "Dep_Number";

            Passwordentry1.PasswordChar = '*';
            Passwordentry2.PasswordChar = '*';
        }



        private void Finish_Click(object sender, EventArgs e)
        {
            string birthDate = dateTimePicker1.Text.ToString();
            string fname = FirstName.Text;
            string Lname = LastName.Text;
            int depnum = Convert.ToInt32(DepName.SelectedValue);
            string gender;
            string address = Address.Text;
            string phonenum = PhoneNumber.Text;
            string username = UserName.Text;
            if (fname == "" || Lname == "" || address == ""  || username == ""||phonenum==""||Passwordentry1.Text==""||Passwordentry2.Text=="")
            {
                MessageBox.Show("Please enter all missing values!");
                return;
            }
            if (Passwordentry1.Text != Passwordentry2.Text)
            {
                MessageBox.Show("Passwords Should Match");
                return;
            }
            var hash = SecurePasswordHasher.Hash(Passwordentry1.Text);
            if (radioButton1.Checked == true)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }
            if ((DateTime.Today.Year - dateTimePicker1.Value.Year) < 16)
            {
                MessageBox.Show("Employees cannot be younger than 16!");
                return;
            }
            if(!fname.All(Char.IsLetter))
            {
                MessageBox.Show("First name can only include letters!");
                return;
            }
            if (!Lname.All(Char.IsLetter))
            {
                MessageBox.Show("Last name can only include letters!");
                return;
            }
            int r= contollerObject.InsertEmployee(fname, Lname, depnum,birthDate, gender, address, phonenum, username,hash);
            if(r == 0)
            {
                MessageBox.Show("Username already exists!");

            }
            else if (r == 1)
            {
                MessageBox.Show("Employee hired successfully!");
            }
        }

        private void HireEmloyee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HeadFunctionalities f=new HeadFunctionalities(HeadId);
            this.Close();
        }

        private void FirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void LastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Address_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
