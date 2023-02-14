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
    public partial class ContactAffiliates : Form
    {
        Controller controllerObj=new Controller();
        int EmpId;
        public ContactAffiliates(int empId)
        {
            InitializeComponent();


            dataGridView1.DataSource = controllerObj.GetAffiliates();


            NameCombo.DataSource = controllerObj.GetAffiliates();
            NameCombo.ValueMember = "Affiliate";
            NameCombo.DisplayMember = "Affiliate";
            EmpId = empId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name;
            string type;
            string phone;
            int points;
            
            if(New.Checked==true)
            {
                if(NameText.Text==""||PhoneText.Text=="")
                {
                    MessageBox.Show("Enter all values!");
                    return;
                }
                name=NameText.Text;
                phone=PhoneText.Text;
            }
            else 
            {
                name=NameCombo.Text;
                DataTable dt = new DataTable();
                dt = controllerObj.GetAffiliateNumber(name);
                phone = dt.Rows[0][0].ToString();
            }
            if(TypeBox.Text=="")
            {
                MessageBox.Show("enter all values");
                return;
            }

            points = (int)numericUpDown1.Value;
            type = TypeBox.Text;

            controllerObj.InsertReward(type, name, points, phone);
            dataGridView1.DataSource= controllerObj.GetAffiliates();
            dataGridView1.Refresh();


            NameCombo.DataSource = controllerObj.GetAffiliates();
            NameCombo.ValueMember = "Affiliate";
            NameCombo.DisplayMember = "Affiliate";
            NameCombo.Refresh();
        }

        private void ContactAffiliates_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeFunctionalities f = new EmployeeFunctionalities(EmpId);
            f.Show();
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
