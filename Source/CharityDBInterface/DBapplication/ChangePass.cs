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
    public partial class ChangePass : Form
    {
        int UserType;
        int Id;
        Controller controllerObject = new Controller();
        public ChangePass(int userid,int usertype)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            Id = userid;
            UserType = usertype;
            old_password.PasswordChar = '*';
            Passwordentry1.PasswordChar = '*';
            Passwordentry2.PasswordChar = '*';
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(Passwordentry1.Text==""||Passwordentry2.Text==""||old_password.Text=="")
            {
                MessageBox.Show("Cannot leave any field empty!");
                return;
            }
            if(Passwordentry1.Text!=Passwordentry2.Text)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }
            if(UserType==1)
            {
                DataTable dt = controllerObject.CheckHeadPassPresent(Id);
                bool check = SecurePasswordHasher.Verify(old_password.Text, dt.Rows[0][0].ToString());
                if (!check)
                {
                    MessageBox.Show("Wrong old password");
                }
                else
                {
                    var hash = SecurePasswordHasher.Hash(Passwordentry1.Text);
                    int r = controllerObject.UpdateEmployeePass(Id, hash);
                    if (r != 0)
                    {
                        MessageBox.Show("Password updated successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update password");
                    }

                }
            }
            else if(UserType == 2)
            {
                DataTable dt = controllerObject.CheckEmployeePassPresent(Id);
                bool check = SecurePasswordHasher.Verify(old_password.Text, dt.Rows[0][0].ToString());
                if (!check)
                {
                    MessageBox.Show("Wrong old password");
                }
                else
                {
                    var hash = SecurePasswordHasher.Hash(Passwordentry1.Text);
                    int r = controllerObject.UpdateEmployeePass(Id, hash);
                    if (r != 0)
                    {
                        MessageBox.Show("Password updated successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update password");
                    }

                }
            }
            else
            {
                DataTable dt = controllerObject.CheckVolunteerPassPresent(Id);
                bool check = SecurePasswordHasher.Verify(old_password.Text, dt.Rows[0][0].ToString());
                if (!check)
                {
                    MessageBox.Show("Wrong old password");
                }
                else
                {
                    var hash = SecurePasswordHasher.Hash(Passwordentry1.Text);
                    int r = controllerObject.UpdateVolunteerPass(Id, hash);
                    if (r != 0)
                    {
                        MessageBox.Show("Password updated successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update password");
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if(UserType==1)
            {
                HeadFunctionalities f = new HeadFunctionalities(Id);
                this.Close();
            }
           else if(UserType==2)
            {
                EmployeeFunctionalities f = new EmployeeFunctionalities(Id);
                f.Show();
                this.Close();
            }
           else if(UserType ==3)
            {
                VolunteerFunctionalities f = new VolunteerFunctionalities(Id);
                f.Show();
                this.Close();
            }
        }
    }
}
