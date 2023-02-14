using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace DBapplication
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            SoundPlayer player = new SoundPlayer(@"C:\Users\husse\OneDrive\Desktop\All Courses\DataBase\DB2412\DB2412\HopeSound.wav");
            player.Play();
            InitializeComponent();
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            VolunteerDetails f = new VolunteerDetails();
            f.Show();
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            SignIn f = new SignIn();
            f.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
