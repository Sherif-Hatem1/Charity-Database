namespace DBapplication
{
    partial class SendRequest
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
            this.College_Degree = new System.Windows.Forms.Label();
            this.DepName = new System.Windows.Forms.ComboBox();
            this.Send_Request = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // College_Degree
            // 
            this.College_Degree.AutoSize = true;
            this.College_Degree.BackColor = System.Drawing.Color.Transparent;
            this.College_Degree.Font = new System.Drawing.Font("Century Gothic", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.College_Degree.Location = new System.Drawing.Point(7, 125);
            this.College_Degree.Name = "College_Degree";
            this.College_Degree.Size = new System.Drawing.Size(430, 34);
            this.College_Degree.TabIndex = 1;
            this.College_Degree.Text = "Preferred Department Location";
            // 
            // DepName
            // 
            this.DepName.BackColor = System.Drawing.SystemColors.Info;
            this.DepName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DepName.Font = new System.Drawing.Font("Century Gothic", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DepName.FormattingEnabled = true;
            this.DepName.Location = new System.Drawing.Point(510, 125);
            this.DepName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DepName.Name = "DepName";
            this.DepName.Size = new System.Drawing.Size(229, 42);
            this.DepName.TabIndex = 2;
            // 
            // Send_Request
            // 
            this.Send_Request.BackgroundImage = global::DBapplication.Properties.Resources.volunteer;
            this.Send_Request.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Send_Request.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Send_Request.Font = new System.Drawing.Font("Century Gothic", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send_Request.Location = new System.Drawing.Point(449, 339);
            this.Send_Request.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Send_Request.Name = "Send_Request";
            this.Send_Request.Size = new System.Drawing.Size(341, 110);
            this.Send_Request.TabIndex = 3;
            this.Send_Request.Text = "Request to be an employee";
            this.Send_Request.UseVisualStyleBackColor = true;
            this.Send_Request.Click += new System.EventHandler(this.Send_Request_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Century Gothic", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::DBapplication.Properties.Resources.volbackground;
            this.button2.Location = new System.Drawing.Point(14, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(244, 64);
            this.button2.TabIndex = 60;
            this.button2.Text = "Back to Menu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SendRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DBapplication.Properties.Resources.volunteer;
            this.ClientSize = new System.Drawing.Size(971, 640);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Send_Request);
            this.Controls.Add(this.DepName);
            this.Controls.Add(this.College_Degree);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SendRequest";
            this.Text = "SendRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label College_Degree;
        private System.Windows.Forms.ComboBox DepName;
        private System.Windows.Forms.Button Send_Request;
        private System.Windows.Forms.Button button2;
    }
}