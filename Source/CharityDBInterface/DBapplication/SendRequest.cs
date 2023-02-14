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
    public partial class SendRequest : Form
    {
        Controller controllerObject = new Controller();
        int VolunteerID;
        public SendRequest(int volunteerID)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            DataTable dt = controllerObject.SelectDep();
            DepName.DataSource = dt;
            DepName.DisplayMember = "Dep_Name";
            DepName.ValueMember = "Dep_Number";
            VolunteerID = volunteerID;
        }

        private void Send_Request_Click(object sender, EventArgs e)
        {
            DataTable checkPrev = controllerObject.CheckPrevEmpRequest(Convert.ToInt32(DepName.SelectedValue), VolunteerID);
            if (checkPrev != null)
            {
                MessageBox.Show("Request already sent!");
                return;
            }
            int depNumber = Convert.ToInt32(DepName.SelectedValue);
           int r= controllerObject.SendBeAnEmployeeRequest(depNumber, VolunteerID);
            if(r!=0)
            {
                MessageBox.Show("Request sent successfully");
            }
            else 
            {
                MessageBox.Show("Request failed to send");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            VolunteerFunctionalities f = new VolunteerFunctionalities(VolunteerID);
            f.Show();
            this.Close();
        }
    }
}
