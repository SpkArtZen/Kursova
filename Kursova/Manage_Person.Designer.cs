namespace Kursova
{
    partial class Manage_Person
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
            this.search_Box = new System.Windows.Forms.TextBox();
            this.radioB_emp = new System.Windows.Forms.RadioButton();
            this.radioB_cit = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 109);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(24, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Редагування даних";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.search_Box);
            this.panel2.Controls.Add(this.radioB_emp);
            this.panel2.Controls.Add(this.radioB_cit);
            this.panel2.Location = new System.Drawing.Point(13, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 57);
            this.panel2.TabIndex = 1;
            // 
            // search_Box
            // 
            this.search_Box.Location = new System.Drawing.Point(315, 16);
            this.search_Box.Name = "search_Box";
            this.search_Box.Size = new System.Drawing.Size(245, 22);
            this.search_Box.TabIndex = 0;
            this.search_Box.TextChanged += new System.EventHandler(this.search_Box_TextChanged);
            // 
            // radioB_emp
            // 
            this.radioB_emp.AutoSize = true;
            this.radioB_emp.Location = new System.Drawing.Point(168, 18);
            this.radioB_emp.Name = "radioB_emp";
            this.radioB_emp.Size = new System.Drawing.Size(123, 20);
            this.radioB_emp.TabIndex = 1;
            this.radioB_emp.TabStop = true;
            this.radioB_emp.Text = "Роботодавець";
            this.radioB_emp.UseVisualStyleBackColor = true;
            // 
            // radioB_cit
            // 
            this.radioB_cit.AutoSize = true;
            this.radioB_cit.Checked = true;
            this.radioB_cit.Location = new System.Drawing.Point(31, 18);
            this.radioB_cit.Name = "radioB_cit";
            this.radioB_cit.Size = new System.Drawing.Size(107, 20);
            this.radioB_cit.TabIndex = 0;
            this.radioB_cit.TabStop = true;
            this.radioB_cit.Text = "Громадянин";
            this.radioB_cit.UseVisualStyleBackColor = true;
            // 
            // Manage_Person
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 641);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Manage_Person";
            this.Text = "Редагування профілів";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Manage_Person_FormClosing);
            this.Load += new System.EventHandler(this.Manage_Person_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioB_emp;
        private System.Windows.Forms.RadioButton radioB_cit;
        private System.Windows.Forms.TextBox search_Box;
    }
}