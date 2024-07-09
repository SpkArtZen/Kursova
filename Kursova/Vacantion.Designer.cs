namespace Kursova
{
    partial class Vacantion
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
            this.Manage_Vacantion = new System.Windows.Forms.RadioButton();
            this.Add_Vacantion = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Delete_citizen = new System.Windows.Forms.Button();
            this.add_citizen = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.allCitizen = new System.Windows.Forms.ComboBox();
            this.allVacantions = new System.Windows.Forms.ComboBox();
            this.buttonDeleteVacantion = new System.Windows.Forms.Button();
            this.comboBoxVacantions = new System.Windows.Forms.ComboBox();
            this.add_vacantion_btn = new System.Windows.Forms.Button();
            this.comboBox_Employer = new System.Windows.Forms.ComboBox();
            this.comboBox_EmploymentType = new System.Windows.Forms.ComboBox();
            this.textBox_Salary = new System.Windows.Forms.TextBox();
            this.textBox_Company = new System.Windows.Forms.TextBox();
            this.textBox_Position = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(26, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вакансії";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.Manage_Vacantion);
            this.panel2.Controls.Add(this.Add_Vacantion);
            this.panel2.Location = new System.Drawing.Point(13, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(654, 48);
            this.panel2.TabIndex = 1;
            // 
            // Manage_Vacantion
            // 
            this.Manage_Vacantion.AutoSize = true;
            this.Manage_Vacantion.Location = new System.Drawing.Point(216, 17);
            this.Manage_Vacantion.Name = "Manage_Vacantion";
            this.Manage_Vacantion.Size = new System.Drawing.Size(175, 20);
            this.Manage_Vacantion.TabIndex = 1;
            this.Manage_Vacantion.Text = "Керування вакансіями";
            this.Manage_Vacantion.UseVisualStyleBackColor = true;
            // 
            // Add_Vacantion
            // 
            this.Add_Vacantion.AutoSize = true;
            this.Add_Vacantion.Checked = true;
            this.Add_Vacantion.Location = new System.Drawing.Point(33, 17);
            this.Add_Vacantion.Name = "Add_Vacantion";
            this.Add_Vacantion.Size = new System.Drawing.Size(154, 20);
            this.Add_Vacantion.TabIndex = 0;
            this.Add_Vacantion.TabStop = true;
            this.Add_Vacantion.Text = "Створення вакансії";
            this.Add_Vacantion.UseVisualStyleBackColor = true;
            this.Add_Vacantion.CheckedChanged += new System.EventHandler(this.Add_Vacantion_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.buttonDeleteVacantion);
            this.panel3.Controls.Add(this.comboBoxVacantions);
            this.panel3.Controls.Add(this.add_vacantion_btn);
            this.panel3.Controls.Add(this.comboBox_Employer);
            this.panel3.Controls.Add(this.comboBox_EmploymentType);
            this.panel3.Controls.Add(this.textBox_Salary);
            this.panel3.Controls.Add(this.textBox_Company);
            this.panel3.Controls.Add(this.textBox_Position);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(13, 174);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(654, 456);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel4.Controls.Add(this.Delete_citizen);
            this.panel4.Controls.Add(this.add_citizen);
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Controls.Add(this.allCitizen);
            this.panel4.Controls.Add(this.allVacantions);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(654, 456);
            this.panel4.TabIndex = 3;
            this.panel4.Visible = false;
            // 
            // Delete_citizen
            // 
            this.Delete_citizen.Location = new System.Drawing.Point(16, 60);
            this.Delete_citizen.Name = "Delete_citizen";
            this.Delete_citizen.Size = new System.Drawing.Size(106, 23);
            this.Delete_citizen.TabIndex = 5;
            this.Delete_citizen.Text = "Видалити";
            this.Delete_citizen.UseVisualStyleBackColor = true;
            this.Delete_citizen.Click += new System.EventHandler(this.Delete_citizen_Click);
            // 
            // add_citizen
            // 
            this.add_citizen.Location = new System.Drawing.Point(16, 29);
            this.add_citizen.Name = "add_citizen";
            this.add_citizen.Size = new System.Drawing.Size(106, 23);
            this.add_citizen.TabIndex = 4;
            this.add_citizen.Text = "Додати";
            this.add_citizen.UseVisualStyleBackColor = true;
            this.add_citizen.Click += new System.EventHandler(this.add_citizen_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(618, 360);
            this.dataGridView1.TabIndex = 3;
            // 
            // allCitizen
            // 
            this.allCitizen.FormattingEnabled = true;
            this.allCitizen.Location = new System.Drawing.Point(141, 59);
            this.allCitizen.Name = "allCitizen";
            this.allCitizen.Size = new System.Drawing.Size(493, 24);
            this.allCitizen.TabIndex = 2;
            // 
            // allVacantions
            // 
            this.allVacantions.FormattingEnabled = true;
            this.allVacantions.Location = new System.Drawing.Point(141, 29);
            this.allVacantions.Name = "allVacantions";
            this.allVacantions.Size = new System.Drawing.Size(493, 24);
            this.allVacantions.TabIndex = 1;
            this.allVacantions.SelectedIndexChanged += new System.EventHandler(this.allVacantions_SelectedIndexChanged);
            // 
            // buttonDeleteVacantion
            // 
            this.buttonDeleteVacantion.Location = new System.Drawing.Point(397, 209);
            this.buttonDeleteVacantion.Name = "buttonDeleteVacantion";
            this.buttonDeleteVacantion.Size = new System.Drawing.Size(130, 23);
            this.buttonDeleteVacantion.TabIndex = 12;
            this.buttonDeleteVacantion.Text = "Видалити";
            this.buttonDeleteVacantion.UseVisualStyleBackColor = true;
            this.buttonDeleteVacantion.Click += new System.EventHandler(this.buttonDeleteVacantion_Click);
            // 
            // comboBoxVacantions
            // 
            this.comboBoxVacantions.FormattingEnabled = true;
            this.comboBoxVacantions.Location = new System.Drawing.Point(310, 247);
            this.comboBoxVacantions.Name = "comboBoxVacantions";
            this.comboBoxVacantions.Size = new System.Drawing.Size(217, 24);
            this.comboBoxVacantions.TabIndex = 11;
            // 
            // add_vacantion_btn
            // 
            this.add_vacantion_btn.Location = new System.Drawing.Point(159, 209);
            this.add_vacantion_btn.Name = "add_vacantion_btn";
            this.add_vacantion_btn.Size = new System.Drawing.Size(130, 23);
            this.add_vacantion_btn.TabIndex = 10;
            this.add_vacantion_btn.Text = "Додати";
            this.add_vacantion_btn.UseVisualStyleBackColor = true;
            this.add_vacantion_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_Employer
            // 
            this.comboBox_Employer.FormattingEnabled = true;
            this.comboBox_Employer.Location = new System.Drawing.Point(36, 247);
            this.comboBox_Employer.Name = "comboBox_Employer";
            this.comboBox_Employer.Size = new System.Drawing.Size(217, 24);
            this.comboBox_Employer.TabIndex = 9;
            // 
            // comboBox_EmploymentType
            // 
            this.comboBox_EmploymentType.FormattingEnabled = true;
            this.comboBox_EmploymentType.Location = new System.Drawing.Point(159, 125);
            this.comboBox_EmploymentType.Name = "comboBox_EmploymentType";
            this.comboBox_EmploymentType.Size = new System.Drawing.Size(149, 24);
            this.comboBox_EmploymentType.TabIndex = 8;
            // 
            // textBox_Salary
            // 
            this.textBox_Salary.Location = new System.Drawing.Point(159, 169);
            this.textBox_Salary.Name = "textBox_Salary";
            this.textBox_Salary.Size = new System.Drawing.Size(149, 22);
            this.textBox_Salary.TabIndex = 7;
            // 
            // textBox_Company
            // 
            this.textBox_Company.Location = new System.Drawing.Point(159, 80);
            this.textBox_Company.Name = "textBox_Company";
            this.textBox_Company.Size = new System.Drawing.Size(278, 22);
            this.textBox_Company.TabIndex = 6;
            // 
            // textBox_Position
            // 
            this.textBox_Position.Location = new System.Drawing.Point(159, 36);
            this.textBox_Position.Name = "textBox_Position";
            this.textBox_Position.Size = new System.Drawing.Size(278, 22);
            this.textBox_Position.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Роботодавець:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Тип зайнятості:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Зарплатня:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Компанія:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Посада:";
            // 
            // Vacantion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 635);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Vacantion";
            this.Text = "Вакансії";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Vacantion_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton Add_Vacantion;
        private System.Windows.Forms.RadioButton Manage_Vacantion;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_Employer;
        private System.Windows.Forms.ComboBox comboBox_EmploymentType;
        private System.Windows.Forms.TextBox textBox_Salary;
        private System.Windows.Forms.TextBox textBox_Company;
        private System.Windows.Forms.TextBox textBox_Position;
        private System.Windows.Forms.Button add_vacantion_btn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox allCitizen;
        private System.Windows.Forms.ComboBox allVacantions;
        private System.Windows.Forms.Button buttonDeleteVacantion;
        private System.Windows.Forms.ComboBox comboBoxVacantions;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Delete_citizen;
        private System.Windows.Forms.Button add_citizen;
    }
}