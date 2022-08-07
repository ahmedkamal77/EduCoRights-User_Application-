
namespace LoginPage
{
    partial class Sign_In
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sign_In));
            this.textuser = new System.Windows.Forms.TextBox();
            this.textpassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.PictureBox();
            this.btnMinimized = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Signuplink = new System.Windows.Forms.LinkLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txtExistedUser = new System.Windows.Forms.TextBox();
            this.txtCorrectPassword = new System.Windows.Forms.TextBox();
            this.btnRem = new System.Windows.Forms.CheckBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnexit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimized)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // textuser
            // 
            this.textuser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.textuser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textuser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textuser.ForeColor = System.Drawing.Color.LightGray;
            this.textuser.Location = new System.Drawing.Point(345, 160);
            this.textuser.Name = "textuser";
            this.textuser.Size = new System.Drawing.Size(410, 20);
            this.textuser.TabIndex = 1;
            this.textuser.Text = "Username";
            this.textuser.Enter += new System.EventHandler(this.textuser_Enter);
            this.textuser.Leave += new System.EventHandler(this.textuser_Leave);
            // 
            // textpassword
            // 
            this.textpassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.textpassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textpassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textpassword.ForeColor = System.Drawing.Color.LightGray;
            this.textpassword.Location = new System.Drawing.Point(345, 245);
            this.textpassword.Name = "textpassword";
            this.textpassword.Size = new System.Drawing.Size(410, 20);
            this.textpassword.TabIndex = 2;
            this.textpassword.Text = "Password";
            this.textpassword.Enter += new System.EventHandler(this.textpassword_Enter);
            this.textpassword.Leave += new System.EventHandler(this.textpassword_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(477, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 33);
            this.label1.TabIndex = 3;
            this.label1.Text = "LOGIN";
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.DarkGray;
            this.btnlogin.FlatAppearance.BorderSize = 0;
            this.btnlogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnlogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnlogin.Location = new System.Drawing.Point(345, 377);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(410, 41);
            this.btnlogin.TabIndex = 3;
            this.btnlogin.Text = "Log in";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btnexit
            // 
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.Location = new System.Drawing.Point(816, 5);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(30, 32);
            this.btnexit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnexit.TabIndex = 6;
            this.btnexit.TabStop = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnMinimized
            // 
            this.btnMinimized.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimized.Image")));
            this.btnMinimized.Location = new System.Drawing.Point(780, 5);
            this.btnMinimized.Name = "btnMinimized";
            this.btnMinimized.Size = new System.Drawing.Size(30, 32);
            this.btnMinimized.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimized.TabIndex = 7;
            this.btnMinimized.TabStop = false;
            this.btnMinimized.Click += new System.EventHandler(this.btnMinimized_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Location = new System.Drawing.Point(342, 182);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(410, 1);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Location = new System.Drawing.Point(342, 266);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(410, 1);
            this.panel3.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(317, 161);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(316, 244);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(359, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Don\'t have an account ?";
            // 
            // Signuplink
            // 
            this.Signuplink.ActiveLinkColor = System.Drawing.Color.LightGray;
            this.Signuplink.AutoSize = true;
            this.Signuplink.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signuplink.ForeColor = System.Drawing.Color.LightGray;
            this.Signuplink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.Signuplink.Location = new System.Drawing.Point(564, 434);
            this.Signuplink.Name = "Signuplink";
            this.Signuplink.Size = new System.Drawing.Size(68, 21);
            this.Signuplink.TabIndex = 0;
            this.Signuplink.TabStop = true;
            this.Signuplink.Text = "Sign Up";
            this.Signuplink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Signuplink_LinkClicked);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(719, 233);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseEnter += new System.EventHandler(this.pictureBox4_MouseEnter);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            // 
            // txtExistedUser
            // 
            this.txtExistedUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.txtExistedUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExistedUser.ForeColor = System.Drawing.Color.Red;
            this.txtExistedUser.Location = new System.Drawing.Point(560, 189);
            this.txtExistedUser.Name = "txtExistedUser";
            this.txtExistedUser.Size = new System.Drawing.Size(285, 13);
            this.txtExistedUser.TabIndex = 20;
            // 
            // txtCorrectPassword
            // 
            this.txtCorrectPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.txtCorrectPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorrectPassword.ForeColor = System.Drawing.Color.Red;
            this.txtCorrectPassword.Location = new System.Drawing.Point(560, 269);
            this.txtCorrectPassword.Name = "txtCorrectPassword";
            this.txtCorrectPassword.Size = new System.Drawing.Size(285, 13);
            this.txtCorrectPassword.TabIndex = 21;
            // 
            // btnRem
            // 
            this.btnRem.AutoSize = true;
            this.btnRem.BackColor = System.Drawing.Color.Transparent;
            this.btnRem.ForeColor = System.Drawing.Color.DarkGray;
            this.btnRem.Location = new System.Drawing.Point(342, 291);
            this.btnRem.Name = "btnRem";
            this.btnRem.Size = new System.Drawing.Size(113, 21);
            this.btnRem.TabIndex = 22;
            this.btnRem.Text = "Remember me";
            this.btnRem.UseVisualStyleBackColor = false;
            this.btnRem.CheckedChanged += new System.EventHandler(this.btnRem_CheckedChanged);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(40, 60);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(220, 220);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 23;
            this.pictureBox6.TabStop = false;
            // 
            // Sign_In
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(850, 650);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.btnRem);
            this.Controls.Add(this.txtCorrectPassword);
            this.Controls.Add(this.txtExistedUser);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.Signuplink);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnMinimized);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textpassword);
            this.Controls.Add(this.textuser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Sign_In";
            this.Opacity = 0.9D;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RadForm1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RadForm1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnexit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimized)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textuser;
        private System.Windows.Forms.TextBox textpassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.PictureBox btnexit;
        private System.Windows.Forms.PictureBox btnMinimized;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel Signuplink;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txtExistedUser;
        private System.Windows.Forms.TextBox txtCorrectPassword;
        private System.Windows.Forms.CheckBox btnRem;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}