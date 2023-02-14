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
    public partial class EnterEmployeeUsername : Form
    {
        int VolID;
        int DepID;
        int Request_No;
        Controller ControllerObj = new Controller();
        public EnterEmployeeUsername(int volID,int depID,int request_No)
        {
            VolID = volID;
            DepID = depID;
            Request_No = request_No;
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Please enter a username first");
                return;
            }
            string username = textBox1.Text;

            DataTable dt = new DataTable();
            dt=ControllerObj.CheckUsernameExists(username);
            if (dt!=null)
            {
                MessageBox.Show("Username exists");
                return;
            }
           
           int r= ControllerObj.InsertEmployeeFromRequest(DepID,VolID,username);
            if (r==0)
            {
                MessageBox.Show("Volunteer already in a department!");
                return;
            }
            else
            {
                MessageBox.Show("Employment request accepted successfully!");

            }
            r=ControllerObj.SetRequestAccepted(Request_No);
            if(r==0)
            {
                MessageBox.Show("unsuccessful update"); //DELETE LATER
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
