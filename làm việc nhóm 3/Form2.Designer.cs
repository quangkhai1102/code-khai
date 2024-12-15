namespace làm_việc_nhóm_3
{
    partial class dashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_pay = new Guna.UI2.WinForms.Guna2Button();
            this.btn_staff = new Guna.UI2.WinForms.Guna2Button();
            this.btn_detail = new Guna.UI2.WinForms.Guna2Button();
            this.btn_register = new Guna.UI2.WinForms.Guna2Button();
            this.btn_add = new Guna.UI2.WinForms.Guna2Button();
            this.panelmoving = new Guna.UI2.WinForms.Guna2Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1882, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelmoving);
            this.panel2.Controls.Add(this.btn_pay);
            this.panel2.Controls.Add(this.btn_staff);
            this.panel2.Controls.Add(this.btn_detail);
            this.panel2.Controls.Add(this.btn_register);
            this.panel2.Controls.Add(this.btn_add);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1882, 100);
            this.panel2.TabIndex = 1;
            // 
            // btn_pay
            // 
            this.btn_pay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_pay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_pay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_pay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_pay.FillColor = System.Drawing.Color.LightPink;
            this.btn_pay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pay.ForeColor = System.Drawing.Color.Black;
            this.btn_pay.Location = new System.Drawing.Point(1589, 6);
            this.btn_pay.Name = "btn_pay";
            this.btn_pay.Size = new System.Drawing.Size(180, 91);
            this.btn_pay.TabIndex = 4;
            this.btn_pay.Text = "Thanh toán";
            this.btn_pay.Click += new System.EventHandler(this.btn_pay_Click);
            // 
            // btn_staff
            // 
            this.btn_staff.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_staff.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_staff.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_staff.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_staff.FillColor = System.Drawing.Color.LightPink;
            this.btn_staff.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_staff.ForeColor = System.Drawing.Color.Black;
            this.btn_staff.Location = new System.Drawing.Point(1244, 6);
            this.btn_staff.Name = "btn_staff";
            this.btn_staff.Size = new System.Drawing.Size(180, 91);
            this.btn_staff.TabIndex = 3;
            this.btn_staff.Text = "Nhân viên";
            this.btn_staff.Click += new System.EventHandler(this.btn_staff_Click);
            // 
            // btn_detail
            // 
            this.btn_detail.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_detail.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_detail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_detail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_detail.FillColor = System.Drawing.Color.LightPink;
            this.btn_detail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_detail.ForeColor = System.Drawing.Color.Black;
            this.btn_detail.Location = new System.Drawing.Point(835, 6);
            this.btn_detail.Name = "btn_detail";
            this.btn_detail.Size = new System.Drawing.Size(258, 91);
            this.btn_detail.TabIndex = 2;
            this.btn_detail.Text = "Chi tiết khách hàng";
            this.btn_detail.Click += new System.EventHandler(this.btn_detail_Click);
            // 
            // btn_register
            // 
            this.btn_register.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_register.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_register.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_register.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_register.FillColor = System.Drawing.Color.LightPink;
            this.btn_register.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_register.ForeColor = System.Drawing.Color.Black;
            this.btn_register.Location = new System.Drawing.Point(428, 3);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(272, 91);
            this.btn_register.TabIndex = 1;
            this.btn_register.Text = "Đăng ký khách hàng";
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // btn_add
            // 
            this.btn_add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_add.FillColor = System.Drawing.Color.LightPink;
            this.btn_add.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.Black;
            this.btn_add.Location = new System.Drawing.Point(114, 6);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(180, 91);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "Thêm phòng";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // panelmoving
            // 
            this.panelmoving.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelmoving.Location = new System.Drawing.Point(113, 93);
            this.panelmoving.Name = "panelmoving";
            this.panelmoving.Size = new System.Drawing.Size(181, 7);
            this.panelmoving.TabIndex = 2;
            // 
            // dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1882, 852);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dashboard";
            this.Text = "Form2";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btn_detail;
        private Guna.UI2.WinForms.Guna2Button btn_register;
        private Guna.UI2.WinForms.Guna2Button btn_add;
        private Guna.UI2.WinForms.Guna2Button btn_pay;
        private Guna.UI2.WinForms.Guna2Button btn_staff;
        private Guna.UI2.WinForms.Guna2Panel panelmoving;
    }
}