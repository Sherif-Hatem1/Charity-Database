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
    public partial class ChooseProjectFunc : Form
    {
        int id;
        public ChooseProjectFunc(int Id)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            id = Id;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ManageProjects h = new ManageProjects(id);
            h.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Addproject h = new Addproject(id);
            h.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HeadFunctionalities h = new HeadFunctionalities(id);
            h.Show();
            this.Close();
        }
    }
}
