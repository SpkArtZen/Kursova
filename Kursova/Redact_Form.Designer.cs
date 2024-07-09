namespace Kursova
{
    partial class Redact_Form
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
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comm_red = new System.Windows.Forms.Button();
            this.text_phone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comment_phone_emp = new System.Windows.Forms.TextBox();
            this.remove = new System.Windows.Forms.Button();
            this.phones_emp = new System.Windows.Forms.ComboBox();
            this.add = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.email_red = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.name_emp = new System.Windows.Forms.TextBox();
            this.name_red = new System.Windows.Forms.Button();
            this.email_emp = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 87);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(21, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 38);
            this.label5.TabIndex = 0;
            this.label5.Text = "Редагування";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(530, 383);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AliceBlue;
            this.panel4.Controls.Add(this.comm_red);
            this.panel4.Controls.Add(this.text_phone);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.comment_phone_emp);
            this.panel4.Controls.Add(this.remove);
            this.panel4.Controls.Add(this.phones_emp);
            this.panel4.Controls.Add(this.add);
            this.panel4.Location = new System.Drawing.Point(29, 142);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(469, 233);
            this.panel4.TabIndex = 2;
            // 
            // comm_red
            // 
            this.comm_red.Location = new System.Drawing.Point(283, 109);
            this.comm_red.Name = "comm_red";
            this.comm_red.Size = new System.Drawing.Size(97, 23);
            this.comm_red.TabIndex = 14;
            this.comm_red.Text = "Оновити";
            this.comm_red.UseVisualStyleBackColor = true;
            this.comm_red.Click += new System.EventHandler(this.comm_red_Click);
            // 
            // text_phone
            // 
            this.text_phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_phone.Location = new System.Drawing.Point(111, 21);
            this.text_phone.Name = "text_phone";
            this.text_phone.Size = new System.Drawing.Size(140, 22);
            this.text_phone.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Додати \r\nтелефон:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Видалити";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Коментар:";
            // 
            // comment_phone_emp
            // 
            this.comment_phone_emp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.comment_phone_emp.Location = new System.Drawing.Point(111, 106);
            this.comment_phone_emp.Multiline = true;
            this.comment_phone_emp.Name = "comment_phone_emp";
            this.comment_phone_emp.Size = new System.Drawing.Size(140, 114);
            this.comment_phone_emp.TabIndex = 8;
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(281, 62);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(27, 24);
            this.remove.TabIndex = 11;
            this.remove.Text = "-";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // phones_emp
            // 
            this.phones_emp.FormattingEnabled = true;
            this.phones_emp.Location = new System.Drawing.Point(111, 62);
            this.phones_emp.Name = "phones_emp";
            this.phones_emp.Size = new System.Drawing.Size(140, 24);
            this.phones_emp.TabIndex = 9;
            this.phones_emp.SelectedIndexChanged += new System.EventHandler(this.phones_emp_SelectedIndexChanged);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(281, 20);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(25, 24);
            this.add.TabIndex = 10;
            this.add.Text = "+";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.AliceBlue;
            this.panel3.Controls.Add(this.email_red);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.name_emp);
            this.panel3.Controls.Add(this.name_red);
            this.panel3.Controls.Add(this.email_emp);
            this.panel3.Location = new System.Drawing.Point(29, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(469, 116);
            this.panel3.TabIndex = 2;
            // 
            // email_red
            // 
            this.email_red.Location = new System.Drawing.Point(283, 70);
            this.email_red.Name = "email_red";
            this.email_red.Size = new System.Drawing.Size(97, 23);
            this.email_red.TabIndex = 13;
            this.email_red.Text = "Оновити";
            this.email_red.UseVisualStyleBackColor = true;
            this.email_red.Click += new System.EventHandler(this.email_red_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ім\'я:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пошта:";
            // 
            // name_emp
            // 
            this.name_emp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.name_emp.Location = new System.Drawing.Point(111, 15);
            this.name_emp.Name = "name_emp";
            this.name_emp.Size = new System.Drawing.Size(140, 22);
            this.name_emp.TabIndex = 5;
            // 
            // name_red
            // 
            this.name_red.Location = new System.Drawing.Point(283, 14);
            this.name_red.Name = "name_red";
            this.name_red.Size = new System.Drawing.Size(97, 23);
            this.name_red.TabIndex = 12;
            this.name_red.Text = "Оновити";
            this.name_red.UseVisualStyleBackColor = true;
            this.name_red.Click += new System.EventHandler(this.name_red_Click);
            // 
            // email_emp
            // 
            this.email_emp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email_emp.Location = new System.Drawing.Point(111, 71);
            this.email_emp.Name = "email_emp";
            this.email_emp.Size = new System.Drawing.Size(140, 22);
            this.email_emp.TabIndex = 6;
            // 
            // Redact_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 497);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Redact_Form";
            this.Text = "Редагування";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Redact_Form_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox name_emp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox phones_emp;
        private System.Windows.Forms.TextBox comment_phone_emp;
        private System.Windows.Forms.TextBox email_emp;
        private System.Windows.Forms.Button comm_red;
        private System.Windows.Forms.Button email_red;
        private System.Windows.Forms.Button name_red;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox text_phone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
    }
}