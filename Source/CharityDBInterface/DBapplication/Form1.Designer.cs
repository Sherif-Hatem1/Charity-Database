namespace DBapplication
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartProject = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.projectBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.charityDBDataSet1 = new DBapplication.CharityDBDataSet1();
            this.button1 = new System.Windows.Forms.Button();
            this.charityDBDataSet = new DBapplication.CharityDBDataSet();
            this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectTableAdapter = new DBapplication.CharityDBDataSetTableAdapters.ProjectTableAdapter();
            this.projectTableAdapter1 = new DBapplication.CharityDBDataSet1TableAdapters.ProjectTableAdapter();
            this.chartDonors = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.financeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.activeDonors = new DBapplication.ActiveDonors();
            this.button2 = new System.Windows.Forms.Button();
            this.financeTableAdapter = new DBapplication.ActiveDonorsTableAdapters.FinanceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.chartProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charityDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charityDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDonors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeDonors)).BeginInit();
            this.SuspendLayout();
            // 
            // chartProject
            // 
            this.chartProject.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chartProject.BorderlineColor = System.Drawing.SystemColors.ActiveCaptionText;
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartArea1";
            this.chartProject.ChartAreas.Add(chartArea1);
            this.chartProject.DataSource = this.projectBindingSource1;
            legend1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            legend1.BackImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            legend1.BackSecondaryColor = System.Drawing.SystemColors.ActiveCaption;
            legend1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            legend1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartProject.Legends.Add(legend1);
            this.chartProject.Location = new System.Drawing.Point(26, 51);
            this.chartProject.Name = "chartProject";
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Capital";
            this.chartProject.Series.Add(series1);
            this.chartProject.Size = new System.Drawing.Size(814, 525);
            this.chartProject.TabIndex = 0;
            this.chartProject.Text = "Capital Per Project";
            title1.Font = new System.Drawing.Font("Century Gothic", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Capital Per Project";
            this.chartProject.Titles.Add(title1);
            // 
            // projectBindingSource1
            // 
            this.projectBindingSource1.DataMember = "Project";
            this.projectBindingSource1.DataSource = this.charityDBDataSet1;
            // 
            // charityDBDataSet1
            // 
            this.charityDBDataSet1.DataSetName = "CharityDBDataSet1";
            this.charityDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::DBapplication.Properties.Resources.employee;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(90, 592);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(421, 63);
            this.button1.TabIndex = 1;
            this.button1.Text = "View capitals per project";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // charityDBDataSet
            // 
            this.charityDBDataSet.DataSetName = "CharityDBDataSet";
            this.charityDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // projectBindingSource
            // 
            this.projectBindingSource.DataMember = "Project";
            this.projectBindingSource.DataSource = this.charityDBDataSet;
            // 
            // projectTableAdapter
            // 
            this.projectTableAdapter.ClearBeforeFill = true;
            // 
            // projectTableAdapter1
            // 
            this.projectTableAdapter1.ClearBeforeFill = true;
            // 
            // chartDonors
            // 
            this.chartDonors.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chartDonors.BorderlineColor = System.Drawing.SystemColors.ActiveCaption;
            chartArea2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            chartArea2.BackSecondaryColor = System.Drawing.SystemColors.ActiveCaption;
            chartArea2.Name = "ChartArea1";
            this.chartDonors.ChartAreas.Add(chartArea2);
            this.chartDonors.DataSource = this.financeBindingSource;
            legend2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            legend2.Font = new System.Drawing.Font("Century Gothic", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chartDonors.Legends.Add(legend2);
            this.chartDonors.Location = new System.Drawing.Point(855, 51);
            this.chartDonors.Name = "chartDonors";
            this.chartDonors.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.BackImageTransparentColor = System.Drawing.SystemColors.ActiveCaption;
            series2.BackSecondaryColor = System.Drawing.SystemColors.ActiveCaption;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Color = System.Drawing.SystemColors.ActiveCaption;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "Donors";
            series2.XValueMember = "Count";
            series2.YValueMembers = "Count";
            this.chartDonors.Series.Add(series2);
            this.chartDonors.Size = new System.Drawing.Size(928, 525);
            this.chartDonors.TabIndex = 2;
            this.chartDonors.Text = "chart1";
            title2.Font = new System.Drawing.Font("Century Gothic", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Most Active Donors";
            title2.Text = "Most Active Donors";
            this.chartDonors.Titles.Add(title2);
            this.chartDonors.Click += new System.EventHandler(this.chartDonors_Click);
            // 
            // financeBindingSource
            // 
            this.financeBindingSource.DataMember = "Finance";
            this.financeBindingSource.DataSource = this.activeDonors;
            // 
            // activeDonors
            // 
            this.activeDonors.DataSetName = "ActiveDonors";
            this.activeDonors.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GrayText;
            this.button2.BackgroundImage = global::DBapplication.Properties.Resources.employee;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1133, 582);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(379, 73);
            this.button2.TabIndex = 3;
            this.button2.Text = "View most active donors";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // financeTableAdapter
            // 
            this.financeTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::DBapplication.Properties.Resources.cool_background;
            this.ClientSize = new System.Drawing.Size(1655, 736);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chartDonors);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chartProject);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charityDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charityDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDonors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeDonors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartProject;
        private System.Windows.Forms.Button button1;
        private CharityDBDataSet charityDBDataSet;
        private System.Windows.Forms.BindingSource projectBindingSource;
        private CharityDBDataSetTableAdapters.ProjectTableAdapter projectTableAdapter;
        private CharityDBDataSet1 charityDBDataSet1;
        private System.Windows.Forms.BindingSource projectBindingSource1;
        private CharityDBDataSet1TableAdapters.ProjectTableAdapter projectTableAdapter1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDonors;
        private System.Windows.Forms.Button button2;
        private ActiveDonors activeDonors;
        private System.Windows.Forms.BindingSource financeBindingSource;
        private ActiveDonorsTableAdapters.FinanceTableAdapter financeTableAdapter;
    }
}