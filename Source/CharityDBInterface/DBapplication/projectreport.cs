using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBapplication
{
    
    public partial class projectreport : Form
    {
        int HeadId;
        Controller controllerObject = new Controller();
        public projectreport(int Id)
        {
            HeadId = Id;
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            chart1.DataSource = controllerObject.getDaysRemainingAfterEnd();
            chart1.Series["Days"].XValueMember = "Project_Name";
            chart1.Series["Days"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chart1.Series["Days"].YValueMembers = "date_difference";
            chart1.Series["Days"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

            string stats = "Project statistics";
            DataTable dt = new DataTable();
            DataTable dtmax= new DataTable();
            DataTable dtmin = new DataTable();
            DataTable dtavg = new DataTable();
            DataTable dtidmax = new DataTable();
            DataTable dtidmin = new DataTable();
            dt.Columns.Add(stats);
            dt.Columns.Add("Value");
            dt.Columns.Add("Project Name");
            dt.Rows.Add("Max project cost");
            dt.Rows.Add("Min project cost");
            dt.Rows.Add("Average project cost");
        
           
            dataGridView1.DataSource = dt;
            dtmax = controllerObject.maxprojectcost();
            if(dtmax!=null)
            {
                int money = Convert.ToInt32(dtmax.Rows[0][0]);
                dtidmax = controllerObject.maxprojectcostid(money);
                dataGridView1.Rows[0].Cells[1].Value = dtmax.Rows[0][0];
                dataGridView1.Rows[0].Cells[2].Value = dtidmax.Rows[0][0].ToString();
            }
            
           
            dtmin = controllerObject.minprojectcost();
            if (dtmin!=null)
            {
                int money2 = Convert.ToInt32(dtmin.Rows[0][0]);
                dtidmin = controllerObject.maxprojectcostid(money2);
                dataGridView1.Rows[1].Cells[1].Value = dtmin.Rows[0][0];
                dataGridView1.Rows[1].Cells[2].Value = dtidmin.Rows[0][0];
            }
            dtavg= controllerObject.avgprojectcost();
            dataGridView1.Rows[2].Cells[1].Value = dtavg.Rows[0][0];

          
            



            //string sourceDateText = "31-08-2012";
            //DateTime sourceDate = DateTime.Parse(sourceDateText, "dd-MM-yyyy")

        }

        private void projectreport_Load(object sender, EventArgs e)
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
