using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static Kursova.Manage_Person;

namespace Kursova
{
    public partial class Manage_Person : Form
    {
        SqlConnection connectionString = new SqlConnection(@"Data Source=ACER;Initial Catalog=Vacantion_kursosva;Integrated Security=True");
        DataBase dataBase = new DataBase();
        public List<Employer> employers = new List<Employer>();
        public List<Citizen> citizens = new List<Citizen>();
        private TabControl tabControl; // Додано поле класу

        public Manage_Person()
        {
            InitializeComponent();
            tabControl = new TabControl(); // Ініціалізація TabControl
            tabControl.Width = 600;
            tabControl.Height = 600;
            tabControl.Left = (this.Width - tabControl.Width) / 2;
            tabControl.Top = (int)(this.Height * 0.30);
            this.Controls.Add(tabControl);
        }

        private void ClearTabControl(TabControl tabControl)
        {
            tabControl.TabPages.Clear();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            if (radioB_emp.Checked)
            {
                string quer = search_Box.Text.Trim();
                employers.Clear();
                employers = GetEmployersData(quer);

                ClearTabControl(tabControl); // Очищення TabControl перед відображенням нового списку
                DisplayEmployers(employers);
            }
            else if (radioB_cit.Checked)
            {
                string quer = search_Box.Text.Trim();
                citizens.Clear();
                citizens = GetCitizenData(quer);
                ClearTabControl(tabControl);
                DisplayCitizens(citizens);
            }          
        }

        private List<Employer> GetEmployersData(string quer)
        {
            List<Employer> employers = new List<Employer>();

            string query = $"SELECT E.ID_Employer, E.Name_employer, E.email " +
                           $"FROM Employer E " +
                           $"WHERE E.email = '{quer}' OR E.Name_employer = '{quer}'";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string email_emp = reader.GetString(2);
                    Employer emp = new Employer(id, name, email_emp);
                    employers.Add(emp);
                }
                reader.Close();
            }

            return employers;
        }
        private List<Citizen> GetCitizenData(string quer)
        {
            List<Citizen> citizens = new List<Citizen>();

            string query = $"SELECT ID_Citizen, Name, Surname, Birthdate, Adress, Invalidity, Criminal_record " +
                           $"FROM Citizen " +
                           $"WHERE Name = '{quer}' OR Surname = '{quer}' OR Adress = '{quer}'";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string surname = reader.GetString(2);
                    DateTime birthdate = reader.GetDateTime(3);
                    string adress = reader.GetString(4);
                    bool inv = reader.GetBoolean(5);
                    bool crime = reader.GetBoolean(6);
                    Citizen cit = new Citizen(id, name, surname, birthdate, adress, inv, crime);
                    citizens.Add(cit);
                }
                reader.Close();
            }

            return citizens;
        }
        public class Employer
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string email { get; set; }
            public string Comment { get; set; }

            public Employer(int id, string name, string em)
            {
                this.ID = id;
                this.Name = name;
                this.email = em;
            }
        }
        public class Citizen
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime Date { get; set; }
            public string Adress { get; set; }
            public bool Invalidity {  get; set; }
            public bool Crime { get; set; }
            public Citizen(int iD, string name, string surname, DateTime date, string adress, bool invalidity, bool crime)
            {
                ID = iD;
                Name = name;
                Surname = surname;
                Date = date; 
                Adress = adress;
                Invalidity = invalidity;
                Crime = crime;
            }
        }

        private void DisplayEmployers(List<Employer> employers)
        {
            int tabPageIndex = 0;
            int rowCount = 0;
            int colCount = 0;
            int labelLeft = 10;
            int labelWidth = 200;
            int labelHeight = 20;
            int verticalGap = 2;
            int panelWidth = 275;
            int panelHeight = 125;

            TabPage tabPage = new TabPage("Сторінка 1");
            tabControl.TabPages.Add(tabPage);

            foreach (var employer in employers)
            {
                if (rowCount == 4)
                {
                    tabPageIndex++;
                    tabPage = new TabPage("Сторінка " + (tabPageIndex + 1));
                    tabControl.TabPages.Add(tabPage);
                    rowCount = 0;
                    colCount = 0;
                }

                Panel panel = new Panel();
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Top = 10 + (panelHeight + verticalGap) * rowCount;
                panel.Left = 10 + ((panelWidth + labelLeft * 2 + 5) * colCount);
                panel.Width = panelWidth;
                panel.Height = panelHeight;

                Label nameLabel = new Label();
                nameLabel.Text = "Ім'я: " + employer.Name;
                nameLabel.Left = labelLeft;
                nameLabel.Top = 10;
                nameLabel.Width = labelWidth;
                nameLabel.Height = labelHeight;

                Label idLabel = new Label();
                idLabel.Text = "ID: " + employer.ID;
                idLabel.Left = labelLeft;
                idLabel.Top = nameLabel.Bottom + verticalGap;
                idLabel.Width = labelWidth;
                idLabel.Height = labelHeight;

                Label emailLabel = new Label();
                emailLabel.Text = "Ел.пошта: " + employer.email;
                emailLabel.Left = labelLeft;
                emailLabel.Top = idLabel.Bottom + verticalGap;
                emailLabel.Width = labelWidth;
                emailLabel.Height = labelHeight;

                Button manageButton = new Button();
                manageButton.Text = "Редагувати";
                manageButton.Top = nameLabel.Top - 13;
                manageButton.Left = nameLabel.Right - 5;
                manageButton.Width = 75;
                manageButton.Height = 35;
                manageButton.Click += (sender, e) => { EditEmployer(employer); };

                panel.Controls.Add(nameLabel);
                panel.Controls.Add(idLabel);
                panel.Controls.Add(emailLabel);
                panel.Controls.Add(manageButton);
                manageButton.BringToFront();
                tabPage.Controls.Add(panel);

                rowCount++;
                if (rowCount > 1)
                {
                    rowCount = 0;
                    colCount++;
                }
            }
        }
        private void DisplayCitizens(List<Citizen> citizens)
        {
            int tabPageIndex = 0;
            int rowCount = 0;
            int colCount = 0;
            int labelLeft = 10;
            int labelWidth = 200;
            int labelHeight = 20;
            int verticalGap = 2;
            int panelWidth = 275;
            int panelHeight = 125;

            TabPage tabPage = new TabPage("Сторінка 1");
            tabControl.TabPages.Add(tabPage);

            foreach (var citizen in citizens)
            {
                if (rowCount == 4)
                {
                    tabPageIndex++;
                    tabPage = new TabPage("Сторінка " + (tabPageIndex + 1));
                    tabControl.TabPages.Add(tabPage);
                    rowCount = 0;
                    colCount = 0;
                }

                Panel panel = new Panel();
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Top = 10 + (panelHeight + verticalGap) * rowCount;
                panel.Left = 10 + ((panelWidth + labelLeft * 2 + 5) * colCount);
                panel.Width = panelWidth;
                panel.Height = panelHeight;

                Label nameLabel = new Label();
                nameLabel.Text = "Ім'я: " + citizen.Name;
                nameLabel.Left = labelLeft;
                nameLabel.Top = 10;
                nameLabel.Width = labelWidth;
                nameLabel.Height = labelHeight;

                Label surLabel = new Label();
                surLabel.Text = "Прізвище: " + citizen.Surname;
                surLabel.Left = labelLeft;
                surLabel.Top = nameLabel.Bottom + verticalGap;
                surLabel.Width = labelWidth;
                surLabel.Height = labelHeight;

                Label datelLabel = new Label();
                datelLabel.Text = "Дата народження: " + citizen.Date;
                datelLabel.Left = labelLeft;
                datelLabel.Top = surLabel.Bottom + verticalGap;
                datelLabel.Width = labelWidth;
                datelLabel.Height = labelHeight;

                Label adresslLabel = new Label();
                adresslLabel.Text = "Адреса: " + citizen.Adress;
                adresslLabel.Left = labelLeft;
                adresslLabel.Top = datelLabel.Bottom + verticalGap;
                adresslLabel.Width = labelWidth;
                adresslLabel.Height = labelHeight;

                Label idlLabel = new Label();
                idlLabel.Text = "ID: " + citizen.ID;
                idlLabel.Left = labelLeft;
                idlLabel.Top = datelLabel.Bottom + verticalGap;
                idlLabel.Width = labelWidth;
                idlLabel.Height = labelHeight;

                Button manageButton = new Button();
                manageButton.Text = "Редагувати";
                manageButton.Top = nameLabel.Top - 13;
                manageButton.Left = nameLabel.Right - 5;
                manageButton.Width = 75;
                manageButton.Height = 35;
                manageButton.Click += (sender, e) => { EditCitizen(citizen); };

                panel.Controls.Add(nameLabel);
                panel.Controls.Add(surLabel);
                panel.Controls.Add(datelLabel);
                panel.Controls.Add(adresslLabel);
                panel.Controls.Add(manageButton);
                manageButton.BringToFront();
                tabPage.Controls.Add(panel);

                rowCount++;
                if (rowCount > 1)
                {
                    rowCount = 0;
                    colCount++;
                }
            }
        }

        private void EditEmployer(Employer employer)
        {
            Redact_Form red_f = new Redact_Form(employer);
            this.Enabled = false;
            red_f.Show();
        }
        private void EditCitizen(Citizen citizen)
        {
            Redact_Form_cit red_f_cit = new Redact_Form_cit(citizen);
            this.Enabled = false;
            red_f_cit.Show();
        }

        private void radioB_emp_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
