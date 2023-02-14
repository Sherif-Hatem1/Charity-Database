using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class SignIn : Form
    {
        
        int VolunteerId;
        Controller contollerObject = new Controller();
        public SignIn()
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            Passwordentry1.PasswordChar = '*';
            comboBox1.Items.Add("Head");
            comboBox1.Items.Add("Employee");
            comboBox1.Items.Add("Volunteer");

        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void sign_in_Click(object sender, EventArgs e)
        {
            string username = UserName.Text;
            string password = Passwordentry1.Text;

            if (comboBox1.SelectedItem==null)
            {
                MessageBox.Show("Must select a type!");
                return;
            }
            string chosenType=comboBox1.SelectedItem.ToString();

            
            if (chosenType == "Volunteer")
            {
                DataTable dt = contollerObject.GetUsernameAndPassofVolunteer(username);
                if (dt == null)
                {
                    MessageBox.Show("Invalid username or password");
                }
                else
                {
                    bool check = SecurePasswordHasher.Verify(password, dt.Rows[0][1].ToString());
                    if (check)
                    {
                        VolunteerId = Convert.ToInt32(dt.Rows[0][2]);
                        VolunteerFunctionalities f = new VolunteerFunctionalities(VolunteerId);
                        f.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid password");
                    }
                }
            }
            else if (chosenType == "Head")
            {
                DataTable dt = contollerObject.GetHeadPass(username);
                if (dt == null)
                {
                    MessageBox.Show("Invalid username or password");
                }
                else
                {
                    bool check = SecurePasswordHasher.Verify(password, dt.Rows[0][1].ToString());
                    if (check)
                    {
                       int HeadId = Convert.ToInt32(dt.Rows[0][2]);
                        HeadFunctionalities f = new HeadFunctionalities(HeadId);
                        f.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid password");
                    }
                }
            }
            else if (chosenType == "Employee")
            {
                DataTable dt = contollerObject.GetEmployeePass(username);
                if (dt == null)
                {
                    MessageBox.Show("Invalid username or password");
                }
                else
                {
                    bool check = SecurePasswordHasher.Verify(password, dt.Rows[0][1].ToString());
                    if (check)
                    {
                        int EmployeeId = Convert.ToInt32(dt.Rows[0][2]);
                        EmployeeFunctionalities f = new EmployeeFunctionalities(EmployeeId);
                        f.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid password");
                    }
                }
            
            }
            
        }
    }
}
