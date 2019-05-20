namespace STS.RelyingPartyApp
{
    partial class Main
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
            this.rtbClaims = new System.Windows.Forms.RichTextBox();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.chbIsUser = new System.Windows.Forms.CheckBox();
            this.chbIsSuperAdmin = new System.Windows.Forms.CheckBox();
            this.chbIsAdmin = new System.Windows.Forms.CheckBox();
            this.errProv = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCalc = new System.Windows.Forms.Button();
            this.btnLoginViaSaml20 = new System.Windows.Forms.Button();
            this.btnServiceTwo = new System.Windows.Forms.Button();
            this.btnServiceOne = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbClaims
            // 
            this.rtbClaims.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbClaims.Location = new System.Drawing.Point(0, 0);
            this.rtbClaims.Margin = new System.Windows.Forms.Padding(4);
            this.rtbClaims.Name = "rtbClaims";
            this.rtbClaims.ReadOnly = true;
            this.rtbClaims.Size = new System.Drawing.Size(879, 490);
            this.rtbClaims.TabIndex = 0;
            this.rtbClaims.Text = "";
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.label2);
            this.pnlInfo.Controls.Add(this.chbIsUser);
            this.pnlInfo.Controls.Add(this.chbIsSuperAdmin);
            this.pnlInfo.Controls.Add(this.chbIsAdmin);
            this.pnlInfo.Controls.Add(this.rtbClaims);
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(879, 527);
            this.pnlInfo.TabIndex = 1;
            // 
            // chbIsUser
            // 
            this.chbIsUser.AutoSize = true;
            this.chbIsUser.Enabled = false;
            this.chbIsUser.Location = new System.Drawing.Point(109, 506);
            this.chbIsUser.Margin = new System.Windows.Forms.Padding(4);
            this.chbIsUser.Name = "chbIsUser";
            this.chbIsUser.Size = new System.Drawing.Size(70, 21);
            this.chbIsUser.TabIndex = 3;
            this.chbIsUser.Text = "isUser";
            this.chbIsUser.UseVisualStyleBackColor = true;
            // 
            // chbIsSuperAdmin
            // 
            this.chbIsSuperAdmin.AutoSize = true;
            this.chbIsSuperAdmin.Enabled = false;
            this.chbIsSuperAdmin.Location = new System.Drawing.Point(269, 506);
            this.chbIsSuperAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.chbIsSuperAdmin.Name = "chbIsSuperAdmin";
            this.chbIsSuperAdmin.Size = new System.Drawing.Size(117, 21);
            this.chbIsSuperAdmin.TabIndex = 2;
            this.chbIsSuperAdmin.Text = "isSuperAdmin";
            this.chbIsSuperAdmin.UseVisualStyleBackColor = true;
            // 
            // chbIsAdmin
            // 
            this.chbIsAdmin.AutoSize = true;
            this.chbIsAdmin.Enabled = false;
            this.chbIsAdmin.Location = new System.Drawing.Point(190, 506);
            this.chbIsAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.chbIsAdmin.Name = "chbIsAdmin";
            this.chbIsAdmin.Size = new System.Drawing.Size(79, 21);
            this.chbIsAdmin.TabIndex = 1;
            this.chbIsAdmin.Text = "isAdmin";
            this.chbIsAdmin.UseVisualStyleBackColor = true;
            // 
            // errProv
            // 
            this.errProv.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errProv.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtnCalc);
            this.panel1.Controls.Add(this.btnLoginViaSaml20);
            this.panel1.Controls.Add(this.btnServiceTwo);
            this.panel1.Controls.Add(this.btnServiceOne);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.txtLogin);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 534);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 123);
            this.panel1.TabIndex = 2;
            // 
            // BtnCalc
            // 
            this.BtnCalc.Location = new System.Drawing.Point(621, 81);
            this.BtnCalc.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCalc.Name = "BtnCalc";
            this.BtnCalc.Size = new System.Drawing.Size(123, 28);
            this.BtnCalc.TabIndex = 17;
            this.BtnCalc.Text = "Call Calculator";
            this.BtnCalc.UseVisualStyleBackColor = true;
            this.BtnCalc.Click += new System.EventHandler(this.BtnCalc_Click);
            // 
            // btnLoginViaSaml20
            // 
            this.btnLoginViaSaml20.Location = new System.Drawing.Point(170, 81);
            this.btnLoginViaSaml20.Name = "btnLoginViaSaml20";
            this.btnLoginViaSaml20.Size = new System.Drawing.Size(128, 28);
            this.btnLoginViaSaml20.TabIndex = 16;
            this.btnLoginViaSaml20.Text = "Saml2.0 Login";
            this.btnLoginViaSaml20.UseVisualStyleBackColor = true;
            this.btnLoginViaSaml20.Click += new System.EventHandler(this.btnLoginViaSaml20_Click);
            // 
            // btnServiceTwo
            // 
            this.btnServiceTwo.Location = new System.Drawing.Point(474, 81);
            this.btnServiceTwo.Margin = new System.Windows.Forms.Padding(4);
            this.btnServiceTwo.Name = "btnServiceTwo";
            this.btnServiceTwo.Size = new System.Drawing.Size(123, 28);
            this.btnServiceTwo.TabIndex = 15;
            this.btnServiceTwo.Text = "Call Service 2";
            this.btnServiceTwo.UseVisualStyleBackColor = true;
            this.btnServiceTwo.Click += new System.EventHandler(this.btnServiceTwo_Click);
            // 
            // btnServiceOne
            // 
            this.btnServiceOne.Location = new System.Drawing.Point(331, 81);
            this.btnServiceOne.Margin = new System.Windows.Forms.Padding(4);
            this.btnServiceOne.Name = "btnServiceOne";
            this.btnServiceOne.Size = new System.Drawing.Size(123, 28);
            this.btnServiceOne.TabIndex = 14;
            this.btnServiceOne.Text = "Call Service 1";
            this.btnServiceOne.UseVisualStyleBackColor = true;
            this.btnServiceOne.Click += new System.EventHandler(this.btnServiceOne_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(108, 48);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(190, 22);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(20, 50);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 17);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Password";
            // 
            // txtLogin
            // 
            this.txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogin.Location = new System.Drawing.Point(108, 16);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(4);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(190, 22);
            this.txtLogin.TabIndex = 11;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(20, 18);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(79, 17);
            this.lblUserName.TabIndex = 10;
            this.lblUserName.Text = "User Name";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(765, 81);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 28);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(19, 81);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(126, 28);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Saml1.1 Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.Login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Available users: test, aaa, bbb, Admin, SuperAdmin (password same as username)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 507);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Your Roles:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 657);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relying Party App";
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbClaims;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.CheckBox chbIsUser;
        private System.Windows.Forms.CheckBox chbIsSuperAdmin;
        private System.Windows.Forms.CheckBox chbIsAdmin;
        private System.Windows.Forms.ErrorProvider errProv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnServiceOne;
        private System.Windows.Forms.Button btnServiceTwo;
        private System.Windows.Forms.Button btnLoginViaSaml20;
        private System.Windows.Forms.Button BtnCalc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

