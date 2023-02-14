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
    public partial class EmployeeUpdateInfo : Form
    {
        int ID;
        int SendingForm;
        Controller contollerObject = new Controller();
        public EmployeeUpdateInfo(int EmpID,int form)
        {
            InitializeComponent();
              FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            ID = EmpID;
            SendingForm = form;
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            if (FirstName.Text != "")
            {
                string first = FirstName.Text;
                if (!first.All(Char.IsLetter))
                {
                    MessageBox.Show("First Name can only contain letters!");
                    return;
                }
                int r = contollerObject.UpdateEmployeeFirstName(first, ID);
                if (r == 0)
                {
                    MessageBox.Show("Couldn't update First Name!");
                }
                else if (r == 1)
                {
                    MessageBox.Show("First Name updated successfully!");
                }
            }
            if (LastName.Text != "")
            {
                string lastName = LastName.Text;
                if (!lastName.All(Char.IsLetter))
                {
                    MessageBox.Show("Last Name can only contain letters!");
                    return;
                }
                int r = contollerObject.UpdateEmployeeLastName(lastName, ID);
                if (r == 0)
                {
                    MessageBox.Show("Couldn't update Last Name!");
                }
                else if (r == 1)
                {
                    MessageBox.Show("Last Name updated successfully!");
                }
            }
            if (Address.Text != "")
            {
                string address = Address.Text;
                int r = contollerObject.UpdateEmployeeAddress(address, ID);
                if (r == 0)
                {
                    MessageBox.Show("Couldn't update address!");
                }
                else if (r == 1)
                {
                    MessageBox.Show("address updated successfully!");
                }
            }
            if (PhoneNumber.Text != "")
            {
                string phoneNumber = PhoneNumber.Text;
                int r = contollerObject.UpdateEmployeePhoneNumber(phoneNumber, ID);
                if (r == 0)
                {
                    MessageBox.Show("Couldn't update phone number!");
                }
                else if (r == 1)
                {
                    MessageBox.Show("Phone number updated successfully!");
                }
            }
            if (UserName.Text != "")
            {
                string userName = UserName.Text;
                int r = contollerObject.UpdateEmployeeUsername(userName, ID);
                if (r == 0)
                {
                    MessageBox.Show("Username already exists!");
                }
                else if (r == 1)
                {
                    MessageBox.Show("Username updated successfully!");
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(SendingForm==1)
            {
                HeadFunctionalities f = new HeadFunctionalities(ID);
                f.Show();
            }
            else if(SendingForm==2)
            {
                EmployeeFunctionalities f = new EmployeeFunctionalities(ID);
                f.Show();
            }
           
            this.Close();
        }

        private void Address_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
