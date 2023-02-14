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
    public partial class JoinProjectRequest : Form
    {
        int vol_ID;
        Controller controllerObject=new Controller();

        public JoinProjectRequest(int volunteer_Id)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            checkBox1.Checked = false;
            DataTable dt = controllerObject.SelectProjects();
            project.DataSource = dt;
            project.DisplayMember = "Project_Name";
            project.ValueMember = "Project_Num";
            vol_ID = volunteer_Id;
        }

    

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                DataTable dt = controllerObject.SelectNearByProjects(vol_ID);
                project.DataSource = dt;
                project.DisplayMember = "Project_Name";
                project.ValueMember = "Project_Num";
            }
            else
           {
                DataTable dt = controllerObject.SelectProjects();
                project.DataSource = dt;
                project.DisplayMember = "Project_Name";
                project.ValueMember = "Project_Num";
            }
        }

        private void Joinaproject_Click(object sender, EventArgs e)
        {
            DataTable checkPrev = controllerObject.CheckPrevRequest(Convert.ToInt32(project.SelectedValue), vol_ID);
            if (checkPrev != null)
            {
                MessageBox.Show("Request already sent!");
                return;
            }
            else
            {
                int r=controllerObject.SendJoinProjectRequest(Convert.ToInt32(project.SelectedValue), vol_ID);
                DataTable dt = controllerObject.SelectProjects();
                project.DataSource = dt;
                project.DisplayMember = "Project_Name";
                project.ValueMember = "Project_Num";
                if(r==0)
                {
                    MessageBox.Show("Couldn't send request");
                }
                else
                {
                    MessageBox.Show("Request sent successfully");
                }
                   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VolunteerFunctionalities f = new VolunteerFunctionalities(vol_ID);
            f.Show();
            this.Close();
        }
    }
}