namespace Kursova
{
    partial class Registration
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
            this.password_name = new System.Windows.Forms.Label();
            this.login_name = new System.Windows.Forms.Label();
            this.reg_button = new System.Windows.Forms.Button();
            this.password_text = new System.Windows.Forms.TextBox();
            this.login_text = new System.Windows.Forms.TextBox();
            this.rep_pas = new System.Windows.Forms.TextBox();
            this.rep_pass = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // password_name
            // 
            this.password_name.AutoSize = true;
            this.password_name.Location = new System.Drawing.Point(26, 67);
            this.password_name.Name = "password_name";
            this.password_name.Size = new System.Drawing.Size(59, 16);
            this.password_name.TabIndex = 10;
            this.password_name.Text = "Пароль:";
            // 
            // login_name
            // 
            this.login_name.AutoSize = true;
            this.login_name.Location = new System.Drawing.Point(26, 23);
            this.login_name.Name = "login_name";
            this.login_name.Size = new System.Drawing.Size(44, 16);
            this.login_name.TabIndex = 9;
            this.login_name.Text = "Логін:";
            // 
            // reg_button
            // 
            this.reg_button.Location = new System.Drawing.Point(405, 160);
            this.reg_button.Name = "reg_button";
            this.reg_button.Size = new System.Drawing.Size(137, 23);
            this.reg_button.TabIndex = 8;
            this.reg_button.Text = "Зареєструватись";
            this.reg_button.UseVisualStyleBackColor = true;
            this.reg_button.Click += new System.EventHandler(this.reg_button_Click);
            // 
            // password_text
            // 
            this.password_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password_text.Location = new System.Drawing.Point(109, 67);
            this.password_text.Name = "password_text";
            this.password_text.Size = new System.Drawing.Size(100, 22);
            this.password_text.TabIndex = 7;
            // 
            // login_text
            // 
            this.login_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.login_text.Location = new System.Drawing.Point(109, 23);
            this.login_text.Name = "login_text";
            this.login_text.Size = new System.Drawing.Size(100, 22);
            this.login_text.TabIndex = 6;
            // 
            // rep_pas
            // 
            this.rep_pas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rep_pas.Location = new System.Drawing.Point(109, 114);
            this.rep_pas.Name = "rep_pas";
            this.rep_pas.Size = new System.Drawing.Size(100, 22);
            this.rep_pas.TabIndex = 11;
            // 
            // rep_pass
            // 
            this.rep_pass.AutoSize = true;
            this.rep_pass.Location = new System.Drawing.Point(26, 104);
            this.rep_pass.Name = "rep_pass";
            this.rep_pass.Size = new System.Drawing.Size(65, 32);
            this.rep_pass.TabIndex = 12;
            this.rep_pass.Text = "Пароль\r\n(повтор):";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 59);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Реєстрація";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.reg_button);
            this.panel2.Location = new System.Drawing.Point(13, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 206);
            this.panel2.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.AliceBlue;
            this.panel3.Controls.Add(this.login_text);
            this.panel3.Controls.Add(this.rep_pas);
            this.panel3.Controls.Add(this.login_name);
            this.panel3.Controls.Add(this.rep_pass);
            this.panel3.Controls.Add(this.password_text);
            this.panel3.Controls.Add(this.password_name);
            this.panel3.Location = new System.Drawing.Point(26, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 165);
            this.panel3.TabIndex = 13;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Registration";
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.Registration_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label password_name;
        private System.Windows.Forms.Label login_name;
        private System.Windows.Forms.Button reg_button;
        private System.Windows.Forms.TextBox password_text;
        private System.Windows.Forms.TextBox login_text;
        private System.Windows.Forms.TextBox rep_pas;
        private System.Windows.Forms.Label rep_pass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}