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

    public partial class ViewEmployeeRequests : Form
    {
        int HeadId;
        Controller ControllerObj=new Controller();
        public ViewEmployeeRequests(int Id)
        {
            HeadId = Id;
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            DataTable dt = new DataTable();
            dt = ControllerObj.GetEmployeeRequests();
            dataGridView1.DataSource= dt;
        }

        private void RejectButton_Click(object sender, EventArgs e)

        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Can only reject one request at a time");
                return;
            }
            int ReqNo = (int)dataGridView1.SelectedRows[0].Cells["Request_No"].Value;
            int r=ControllerObj.SetRequestRejected(ReqNo);
            if (r == 0)
            {
                MessageBox.Show("Couldn't reject request");
            }
            else if(r == 1)
            {
                MessageBox.Show("Request rejected successfully");
            }
            DataTable dt = new DataTable();
            dt = ControllerObj.GetEmployeeRequests();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Can only accept one request at a time");
                return ;
            }
            int VolID = (int)dataGridView1.SelectedRows[0].Cells["Volunteer_Code"].Value;
            int DepID = (int)dataGridView1.SelectedRows[0].Cells["Department_No"].Value;
            int ReqNo=  (int)dataGridView1.SelectedRows[0].Cells["Request_No"].Value;
            EnterEmployeeUsername f=new EnterEmployeeUsername(VolID,DepID, ReqNo);
            f.Show();
           
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HeadFunctionalities f = new HeadFunctionalities(HeadId);
            f.Show();
            this.Close();
        }
    }
}
