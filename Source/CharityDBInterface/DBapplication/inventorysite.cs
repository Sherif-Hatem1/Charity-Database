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
    public partial class inventorysite : Form
    {
        int EmpId;
        Controller controllerObject = new Controller();
        public inventorysite(int empId)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
            DataTable dt3 = controllerObject.Selectsitesinfo();

            combosite.DataSource = dt3;
            combosite.ValueMember = "Site_No";
            combosite.DisplayMember = "Site_No";
            DataTable dt2 = controllerObject.Selectsupplierinfo();
            combosupplier.DataSource = dt2;
            combosupplier.ValueMember = "Supplier_id";
            combosupplier.DisplayMember = "Supplier_Name";
            if (combosupplier.SelectedValue != null)
            {


                DataTable dt = controllerObject.Selectonesupplier((int)combosupplier.SelectedValue);
                if (dt != null)
                {

                    decimal value = Convert.ToDecimal(dt.Rows[0][1]);
                    numericUpDown1.Maximum = value;
                }

            }
            EmpId = empId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObject.Selectsupplierinfo();
            dataGridViewsupplier.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObject.Selectsitesinfo();
            dataGridViewsites.DataSource = dt;
        }

      

        private void Transfer_Click(object sender, EventArgs e)
        {

            int site = Convert.ToInt32(combosite.SelectedValue);
            int id = Convert.ToInt32(combosupplier.SelectedValue);
            DataTable dt = controllerObject.Selecttrue(id, site);
            if (combosupplier.SelectedValue != null)
            {
                DataTable dt4 = controllerObject.Selectonesupplier((int)combosupplier.SelectedValue);
                if (dt != null)
                {
                    decimal value = Convert.ToDecimal(dt4.Rows[0][1]);
                    numericUpDown1.Maximum = value;
                }

            }
            if (dt==null)
            {
                MessageBox.Show("supplier's product type must match inventory site's product type");
            }
            else
            {

                int r = controllerObject.Insertsuppliersite((int)numericUpDown1.Value, (int)combosite.SelectedValue, (int)combosupplier.SelectedValue);
                if(r!=0)
                {
                    MessageBox.Show("supplies allocated succesfully");
                    DataTable dtsite = controllerObject.Selectsitesinfo();
                    dataGridViewsites.DataSource = dtsite;
                    dataGridViewsites.Refresh();
                    DataTable dtsupp = controllerObject.Selectsupplierinfo();
                    dataGridViewsupplier.DataSource = dtsupp;
                    dataGridViewsupplier.Refresh();
                }
            }
            if (combosupplier.SelectedValue != null)
            {
                DataTable dt4 = controllerObject.Selectonesupplier((int)combosupplier.SelectedValue);
                if (dt != null)
                {
                    decimal value = Convert.ToDecimal(dt4.Rows[0][1]);
                    numericUpDown1.Maximum = value;
                }

            }

        }



        private void inventorysite_Load(object sender, EventArgs e)
        {

        }

        private void combosite_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeFunctionalities f = new EmployeeFunctionalities(EmpId);
            f.Show();
            this.Close();
        }

        private void dataGridViewsupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void combosupplier_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dt4 = controllerObject.Selectonesupplier((int)combosupplier.SelectedValue);
            if (dt4 != null)
            {
                decimal value = Convert.ToDecimal(dt4.Rows[0][1]);
                numericUpDown1.Maximum = value;
            }
        }
    }
}
