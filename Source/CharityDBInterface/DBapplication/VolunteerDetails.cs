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
    public partial class VolunteerDetails : Form
    {
        Controller contollerObject = new Controller();
        
        public VolunteerDetails()
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            
            Passwordentry1.PasswordChar = '*';
            Passwordentry2.PasswordChar = '*';
        }


        private void Finish_Click(object sender, EventArgs e)
        {
            string gender;
            if (radioButton1.Checked==true)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }
            if(Passwordentry1.Text == ""||Passwordentry2.Text==""||FirstName.Text==""||LastName.Text==""||Address.Text==""||PhoneNumber.Text==""||UserName.Text=="")
            {
                MessageBox.Show("Please enter all information!");
                return;
            }
            if(!FirstName.Text.All(Char.IsLetter))
            {
                MessageBox.Show("First name can only have letters");
                return;
            }
            if (!LastName.Text.All(Char.IsLetter))
            {
                MessageBox.Show("Last name can only have letters");
                return;
            }
            if (Passwordentry1.Text!=Passwordentry2.Text)
            {
                MessageBox.Show("Passwords Should Match");
                return;
            }
           var hash= SecurePasswordHasher.Hash(Passwordentry1.Text);
            if((DateTime.Today.Year-dateTimePicker1.Value.Year)<16)
            {
                MessageBox.Show("Cannot be younger than 16 to sign up!");
                return;
            }
            string birthDate = dateTimePicker1.Text.ToString();
            int r=contollerObject.InsertVolunteer(FirstName.Text, LastName.Text, birthDate, gender, Address.Text,PhoneNumber.Text,UserName.Text, hash);
            
            if(r==0)
            {
                MessageBox.Show("Username already exists!");// For developer use only
                return;
            }
            if(r==1)
            {
                MessageBox.Show("Signed up successfully!");
                //this.Close();
            }

            
        }


    }
}
