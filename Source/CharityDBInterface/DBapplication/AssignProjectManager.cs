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
    public partial class AssignProjectManager : Form
    {
        Controller controllerObject=new Controller();
        int HeadID;
        public AssignProjectManager(int headID)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            DataTable dt = new DataTable();
            dt = controllerObject.GetAllEmployeeNames();
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "Employee_id";
            dt.Columns.Add("FullName", typeof(string), "First_Name + ' ' + Last_Name ");
            comboBox1.DisplayMember = "FullName";

            DataTable dt2 = new DataTable();
            dt2 = controllerObject.SelectActiveProjects();
            dataGridView1.DataSource = dt2;
            HeadID = headID;

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
                MessageBox.Show("You can only select one project at a time!");
                return;
            }
            int PNo = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            int ENum = Convert.ToInt32(comboBox1.SelectedValue);
            int r = controllerObject.UpdateProjectEmployee(PNo, ENum);
            if (r == 0)
            {
                MessageBox.Show("Couldn't assign employee to project!");
                return;
            }
            else
            {
                MessageBox.Show("Employee assigned to project successfully!");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HeadFunctionalities f = new HeadFunctionalities(HeadID);
            f.Show();
            this.Close();
        }
    }
}
