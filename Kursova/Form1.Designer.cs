namespace Kursova
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
            this.Add_person = new System.Windows.Forms.Button();
            this.Vacantion = new System.Windows.Forms.Button();
            this.Manage_person = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.To_declare = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Add_person
            // 
            this.Add_person.Location = new System.Drawing.Point(37, 16);
            this.Add_person.Name = "Add_person";
            this.Add_person.Size = new System.Drawing.Size(159, 104);
            this.Add_person.TabIndex = 0;
            this.Add_person.Text = "Додати особу";
            this.Add_person.UseVisualStyleBackColor = true;
            this.Add_person.Click += new System.EventHandler(this.Add_person_Click);
            // 
            // Vacantion
            // 
            this.Vacantion.Location = new System.Drawing.Point(38, 16);
            this.Vacantion.Name = "Vacantion";
            this.Vacantion.Size = new System.Drawing.Size(159, 104);
            this.Vacantion.TabIndex = 1;
            this.Vacantion.Text = "Вакансії";
            this.Vacantion.UseVisualStyleBackColor = true;
            this.Vacantion.Click += new System.EventHandler(this.Vacantion_Click);
            // 
            // Manage_person
            // 
            this.Manage_person.Location = new System.Drawing.Point(214, 16);
            this.Manage_person.Name = "Manage_person";
            this.Manage_person.Size = new System.Drawing.Size(159, 104);
            this.Manage_person.TabIndex = 2;
            this.Manage_person.Text = "Редагувати профіль";
            this.Manage_person.UseVisualStyleBackColor = true;
            this.Manage_person.Click += new System.EventHandler(this.Manage_person_Click);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(38, 13);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(335, 75);
            this.Search.TabIndex = 4;
            this.Search.Text = "Пошук ";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // To_declare
            // 
            this.To_declare.Location = new System.Drawing.Point(215, 16);
            this.To_declare.Name = "To_declare";
            this.To_declare.Size = new System.Drawing.Size(158, 104);
            this.To_declare.TabIndex = 5;
            this.To_declare.Text = "Звіт";
            this.To_declare.UseVisualStyleBackColor = true;
            this.To_declare.Click += new System.EventHandler(this.To_declare_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.Manage_person);
            this.panel1.Controls.Add(this.Add_person);
            this.panel1.Location = new System.Drawing.Point(38, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 134);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.Vacantion);
            this.panel2.Controls.Add(this.To_declare);
            this.panel2.Location = new System.Drawing.Point(38, 176);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 132);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.Controls.Add(this.Search);
            this.panel3.Location = new System.Drawing.Point(38, 314);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(426, 100);
            this.panel3.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(511, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Меню";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Add_person;
        private System.Windows.Forms.Button Vacantion;
        private System.Windows.Forms.Button Manage_person;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button To_declare;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

