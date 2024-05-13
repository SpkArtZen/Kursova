namespace Kursova
{
    partial class Add_Person
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.check_employer = new System.Windows.Forms.RadioButton();
            this.check_citizen = new System.Windows.Forms.RadioButton();
            this.Employer_panel = new System.Windows.Forms.Panel();
            this.add_Employer = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.remove_phone = new System.Windows.Forms.Button();
            this.comment_box = new System.Windows.Forms.TextBox();
            this.addphone = new System.Windows.Forms.Button();
            this.phone_list_emp = new System.Windows.Forms.RichTextBox();
            this.phone_emp_text = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.emp_email = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Employer_name = new System.Windows.Forms.Label();
            this.name_employer_text_box = new System.Windows.Forms.TextBox();
            this.Citizen_panel = new System.Windows.Forms.Panel();
            this.Add_Citizen = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.Remove_cit_phone = new System.Windows.Forms.Button();
            this.Citizen_comment = new System.Windows.Forms.TextBox();
            this.Add_cit_phone = new System.Windows.Forms.Button();
            this.Citizen_richBox = new System.Windows.Forms.RichTextBox();
            this.Citizen_phone_box = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.Crimely = new System.Windows.Forms.CheckBox();
            this.Invalidity = new System.Windows.Forms.CheckBox();
            this.Adress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.day = new System.Windows.Forms.ComboBox();
            this.month = new System.Windows.Forms.ComboBox();
            this.year = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.surname_Citizen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.name_Citizen = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Employer_panel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.Citizen_panel.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 120);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(45, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(766, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Додавання особи";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.check_employer);
            this.panel2.Controls.Add(this.check_citizen);
            this.panel2.Location = new System.Drawing.Point(12, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(852, 60);
            this.panel2.TabIndex = 1;
            // 
            // check_employer
            // 
            this.check_employer.AutoSize = true;
            this.check_employer.Location = new System.Drawing.Point(180, 20);
            this.check_employer.Name = "check_employer";
            this.check_employer.Size = new System.Drawing.Size(123, 20);
            this.check_employer.TabIndex = 1;
            this.check_employer.TabStop = true;
            this.check_employer.Text = "Роботодавець";
            this.check_employer.UseVisualStyleBackColor = true;
            this.check_employer.CheckedChanged += new System.EventHandler(this.check_employer_CheckedChanged);
            // 
            // check_citizen
            // 
            this.check_citizen.AutoSize = true;
            this.check_citizen.Location = new System.Drawing.Point(52, 20);
            this.check_citizen.Name = "check_citizen";
            this.check_citizen.Size = new System.Drawing.Size(107, 20);
            this.check_citizen.TabIndex = 0;
            this.check_citizen.TabStop = true;
            this.check_citizen.Text = "Громадянин";
            this.check_citizen.UseVisualStyleBackColor = true;
            // 
            // Employer_panel
            // 
            this.Employer_panel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Employer_panel.Controls.Add(this.Citizen_panel);
            this.Employer_panel.Controls.Add(this.add_Employer);
            this.Employer_panel.Controls.Add(this.panel6);
            this.Employer_panel.Controls.Add(this.panel5);
            this.Employer_panel.Controls.Add(this.panel4);
            this.Employer_panel.Location = new System.Drawing.Point(11, 205);
            this.Employer_panel.Name = "Employer_panel";
            this.Employer_panel.Size = new System.Drawing.Size(852, 412);
            this.Employer_panel.TabIndex = 2;
            this.Employer_panel.Visible = false;
            // 
            // add_Employer
            // 
            this.add_Employer.Location = new System.Drawing.Point(21, 347);
            this.add_Employer.Name = "add_Employer";
            this.add_Employer.Size = new System.Drawing.Size(189, 35);
            this.add_Employer.TabIndex = 3;
            this.add_Employer.Text = "Додати роботодавця";
            this.add_Employer.UseVisualStyleBackColor = true;
            this.add_Employer.Click += new System.EventHandler(this.add_Employer_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.AliceBlue;
            this.panel6.Controls.Add(this.remove_phone);
            this.panel6.Controls.Add(this.comment_box);
            this.panel6.Controls.Add(this.addphone);
            this.panel6.Controls.Add(this.phone_list_emp);
            this.panel6.Controls.Add(this.phone_emp_text);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(18, 154);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(806, 187);
            this.panel6.TabIndex = 2;
            // 
            // remove_phone
            // 
            this.remove_phone.Location = new System.Drawing.Point(478, 119);
            this.remove_phone.Name = "remove_phone";
            this.remove_phone.Size = new System.Drawing.Size(42, 40);
            this.remove_phone.TabIndex = 5;
            this.remove_phone.Text = "-";
            this.remove_phone.UseVisualStyleBackColor = true;
            this.remove_phone.Click += new System.EventHandler(this.remove_phone_Click);
            // 
            // comment_box
            // 
            this.comment_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.comment_box.Location = new System.Drawing.Point(430, 22);
            this.comment_box.Multiline = true;
            this.comment_box.Name = "comment_box";
            this.comment_box.Size = new System.Drawing.Size(204, 93);
            this.comment_box.TabIndex = 4;
            // 
            // addphone
            // 
            this.addphone.Location = new System.Drawing.Point(430, 119);
            this.addphone.Name = "addphone";
            this.addphone.Size = new System.Drawing.Size(42, 40);
            this.addphone.TabIndex = 3;
            this.addphone.Text = "+";
            this.addphone.UseVisualStyleBackColor = true;
            this.addphone.Click += new System.EventHandler(this.addphone_Click);
            // 
            // phone_list_emp
            // 
            this.phone_list_emp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phone_list_emp.Location = new System.Drawing.Point(23, 63);
            this.phone_list_emp.Name = "phone_list_emp";
            this.phone_list_emp.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.phone_list_emp.Size = new System.Drawing.Size(378, 96);
            this.phone_list_emp.TabIndex = 2;
            this.phone_list_emp.Text = "";
            // 
            // phone_emp_text
            // 
            this.phone_emp_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phone_emp_text.Location = new System.Drawing.Point(176, 24);
            this.phone_emp_text.Name = "phone_emp_text";
            this.phone_emp_text.Size = new System.Drawing.Size(225, 22);
            this.phone_emp_text.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Номер телефону:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.AliceBlue;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.emp_email);
            this.panel5.Location = new System.Drawing.Point(18, 87);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(806, 64);
            this.panel5.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.AliceBlue;
            this.label2.Location = new System.Drawing.Point(17, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пошта роботодавця:";
            // 
            // emp_email
            // 
            this.emp_email.BackColor = System.Drawing.SystemColors.HighlightText;
            this.emp_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emp_email.Location = new System.Drawing.Point(176, 18);
            this.emp_email.Name = "emp_email";
            this.emp_email.Size = new System.Drawing.Size(197, 22);
            this.emp_email.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AliceBlue;
            this.panel4.Controls.Add(this.Employer_name);
            this.panel4.Controls.Add(this.name_employer_text_box);
            this.panel4.Location = new System.Drawing.Point(18, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(806, 64);
            this.panel4.TabIndex = 0;
            // 
            // Employer_name
            // 
            this.Employer_name.AutoSize = true;
            this.Employer_name.BackColor = System.Drawing.Color.AliceBlue;
            this.Employer_name.Location = new System.Drawing.Point(17, 20);
            this.Employer_name.Name = "Employer_name";
            this.Employer_name.Size = new System.Drawing.Size(121, 16);
            this.Employer_name.TabIndex = 1;
            this.Employer_name.Text = "Ім\'я роботодавця:";
            // 
            // name_employer_text_box
            // 
            this.name_employer_text_box.BackColor = System.Drawing.SystemColors.HighlightText;
            this.name_employer_text_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.name_employer_text_box.Location = new System.Drawing.Point(162, 18);
            this.name_employer_text_box.Name = "name_employer_text_box";
            this.name_employer_text_box.Size = new System.Drawing.Size(197, 22);
            this.name_employer_text_box.TabIndex = 0;
            // 
            // Citizen_panel
            // 
            this.Citizen_panel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Citizen_panel.Controls.Add(this.Add_Citizen);
            this.Citizen_panel.Controls.Add(this.panel8);
            this.Citizen_panel.Controls.Add(this.panel7);
            this.Citizen_panel.Controls.Add(this.panel3);
            this.Citizen_panel.Location = new System.Drawing.Point(0, 0);
            this.Citizen_panel.Name = "Citizen_panel";
            this.Citizen_panel.Size = new System.Drawing.Size(852, 412);
            this.Citizen_panel.TabIndex = 3;
            // 
            // Add_Citizen
            // 
            this.Add_Citizen.Location = new System.Drawing.Point(18, 348);
            this.Add_Citizen.Name = "Add_Citizen";
            this.Add_Citizen.Size = new System.Drawing.Size(187, 35);
            this.Add_Citizen.TabIndex = 7;
            this.Add_Citizen.Text = "Додати громадянина";
            this.Add_Citizen.UseVisualStyleBackColor = true;
            this.Add_Citizen.Click += new System.EventHandler(this.Add_Citizen_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.AliceBlue;
            this.panel8.Controls.Add(this.Remove_cit_phone);
            this.panel8.Controls.Add(this.Citizen_comment);
            this.panel8.Controls.Add(this.Add_cit_phone);
            this.panel8.Controls.Add(this.Citizen_richBox);
            this.panel8.Controls.Add(this.Citizen_phone_box);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Location = new System.Drawing.Point(18, 154);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(806, 187);
            this.panel8.TabIndex = 6;
            // 
            // Remove_cit_phone
            // 
            this.Remove_cit_phone.Location = new System.Drawing.Point(478, 119);
            this.Remove_cit_phone.Name = "Remove_cit_phone";
            this.Remove_cit_phone.Size = new System.Drawing.Size(42, 40);
            this.Remove_cit_phone.TabIndex = 5;
            this.Remove_cit_phone.Text = "-";
            this.Remove_cit_phone.UseVisualStyleBackColor = true;
            this.Remove_cit_phone.Click += new System.EventHandler(this.Remove_cit_phone_Click);
            // 
            // Citizen_comment
            // 
            this.Citizen_comment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Citizen_comment.Location = new System.Drawing.Point(430, 22);
            this.Citizen_comment.Multiline = true;
            this.Citizen_comment.Name = "Citizen_comment";
            this.Citizen_comment.Size = new System.Drawing.Size(204, 93);
            this.Citizen_comment.TabIndex = 4;
            // 
            // Add_cit_phone
            // 
            this.Add_cit_phone.Location = new System.Drawing.Point(430, 119);
            this.Add_cit_phone.Name = "Add_cit_phone";
            this.Add_cit_phone.Size = new System.Drawing.Size(42, 40);
            this.Add_cit_phone.TabIndex = 3;
            this.Add_cit_phone.Text = "+";
            this.Add_cit_phone.UseVisualStyleBackColor = true;
            this.Add_cit_phone.Click += new System.EventHandler(this.Add_cit_phone_Click);
            // 
            // Citizen_richBox
            // 
            this.Citizen_richBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Citizen_richBox.Location = new System.Drawing.Point(23, 63);
            this.Citizen_richBox.Name = "Citizen_richBox";
            this.Citizen_richBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Citizen_richBox.Size = new System.Drawing.Size(378, 96);
            this.Citizen_richBox.TabIndex = 2;
            this.Citizen_richBox.Text = "";
            this.Citizen_richBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            this.Citizen_richBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseDown);
            // 
            // Citizen_phone_box
            // 
            this.Citizen_phone_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Citizen_phone_box.Location = new System.Drawing.Point(176, 24);
            this.Citizen_phone_box.Name = "Citizen_phone_box";
            this.Citizen_phone_box.Size = new System.Drawing.Size(225, 22);
            this.Citizen_phone_box.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Номер телефону:";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.AliceBlue;
            this.panel7.Controls.Add(this.Crimely);
            this.panel7.Controls.Add(this.Invalidity);
            this.panel7.Controls.Add(this.Adress);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(18, 87);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(806, 64);
            this.panel7.TabIndex = 3;
            // 
            // Crimely
            // 
            this.Crimely.AutoSize = true;
            this.Crimely.Location = new System.Drawing.Point(478, 20);
            this.Crimely.Name = "Crimely";
            this.Crimely.Size = new System.Drawing.Size(89, 20);
            this.Crimely.TabIndex = 3;
            this.Crimely.Text = "Кримінал";
            this.Crimely.UseVisualStyleBackColor = true;
            // 
            // Invalidity
            // 
            this.Invalidity.AutoSize = true;
            this.Invalidity.Location = new System.Drawing.Point(346, 19);
            this.Invalidity.Name = "Invalidity";
            this.Invalidity.Size = new System.Drawing.Size(107, 20);
            this.Invalidity.TabIndex = 2;
            this.Invalidity.Text = "Інвалідність";
            this.Invalidity.UseVisualStyleBackColor = true;
            // 
            // Adress
            // 
            this.Adress.Location = new System.Drawing.Point(155, 17);
            this.Adress.Name = "Adress";
            this.Adress.Size = new System.Drawing.Size(147, 22);
            this.Adress.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Місто проживання:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.AliceBlue;
            this.panel3.Controls.Add(this.day);
            this.panel3.Controls.Add(this.month);
            this.panel3.Controls.Add(this.year);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.surname_Citizen);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.name_Citizen);
            this.panel3.Location = new System.Drawing.Point(18, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(806, 64);
            this.panel3.TabIndex = 2;
            // 
            // day
            // 
            this.day.FormattingEnabled = true;
            this.day.Location = new System.Drawing.Point(690, 17);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(44, 24);
            this.day.TabIndex = 7;
            // 
            // month
            // 
            this.month.FormattingEnabled = true;
            this.month.Location = new System.Drawing.Point(640, 17);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(44, 24);
            this.month.TabIndex = 6;
            // 
            // year
            // 
            this.year.FormattingEnabled = true;
            this.year.Location = new System.Drawing.Point(572, 17);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(62, 24);
            this.year.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(427, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Дата народження:";
            // 
            // surname_Citizen
            // 
            this.surname_Citizen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.surname_Citizen.Location = new System.Drawing.Point(280, 18);
            this.surname_Citizen.Name = "surname_Citizen";
            this.surname_Citizen.Size = new System.Drawing.Size(121, 22);
            this.surname_Citizen.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Фамілія:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.AliceBlue;
            this.label5.Location = new System.Drawing.Point(17, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ім\'я:";
            // 
            // name_Citizen
            // 
            this.name_Citizen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.name_Citizen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.name_Citizen.Location = new System.Drawing.Point(68, 19);
            this.name_Citizen.Name = "name_Citizen";
            this.name_Citizen.Size = new System.Drawing.Size(121, 22);
            this.name_Citizen.TabIndex = 0;
            // 
            // Add_Person
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 780);
            this.Controls.Add(this.Employer_panel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Add_Person";
            this.Text = "Add_Person";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Add_Person_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.Employer_panel.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.Citizen_panel.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton check_employer;
        private System.Windows.Forms.RadioButton check_citizen;
        private System.Windows.Forms.Panel Employer_panel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Employer_name;
        private System.Windows.Forms.TextBox name_employer_text_box;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox emp_email;
        private System.Windows.Forms.Button add_Employer;
        private System.Windows.Forms.Button addphone;
        private System.Windows.Forms.RichTextBox phone_list_emp;
        private System.Windows.Forms.TextBox phone_emp_text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox comment_box;
        private System.Windows.Forms.Button remove_phone;
        private System.Windows.Forms.Panel Citizen_panel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox name_Citizen;
        private System.Windows.Forms.TextBox surname_Citizen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox day;
        private System.Windows.Forms.ComboBox month;
        private System.Windows.Forms.ComboBox year;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox Adress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button Remove_cit_phone;
        private System.Windows.Forms.TextBox Citizen_comment;
        private System.Windows.Forms.Button Add_cit_phone;
        private System.Windows.Forms.RichTextBox Citizen_richBox;
        private System.Windows.Forms.TextBox Citizen_phone_box;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox Crimely;
        private System.Windows.Forms.CheckBox Invalidity;
        private System.Windows.Forms.Button Add_Citizen;
    }
}