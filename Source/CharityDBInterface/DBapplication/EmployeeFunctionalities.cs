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
    public partial class EmployeeFunctionalities : Form
    {
        
        int employeeId;
      Controller controllerObject=new Controller();
        public EmployeeFunctionalities(int Id)
        {
            InitializeComponent();
           DataTable dt= controllerObject.getEmpDepartment(Id);
            string departmentName=dt.Rows[0][0].ToString();
            if(departmentName== "Finance")
            {
                button1.Enabled=false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button10.Enabled = false;

            }
            else if(departmentName == "Public Relations")
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button9.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button11.Enabled = false;
            }
            else if(departmentName == "Human Resources")
            {
                button1.Enabled = false;
                button5.Enabled = false;
                button9.Enabled = false;
                button3.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
            }
            else if(departmentName== "Logistics")
            {
                button2.Enabled = false;
                button5.Enabled = false;
                button9.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
            }

            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            employeeId = Id;    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inventorysite f = new inventorysite(employeeId);
            f.Show();
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            AcceptVolunteersToJoinProject f = new AcceptVolunteersToJoinProject(employeeId);
            f.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ContactAffiliates f=new ContactAffiliates(employeeId);
            f.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ContactRecipients f = new ContactRecipients(employeeId);
            f.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            inactivedonors f=new inactivedonors(employeeId);
            f.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangePass f = new ChangePass(employeeId, 2);
            f.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SignIn f = new SignIn();
            f.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            EmployeeUpdateInfo f = new EmployeeUpdateInfo(employeeId,2);
            f.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1 f=new Form1();
            f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddRecipient f = new AddRecipient(employeeId);
            f.Show();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Close();
        }
    }
}
