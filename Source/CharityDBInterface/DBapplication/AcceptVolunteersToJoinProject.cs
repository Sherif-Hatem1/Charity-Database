using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBapplication
{
    public partial class AcceptVolunteersToJoinProject : Form
    {
        int EmpId;
        Controller controllerObject = new Controller();
        public AcceptVolunteersToJoinProject(int empId)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            DataTable dt = controllerObject.SelectVolunteerTojoinProjects();
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["Request_No"].Visible = false;
                dataGridView1.Columns["Volunteer_Code"].Visible = false;
                dataGridView1.Columns["Project_key"].Visible = false;
            }
            EmpId = empId;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select a request first!");
                return;
            }
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("You can only approve one request at a time");
            }
            
            else
            {
                  int requestnum = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                  int volid= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
                  int projid= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
                  int check = controllerObject.AddVolunteertoProject(volid, projid);
                if (check == 0)
                {
                    MessageBox.Show("Error occured");
                }
                else
                {

                    int r = controllerObject.SetRequestAccepted(requestnum);
                    if (r == 0)
                    {
                        MessageBox.Show("Request failed to set to accepted");
                    }
                    MessageBox.Show("Request approved!");
                    DataTable dt = controllerObject.SelectVolunteerTojoinProjects();
                    if (dt == null)
                    {
                        MessageBox.Show("No more pending requests!");
                        this.Close();
                        EmployeeFunctionalities f = new EmployeeFunctionalities(EmpId);
                        f.Show();
                        return;
                    }
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["Request_No"].Visible = false;
                    dataGridView1.Columns["Volunteer_Code"].Visible = false;
                    dataGridView1.Columns["Project_key"].Visible = false;
                    dataGridView1.Refresh();

                }
              
            }


        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select a request first!");
                return;
            }
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("You can only reject one request at a time");
            }
            else
            {
                int requestnum = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                int check = controllerObject.SetRequestRejected(requestnum);
                if (check == 0)
                {
                    MessageBox.Show("Request failed to set to rejected");
                }
                else
                {
                    MessageBox.Show("Request rejected");
                    DataTable dt = controllerObject.SelectVolunteerTojoinProjects();
                    if(dt == null)
                    {
                        MessageBox.Show("No more pending requests!");
                        this.Close();
                        EmployeeFunctionalities f = new EmployeeFunctionalities(EmpId);
                        f.Show();
                        return;
                    }
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["Request_No"].Visible = false;
                    dataGridView1.Columns["Volunteer_Code"].Visible = false;
                    dataGridView1.Columns["Project_key"].Visible = false;
                    dataGridView1.Refresh();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeFunctionalities f = new EmployeeFunctionalities(EmpId);
            f.Show();
            this.Close();
        }
    }
}
