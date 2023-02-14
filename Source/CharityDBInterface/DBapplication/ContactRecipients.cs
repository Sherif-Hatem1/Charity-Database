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
    public partial class ContactRecipients : Form
    {
        int EmpId;
        Controller controllerObj= new Controller();
        public ContactRecipients(int empId)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            DataTable dt = new DataTable();
            dt = controllerObj.GetRecipients();
            dataGridView1.DataSource = dt;



            comboBox1.DataSource = dt;
            dt.Columns.Add("FullName", typeof(string), "First_Name + ' ' + Last_Name ");
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "Recipient_id";
            EmpId = empId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID =Convert.ToInt32( comboBox1.SelectedValue);
            int Feedback = (int)numericUpDown1.Value;
            controllerObj.SetFeedback(Feedback, ID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeFunctionalities f = new EmployeeFunctionalities(EmpId);
            f.Show();
            this.Close();
        }
    }
}
