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
    public partial class DonateMoney : Form
    {
        int volunteer_Id;
        Controller contollerObject = new Controller();
        public DonateMoney(int id)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            volunteer_Id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MonetaryAmount.Text == "")
            {
                MessageBox.Show("Please enter value of money to donate.");
                return;
            }
            if(Convert.ToInt32(MonetaryAmount.Text)<0)
            {
                MessageBox.Show("Donation must be a positive amount!");
                return;
            }
            int check = contollerObject.AddDonation(volunteer_Id, Convert.ToInt32(MonetaryAmount.Text));
       
            if (check != 0)
            {
                MessageBox.Show("Thank you for your donation!");
            }
            else
            {
                MessageBox.Show("Donation Failed");
            }
        }

        private void MonetaryAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt=contollerObject.SelectProjects();
            dt.Columns.Remove("Project_Num");
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VolunteerFunctionalities f = new VolunteerFunctionalities(volunteer_Id);
            f.Show();
            this.Close();
        }
    }
}
