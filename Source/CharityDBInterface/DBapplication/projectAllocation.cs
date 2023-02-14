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
    public partial class projectAllocation : Form
    {
        int HeadId;
        Controller controllerObject = new Controller();
        public projectAllocation(int Id)
        {
            HeadId = Id;
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            DataTable dt3 = controllerObject.Selectsitesinfo();

            combosite.DataSource = dt3;
            combosite.ValueMember = "Site_No";
            combosite.DisplayMember = "Site_No";
            DataTable dt2 = controllerObject.Selectprojectinfo();
            comboproject.DataSource = dt2;
            comboproject.ValueMember = "Project_Num";
            comboproject.DisplayMember = "Project_Name";
            if (combosite.SelectedValue != null)
            {


                DataTable dt = controllerObject.Selectonesite((int)combosite.SelectedValue);
                if (dt != null)
                {

                    decimal value = Convert.ToDecimal(dt.Rows[0][1]);
                    numericUpDown1.Maximum = value;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObject.Selectsitesinfo();
            dataGridViewsites.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObject.Selectprojectinfo();
            dataGridViewproject.DataSource = dt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Transfer_Click(object sender, EventArgs e)
        {

            int site = Convert.ToInt32(combosite.SelectedValue);
            int id = Convert.ToInt32(comboproject.SelectedValue);
            DataTable dt = controllerObject.Selecttrue2(id, site);
            if (combosite.SelectedValue != null)
            {
                DataTable dt5 = controllerObject.Selectonesite((int)combosite.SelectedValue);
                if (dt != null)
                {

                    decimal value = Convert.ToDecimal(dt5.Rows[0][1]);
                    numericUpDown1.Maximum = value;
                }

            }
            if (dt == null)
            {
                MessageBox.Show("projects's product type must match inventory site's product type");
            }
            else
            {

                int r = controllerObject.Insertprojectsite((int)numericUpDown1.Value, (int)combosite.SelectedValue, (int)comboproject.SelectedValue);
                if (r != 0)
                {
                    MessageBox.Show("supplies allocated succesfully");
                }
                if (combosite.SelectedValue != null)
                {


                    DataTable dt5 = controllerObject.Selectonesite((int)combosite.SelectedValue);
                    if (dt != null)
                    {

                        decimal value = Convert.ToDecimal(dt5.Rows[0][1]);
                        numericUpDown1.Maximum = value;
                    }

                }
            }
            DataTable dt1 = controllerObject.Selectsitesinfo();
            dataGridViewsites.DataSource = dt1;
            dataGridViewsites.Refresh();

            DataTable dt2 = controllerObject.Selectprojectinfo();
            dataGridViewproject.DataSource = dt2;
            dataGridViewproject.Refresh();
        }

        private void projectAllocation_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HeadFunctionalities f = new HeadFunctionalities(HeadId);
            this.Close();
        }

        private void combosite_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
                DataTable dt5 = controllerObject.Selectonesite((int)combosite.SelectedValue);
                if (dt5 != null)
                {

                    decimal value = Convert.ToDecimal(dt5.Rows[0][1]);
                    numericUpDown1.Maximum = value;
                }

        }
    }
}