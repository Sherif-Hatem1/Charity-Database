using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;


namespace DBapplication
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            DataSet2 d = new DataSet2();//esm el dataset
            string cs = @"Data Source=DESKTOP-SM12V1I\SQLEXPRESS;Initial Catalog=CharityDB;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("select Issue_Date,Monetary_Amount,Transaction_Type,Project_Code,Project_Name From Finance,Project where Transaction_Type='Project' AND Project_Code=Project_Num order by Project_Code",cn);//el query
            SqlDataAdapter da2 = new SqlDataAdapter("select Issue_Date,Monetary_Amount,First_Name,Last_Name From Finance f,Volunteer v where v.Volunteer_id=f.Volunteer_ID", cn);
            SqlDataAdapter da3 = new SqlDataAdapter("SELECT ((SELECT SUM(Monetary_Amount) From Finance where Transaction_Type='Donation') - (SELECT SUM(Monetary_Amount) From Finance where Transaction_Type='Project')) as Funds", cn);
            da.Fill(d, d.Tables[0].TableName);//eda?
            da2.Fill(d,d.Tables[1].TableName);
            da3.Fill(d, d.Tables[2].TableName);
            ReportDataSource rds3 = new ReportDataSource("Funds", d.Tables[2]);
            ReportDataSource rds2 = new ReportDataSource("Donations", d.Tables[1]);
            ReportDataSource rds = new ReportDataSource("Finance", d.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.DataSources.Add(rds2);
            this.reportViewer1.LocalReport.DataSources.Add(rds3);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
