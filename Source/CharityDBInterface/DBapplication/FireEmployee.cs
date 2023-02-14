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
    public partial class FireEmployee : Form
    {
        int HeadID;
        Controller controllerObject = new Controller();
        public FireEmployee(int headID)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            HeadID = headID;
            DataTable dt = controllerObject.Viewemployeesfire(HeadID);
            dataGridView1.DataSource = dt;
            dataGridView1.Show();
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

      
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("can only fire one employee at a time");
            }
            else
            {

                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
                int check=controllerObject.FireEmployee(id);
                if(check==0)
                {
                    MessageBox.Show("failed to fire employee");
                }
                else
                {
                    MessageBox.Show("Employee fired succesfully");
                }
                DataTable dt = controllerObject.Viewemployeesfire(HeadID);
                dataGridView1.DataSource = dt;
                
                dataGridView1.Refresh();
              
                 

                
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            HeadFunctionalities f = new HeadFunctionalities(HeadID);
            this.Close();
        }
    }
}
