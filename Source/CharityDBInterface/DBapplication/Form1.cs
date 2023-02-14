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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chartProject.Series["Capital"].XValueMember = "Project_Name";
            chartProject.Series["Capital"].XValueType=System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartProject.Series["Capital"].YValueMembers = "Project_Capital";
            chartProject.Series["Capital"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'activeDonors.Finance' table. You can move, or remove it, as needed.
            this.financeTableAdapter.Fill(this.activeDonors.Finance);
            // TODO: This line of code loads data into the 'charityDBDataSet1.Project' table. You can move, or remove it, as needed.
            this.projectTableAdapter1.Fill(this.charityDBDataSet1.Project);
            // TODO: This line of code loads data into the 'charityDBDataSet.Project' table. You can move, or remove it, as needed.
            this.projectTableAdapter.Fill(this.charityDBDataSet.Project);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            chartDonors.Series["Donors"].XValueMember = "Username";
            chartDonors.Series["Donors"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartDonors.Series["Donors"].YValueMembers = "Count";
            chartDonors.Series["Donors"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
         
        }

        private void chartDonors_Click(object sender, EventArgs e)
        {

        }
    }
}
