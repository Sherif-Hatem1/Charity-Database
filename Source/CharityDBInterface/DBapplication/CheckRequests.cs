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
    public partial class CheckRequests : Form
    {
        int VolunteerID;
        Controller contollerObject = new Controller();
        public CheckRequests(int id)
        {
            VolunteerID= id;
            InitializeComponent();
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.EnableHeadersVisualStyles = false;
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            DataTable dt= contollerObject.SelectRequests(id);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VolunteerFunctionalities f = new VolunteerFunctionalities(VolunteerID);
            f.Show();
            this.Close();
        }
    }
}
