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
    public partial class VolunteerFunctionalities : Form
    {
        int vol_ID;
       Controller controllerObject=new Controller();
        public VolunteerFunctionalities(int volunteerId)
        {
            vol_ID=volunteerId;
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
           DataTable dt= controllerObject.GetVolunteerName(vol_ID);
            label2.Text = dt.Rows[0][0].ToString();
        }

        private void BecomeEmployee_Click(object sender, EventArgs e)
        {
            SendRequest f = new SendRequest(vol_ID);
            f.Show();
           this.Close();
        }

        private void Join_Project_Click(object sender, EventArgs e)
        {
            JoinProjectRequest f = new JoinProjectRequest(vol_ID);
            f.Show();
          this.Close();
        }

        private void Redeem_Rewards_Click(object sender, EventArgs e)
        {
            RedeemRewards f = new RedeemRewards(vol_ID);
            f.Show();
           this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangePass f = new ChangePass(vol_ID,3);
            f.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckRequests f = new CheckRequests(vol_ID);
            f.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DonateMoney f = new DonateMoney(vol_ID);
            f.Show();
           this.Close();
        }

        private void VolunteerFunctionalities_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SignIn f = new SignIn();
           
            f.Show();
          this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            VolUpdateInfo f = new VolUpdateInfo(vol_ID);
            f.Show();
            this.Close();
        }
    }
}
