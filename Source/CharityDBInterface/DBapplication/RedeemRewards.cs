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
    public partial class RedeemRewards : Form
    {
        Controller controllerObject=new Controller();
        int Volunteer_id;
        DataColumn rewardnumcol;
        DataTable table;
        public RedeemRewards(int vol_ID)
        {
            Volunteer_id = vol_ID;
           InitializeComponent();
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.EnableHeadersVisualStyles = false;
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            DataTable dt= controllerObject.RetrievePoints(vol_ID);
          // textBox1.Text = dt.Rows[0][0].ToString();
            DataTable rewards = controllerObject.RetrieveRewards();
            dataGridView1.DataSource=rewards;
            label2.Text = dt.Rows[0][0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("You can only redeem one reward at a time");
            }
            else
            {
                int rewardnum = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                if(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value)>Convert.ToInt32(label2.Text))
                {
                    MessageBox.Show("Insufficient number of points, participate in more projects and gain more points!");
                    return;
                }
                int check = controllerObject.RedeemReward(rewardnum, Volunteer_id);
                if (check == 0)
                {
                    MessageBox.Show("Error occured");
                }
                else
                {
                    MessageBox.Show("Reward Redeemed Succesfully!");
                    DataTable dt2 = controllerObject.RetrievePoints(Volunteer_id);
                   // textBox1.Text = dt2.Rows[0][0].ToString();
                    label2.Text= dt2.Rows[0][0].ToString();
                }
                DataTable dt = controllerObject.RetrieveRewards();
                dataGridView1.Columns.Remove(dataGridView1.Columns[2]);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
        }

        private void RedeemRewards_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            VolunteerFunctionalities f = new VolunteerFunctionalities(Volunteer_id);
            f.Show();
            this.Close();
        }
    }
}
