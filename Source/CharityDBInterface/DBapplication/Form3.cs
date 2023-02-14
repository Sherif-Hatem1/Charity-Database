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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            
            this.reportViewer1.RefreshReport();
            DataSetRecipients d = new DataSetRecipients();//esm el dataset
            string cs = @"Data Source=DESKTOP-SM12V1I\SQLEXPRESS;Initial Catalog=CharityDB;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("Select avg(Feedback_Rating) as average,Project_Name from Recipient,project where Project_No=Project_Num group by Project_Name", cn);//el query
           
            da.Fill(d, d.Tables[0].TableName);//eda?
            
            ReportDataSource rds = new ReportDataSource("Recipient", d.Tables[0]);
            
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
