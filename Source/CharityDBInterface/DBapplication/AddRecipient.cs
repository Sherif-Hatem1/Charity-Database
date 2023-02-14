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
    public partial class AddRecipient : Form
    {
        int EmpID;
        Controller controllerObject = new Controller();
        public AddRecipient(int empID)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;

            EmpID = empID;
            DataTable dt = new DataTable();

            dt= controllerObject.SelectActiveProjectsManage();
            if(dt==null)
            {
                MessageBox.Show("There are no active projects to add a recipient to!");
                this.Close();
                EmployeeFunctionalities f = new EmployeeFunctionalities(EmpID);
                return;
            }
            comboBox1.DataSource = dt;
                
            comboBox1.ValueMember = "Project_Num";
            comboBox1.DisplayMember = "Project_Name";
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            string gender;
            if (radioButton1.Checked == true)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }
            if ( FirstName.Text == "" || LastName.Text == "" || Address.Text == "" || PhoneNumber.Text == "" )
            {
                MessageBox.Show("Please enter all information!");
                return;
            }
            if (!FirstName.Text.All(Char.IsLetter))
            {
                MessageBox.Show("First name can only have letters");
                return;
            }
            if (!LastName.Text.All(Char.IsLetter))
            {
                MessageBox.Show("Last name can only have letters");
                return;
            }
            
            string birthDate = dateTimePicker1.Text.ToString();
            int r = controllerObject.InsertRecipient(FirstName.Text, LastName.Text, birthDate, gender, Address.Text, PhoneNumber.Text,Convert.ToInt32(comboBox1.SelectedValue));

            if (r == 0)
            {
                MessageBox.Show("Username already exists!");// For developer use only
                return;
            }
            if (r == 1)
            {
                MessageBox.Show("Signed up successfully!");
                this.Close();
            }

        }
    }
}
