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

    public partial class ManageProjects : Form
    {
        int headID;
        decimal maxFunds;

        Controller controllerObject = new Controller();
        public ManageProjects(int ID)
        { 
            headID = ID;
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            DataTable dt = controllerObject.findavailablefunds();
            if (dt != null)
            {

                decimal value = Convert.ToDecimal(dt.Rows[0][0]);
                numericUpDown1.Maximum = value;
                maxFunds = value;
                textBox1.Text = maxFunds.ToString();
            }
     
            DataTable dt2= controllerObject.SelectActiveProjectsManage();
            dataGridView1.DataSource = dt2;
        }

        private void ManageProjects_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select a project first!");
                return;
            }
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("You can only mark one project as complete at a time!");
                return;
            }
            int projid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            int r = controllerObject.SetProjectInactive(projid);
            if(r == 1)
            {
                MessageBox.Show("Project marked as done successfully!");
                DataTable dt2 = controllerObject.SelectActiveProjectsManage();
                if(dt2==null)
                {
                    MessageBox.Show("No more active projects!");
                    EmployeeFunctionalities f = new EmployeeFunctionalities(headID);
                    f.Show();
                    this.Close();
                }
                dataGridView1.DataSource = dt2;
                dataGridView1.Refresh();
            }
            else if(r==0)
            {
                MessageBox.Show("Couldn't mark project as done!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Must select a project first!");
                return;
            }
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("You can only add funding to one project at a time!");
                return;
            }
            int projid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            DateTime date = DateTime.Today;
            int amount = Convert.ToInt32(numericUpDown1.Value);
            if(amount==0)
            {
                MessageBox.Show("No availble Funds");
                return;
            }
           int r= controllerObject.AddProjectfunding(projid, date, amount);
            if (r == 1)
            {
                MessageBox.Show("Project funding added successfully!");
                DataTable dt2 = controllerObject.SelectActiveProjectsManage();
                dataGridView1.DataSource = dt2;
                dataGridView1.Refresh();
                DataTable dt = controllerObject.findavailablefunds();
                if (dt != null)
                {
                    decimal value = Convert.ToDecimal(dt.Rows[0][0]);
                    numericUpDown1.Maximum = value;
                    numericUpDown1.Refresh();
                    textBox1.Text= value.ToString();
                    textBox1.Refresh();
                }
            }
            else if (r == 0)
            {
                MessageBox.Show("Couldn't add project funding!");
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChooseProjectFunc f = new ChooseProjectFunc(headID);
            f.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
