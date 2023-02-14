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
    public partial class inactivedonors : Form
    {
        Controller controllerObject = new Controller();
        int EmpId;
        public inactivedonors(int empId)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            EmpId = empId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime comptime = DateTime.Now;
            DateTime today = DateTime.Today;
            today = today.AddMonths(-1);
            string date = today.ToString("yyyy-MM-dd");
            DateTime comptimeadjusted= comptime.AddMonths(-1);
            
            DateTime comptime2 = DateTime.Now;

         
            DataTable dt = controllerObject.Selectinactivedonors(date);
            dataGridView1.DataSource = dt;

          
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeFunctionalities f = new EmployeeFunctionalities(EmpId);
            f.Show();
            this.Close();
        }
    }
}
