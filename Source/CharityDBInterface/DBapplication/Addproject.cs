using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBapplication
{
    

    public partial class Addproject : Form
    {
        Controller controllerObject = new Controller();
        int HeadId;
        public Addproject(int Id)
        {
           

            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            HeadId = Id;

            DataTable dt = new DataTable();
            dt = controllerObject.getemployeesid();
            projectmanager.DataSource = dt;
            dt.Columns.Add(
              "FullName",
             typeof(string),
             "First_Name + ' ' + Last_Name ");

            projectmanager.DisplayMember = "FullName";

            projectmanager.ValueMember = "Employee_id";
         

        }

      

        
        private void Add_Click(object sender, EventArgs e)
        {
           
            if (pname.Text == "" || city.Text == "" || textBox1.Text=="")
            {
                MessageBox.Show("Can't leave project city, name or supply type empty!");
              
            }
           else if(EndDate.Value<StartDate.Value)
            {
                MessageBox.Show("Project start date cannot be after its end date");
            }
            else
            {



                    string startDate = StartDate.Text.ToString();
                    string endDate = EndDate.Text.ToString();
                    int employeeid = Convert.ToInt32(projectmanager.SelectedValue);
                    string projectname = pname.Text;
                    string projectcity = city.Text;
                    int points = (int)numericUpDown1.Value;
                    
                    int r = controllerObject.InsertProject(projectname, projectcity, startDate, endDate, "active", employeeid,textBox1.Text,points);
                    if (r == 0)
                    {
                        MessageBox.Show("Failed to add project");
                    }
                    else
                    {
                        MessageBox.Show("Project added succesfully");
                    }
              
            }

        }

        private void projectmanager_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HeadFunctionalities f = new HeadFunctionalities(HeadId);
            this.Close();
        }
    }
}
