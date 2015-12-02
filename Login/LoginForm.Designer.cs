namespace Login
{
    partial class LoginForm
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
            this.lb_statue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_user = new System.Windows.Forms.RichTextBox();
            this.tb_pwd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lb_statue
            // 
            this.lb_statue.AutoSize = true;
            this.lb_statue.BackColor = System.Drawing.Color.Transparent;
            this.lb_statue.Font = new System.Drawing.Font("PMingLiU", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_statue.ForeColor = System.Drawing.Color.Red;
            this.lb_statue.Location = new System.Drawing.Point(64, 249);
            this.lb_statue.Name = "lb_statue";
            this.lb_statue.Size = new System.Drawing.Size(0, 12);
            this.lb_statue.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Image = global::Login.Properties.Resources.btn_close_normal;
            this.label1.Location = new System.Drawing.Point(255, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 23);
            this.label1.TabIndex = 13;
            this.label1.Click += new System.EventHandler(this.btn_cls_Click);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // btn_login
            // 
            this.btn_login.BackgroundImage = global::Login.Properties.Resources.login;
            this.btn_login.FlatAppearance.BorderSize = 0;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.Location = new System.Drawing.Point(65, 278);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(173, 64);
            this.btn_login.TabIndex = 14;
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            this.btn_login.MouseLeave += new System.EventHandler(this.btn_login_MouseLeave);
            this.btn_login.MouseHover += new System.EventHandler(this.btn_login_MouseHover);
            // 
            // label2
            // 
            this.label2.Image = global::Login.Properties.Resources.lbl_username;
            this.label2.Location = new System.Drawing.Point(54, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 30);
            this.label2.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Image = global::Login.Properties.Resources.lbl_password;
            this.label3.Location = new System.Drawing.Point(54, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 30);
            this.label3.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(200)))), ((int)(((byte)(40)))));
            this.label4.Location = new System.Drawing.Point(73, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 22);
            this.label4.TabIndex = 17;
            this.label4.Text = "蓝海创意云、私有云";
            // 
            // tb_user
            // 
            this.tb_user.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tb_user.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_user.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_user.Location = new System.Drawing.Point(87, 112);
            this.tb_user.Multiline = false;
            this.tb_user.Name = "tb_user";
            this.tb_user.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.tb_user.Size = new System.Drawing.Size(171, 30);
            this.tb_user.TabIndex = 18;
            this.tb_user.Text = "adv_007";
            // 
            // tb_pwd
            // 
            this.tb_pwd.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tb_pwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_pwd.Font = new System.Drawing.Font("宋体", 19.5F);
            this.tb_pwd.Location = new System.Drawing.Point(87, 182);
            this.tb_pwd.Name = "tb_pwd";
            this.tb_pwd.PasswordChar = '*';
            this.tb_pwd.Size = new System.Drawing.Size(171, 30);
            this.tb_pwd.TabIndex = 19;
            this.tb_pwd.Text = "123456";
            this.tb_pwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_pwd_KeyPress);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Login.Properties.Resources.authclient_bg_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(300, 391);
            this.Controls.Add(this.tb_pwd);
            this.Controls.Add(this.tb_user);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_statue);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_statue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox tb_user;
        private System.Windows.Forms.TextBox tb_pwd;
    }
}