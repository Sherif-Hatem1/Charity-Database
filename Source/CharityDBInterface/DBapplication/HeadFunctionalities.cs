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
    public partial class HeadFunctionalities : Form
    {
        int Id;
        public HeadFunctionalities(int headId)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            Id = headId;    
        }

        private void Hire_Employee_Click(object sender, EventArgs e)
        {
            HireEmloyee f = new HireEmloyee(Id);
            f.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FireEmployee g = new FireEmployee(Id);
            g.Show();
            this.Close();
        }
       

        private void Addproject1_Click(object sender, EventArgs e)
        {
            Addproject h = new Addproject(Id);
            h.Show();
            this.Close();
        }

        private void projectreport_Click(object sender, EventArgs e)
        {
            projectreport s = new projectreport(Id);
            s.Show();
            this.Close();
        }

        private void HeadFunctionalities_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangePass f = new ChangePass(Id,1);
            f.Show();
           this.Close();
        }

        private void Review_Requests_Click(object sender, EventArgs e)
        {
            ViewEmployeeRequests f=new ViewEmployeeRequests(Id);
            f.Show();
           this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            projectAllocation f=new projectAllocation(Id);
            f.Show();
          this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SignIn f=new SignIn();
            f.Show();
          this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmployeeUpdateInfo f = new EmployeeUpdateInfo(Id,1);
            f.Show();
           this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChooseProjectFunc f = new ChooseProjectFunc(Id);
            f.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AssignProjectManager f = new AssignProjectManager(Id);
            f.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AssignEmployeeToInventorySites f = new AssignEmployeeToInventorySites(Id);
            f.Show();
            this.Close();
        }
    }
}
