using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static Kursova.Manage_Person;
using Button = System.Windows.Forms.Button;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;

namespace Kursova
{
    public partial class Search : Form
    {
        SqlConnection connectionString = new SqlConnection(@"Data Source=ACER;
            Initial Catalog=Vacantion_kursosva;Integrated Security=True");


        List<Vacantion> vacantions = new List<Vacantion>();
        List<Citizen> citizens = new List<Citizen>();
        DataBase dataBase = new DataBase();


        public Search()
        {
            InitializeComponent();

        }
        private List<Citizen> GetCitizenData(string quer)
        {
            string query = $"SELECT c.ID_Citizen, c.Name, c.Surname, c.Birthdate, c.Adress, c.Invalidity, c.Criminal_record, " +
               $"p.Phone, e.Education_type, s.Skill " +
               $"FROM Citizen c " +
               $"LEFT JOIN Citizen_Phone p ON c.ID_Citizen = p.ID_Citizen " +
               $"LEFT JOIN Education e ON c.ID_Citizen = e.ID_Citizen " +
               $"LEFT JOIN Citizen_Skills cs ON c.ID_Citizen = cs.ID_Citizen " +
               $"LEFT JOIN Skills s ON cs.ID_Skill = s.ID_Skill " +
               $"WHERE c.Name Like '%{quer}%' OR c.Surname Like '%{quer}%' OR c.Adress Like '%{quer}%' OR s.Skill LIKE '%{quer}%'" +
               $"OR e.Education_type Like '%{quer}%'";

            List<Citizen> citizens = new List<Citizen>();

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Створюємо списки для зберігання даних
                Dictionary<int, Citizen> citizenDictionary = new Dictionary<int, Citizen>();
                Dictionary<int, List<int>> phonesDictionary = new Dictionary<int, List<int>>();
                Dictionary<int, List<string>> educationDictionary = new Dictionary<int, List<string>>();
                Dictionary<int, List<string>> skillsDictionary = new Dictionary<int, List<string>>();

                // Читаємо дані і зберігаємо їх у словники
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string surname = reader.GetString(2);
                    DateTime birthdate = reader.GetDateTime(3);
                    string adress = reader.GetString(4);
                    bool inv = reader.GetBoolean(5);
                    bool crime = reader.GetBoolean(6);
                    int phone = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                    string education = reader.IsDBNull(8) ? null : reader.GetString(8);
                    string skill = reader.IsDBNull(9) ? null : reader.GetString(9);

                    if (!citizenDictionary.ContainsKey(id))
                    {
                        citizenDictionary[id] = new Citizen(id, name, surname, birthdate, adress, inv, crime);
                    }

                    if (phone > 0)
                    {
                        if (!phonesDictionary.ContainsKey(id))
                            phonesDictionary[id] = new List<int>();

                        if (!phonesDictionary[id].Contains(phone))
                            phonesDictionary[id].Add(phone);
                    }

                    if (!string.IsNullOrEmpty(education))
                    {
                        if (!educationDictionary.ContainsKey(id))
                            educationDictionary[id] = new List<string>();

                        if (!educationDictionary[id].Contains(education))
                            educationDictionary[id].Add(education);
                    }

                    if (!string.IsNullOrEmpty(skill))
                    {
                        if (!skillsDictionary.ContainsKey(id))
                            skillsDictionary[id] = new List<string>();

                        if (!skillsDictionary[id].Contains(skill))
                            skillsDictionary[id].Add(skill);
                    }
                }

                reader.Close();

                // Заповнюємо громадян зі словників
                foreach (var pair in citizenDictionary)
                {
                    int id = pair.Key;
                    Citizen cit = pair.Value;

                    if (phonesDictionary.ContainsKey(id))
                        cit.Phones = phonesDictionary[id];
                    if (educationDictionary.ContainsKey(id))
                        cit.Education = educationDictionary[id];
                    if (skillsDictionary.ContainsKey(id))
                        cit.Skills = skillsDictionary[id];

                    citizens.Add(cit);
                }
            }

            return citizens;
        }


        private List<Vacantion> GetVacantionData(string query)
        {
            List<Vacantion> vacantions = new List<Vacantion>();

            string baseQuery = "SELECT ID_vacantion, ID_Employer, Post, Salary, Replacement_date, Type_of_employment, Company_name FROM Vacantion";
            string filter = string.Empty;

            if (!string.IsNullOrEmpty(query))
            {
                filter = " WHERE Post LIKE @query OR Company_name LIKE @query"; // Додано фільтрацію за посадою та назвою компанії
            }

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                string sqlCommandText = baseQuery + filter;
                SqlCommand command = new SqlCommand(sqlCommandText, connection);

                if (!string.IsNullOrEmpty(query))
                {
                    command.Parameters.AddWithValue("@query", $"%{query}%");
                }

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int employerId = reader.GetInt32(1);
                    string post = reader.GetString(2);
                    int salary = reader.GetInt32(3);
                    DateTime replacementDate = reader.GetDateTime(4);
                    string typeOfEmployment = reader.GetString(5);
                    string companyName = reader.GetString(6);

                    Vacantion vacantion = new Vacantion(id, employerId, post, salary, replacementDate, typeOfEmployment, companyName);
                    vacantions.Add(vacantion);
                }
            }

            return vacantions;
        }
        private void DisplayVacantions(List<Vacantion> vacantions)
        {
            int rowCount = 0;
            int colCount = 0;
            int labelLeft = 10;
            int labelWidth = 200;
            int labelHeight = 20;
            int verticalGap = 2;
            int panelWidth = 275;
            int panelHeight = 175;

            tabControl1.TabPages.Clear(); // Очищаємо вкладки

            TabPage tabPage = new TabPage("Сторінка 1");
            tabControl1.TabPages.Add(tabPage);

            foreach (var vacantion in vacantions)
            {
                
                Panel panel = new Panel();
                panel.BorderStyle = BorderStyle.FixedSingle;
                tabPage.AutoScroll = true;
                panel.Top = 10 + (panelHeight + verticalGap) * rowCount;
                panel.Left = 10 + ((panelWidth + labelLeft * 2 + 5) * colCount);
                panel.Width = panelWidth;
                panel.Height = panelHeight;

                Label nameLabel = new Label();
                nameLabel.Text = "Посада: " + vacantion.Post;
                nameLabel.Left = labelLeft;
                nameLabel.Top = 10;
                nameLabel.Width = labelWidth;
                nameLabel.Height = labelHeight;

                Label idLabel = new Label();
                idLabel.Text = "ID: " + vacantion.ID;
                idLabel.Left = labelLeft;
                idLabel.Top = nameLabel.Bottom + verticalGap;
                idLabel.Width = labelWidth;
                idLabel.Height = labelHeight;

                Label salaryLabel = new Label();
                salaryLabel.Text = "Зарплата: " + vacantion.Salary;
                salaryLabel.Left = labelLeft;
                salaryLabel.Top = idLabel.Bottom + verticalGap;
                salaryLabel.Width = labelWidth;
                salaryLabel.Height = labelHeight;

                Label replacementDateLabel = new Label();
                replacementDateLabel.Text = "Дата розміщення: " + vacantion.ReplacementDate.ToShortDateString();
                replacementDateLabel.Left = labelLeft;
                replacementDateLabel.Top = salaryLabel.Bottom + verticalGap;
                replacementDateLabel.Width = labelWidth;
                replacementDateLabel.Height = labelHeight;

                Label typeOfEmploymentLabel = new Label();
                typeOfEmploymentLabel.Text = "Тип зайнятості: " + vacantion.TypeOfEmployment;
                typeOfEmploymentLabel.Left = labelLeft;
                typeOfEmploymentLabel.Top = replacementDateLabel.Bottom + verticalGap;
                typeOfEmploymentLabel.Width = labelWidth;
                typeOfEmploymentLabel.Height = labelHeight;

                Label companyNameLabel = new Label();
                companyNameLabel.Text = "Назва компанії: " + vacantion.CompanyName;
                companyNameLabel.Left = labelLeft;
                companyNameLabel.Top = typeOfEmploymentLabel.Bottom + verticalGap;
                companyNameLabel.Width = labelWidth;
                companyNameLabel.Height = labelHeight;

                panel.Controls.Add(nameLabel);
                panel.Controls.Add(idLabel);
                panel.Controls.Add(salaryLabel);
                panel.Controls.Add(replacementDateLabel);
                panel.Controls.Add(typeOfEmploymentLabel);
                panel.Controls.Add(companyNameLabel);
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
            int labelLeft = 10;
            int labelWidth = 670;
            int labelHeight = 20;
            int verticalGap = 2;
            int panelWidth = 670;
            int panelHeight = 220;

            tabControl1.TabPages.Clear(); // Очищаємо вкладки

            TabPage tabPage = new TabPage("Сторінка 1");
            tabControl1.TabPages.Add(tabPage);
            tabPage.AutoScroll = true;

            int topPosition = 10;
            foreach (var citizen in citizens)
            {
                Panel panel = new Panel();
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Top = topPosition;
                panel.Left = 10;
                panel.Width = panelWidth;
                panel.Height = panelHeight;
                panel.AutoSize = true; // Автоматичний розмір

                Label nameLabel = new Label();
                nameLabel.Text = "Ім'я: " + citizen.Name;
                nameLabel.Left = labelLeft;
                nameLabel.Top = 10;
                nameLabel.Width = labelWidth;
                nameLabel.Height = labelHeight;

                Label surnameLabel = new Label();
                surnameLabel.Text = "Прізвище: " + citizen.Surname;
                surnameLabel.Left = labelLeft;
                surnameLabel.Top = nameLabel.Bottom + verticalGap;
                surnameLabel.Width = labelWidth;
                surnameLabel.Height = labelHeight;

                Label dateLabel = new Label();
                dateLabel.Text = "Дата народження: " + citizen.Date.ToShortDateString();
                dateLabel.Left = labelLeft;
                dateLabel.Top = surnameLabel.Bottom + verticalGap;
                dateLabel.Width = labelWidth;
                dateLabel.Height = labelHeight;

                Label adressLabel = new Label();
                adressLabel.Text = "Адреса: " + citizen.Adress;
                adressLabel.Left = labelLeft;
                adressLabel.Top = dateLabel.Bottom + verticalGap;
                adressLabel.Width = labelWidth;
                adressLabel.Height = labelHeight;

                Label invalidityLabel = new Label();
                invalidityLabel.Text = "Інвалідність: " + (citizen.Invalidity ? "Так" : "Ні");
                invalidityLabel.Left = labelLeft;
                invalidityLabel.Top = adressLabel.Bottom + verticalGap;
                invalidityLabel.Width = labelWidth;
                invalidityLabel.Height = labelHeight;

                Label crimeLabel = new Label();
                crimeLabel.Text = "Кримінальний запис: " + (citizen.Crime ? "Так" : "Ні");
                crimeLabel.Left = labelLeft;
                crimeLabel.Top = invalidityLabel.Bottom + verticalGap;
                crimeLabel.Width = labelWidth;
                crimeLabel.Height = labelHeight;

                Label phonesLabel = new Label();
                phonesLabel.Text = "Телефони: " + (citizen.Phones != null ? string.Join(", ", citizen.Phones) : "Немає");
                phonesLabel.Left = labelLeft;
                phonesLabel.Top = crimeLabel.Bottom + verticalGap;
                phonesLabel.Width = labelWidth;
                phonesLabel.Height = labelHeight;

                Label educationLabel = new Label();
                educationLabel.Text = "Освіта: " + (citizen.Education != null ? string.Join(", ", citizen.Education) : "Немає");
                educationLabel.Left = labelLeft;
                educationLabel.Top = phonesLabel.Bottom + verticalGap;
                educationLabel.Width = labelWidth;
                educationLabel.Height = labelHeight;

                Label skillsLabel = new Label();
                skillsLabel.Text = "Навички: " + (citizen.Skills != null ? string.Join(", ", citizen.Skills) : "Немає");
                skillsLabel.Left = labelLeft;
                skillsLabel.Top = educationLabel.Bottom + verticalGap;
                skillsLabel.Width = labelWidth;
                skillsLabel.Height = labelHeight;

                panel.Controls.Add(nameLabel);
                panel.Controls.Add(surnameLabel);
                panel.Controls.Add(dateLabel);
                panel.Controls.Add(adressLabel);
                panel.Controls.Add(invalidityLabel);
                panel.Controls.Add(crimeLabel);
                panel.Controls.Add(phonesLabel);
                panel.Controls.Add(educationLabel);
                panel.Controls.Add(skillsLabel);

                tabPage.Controls.Add(panel);

                topPosition += panelHeight + verticalGap;
            }
        }


        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені, що хочете закрити вікно?", "Закриття програми", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Відміна закриття форми
            }
            else if (result == DialogResult.Yes)
            {
                Form1 frm = (Form1)Application.OpenForms["Form1"];
                if (frm != null)
                {
                    frm.Enabled = true;
                    frm.Focus(); // Фокусуємося на формі Form1
                }
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string query = searchTextBox.Text;
            tabControl1.TabPages.Clear();
            if (vacantionRadioButton.Checked)
            {
                vacantions.Clear();
                vacantions = GetVacantionData(query);
                if (!string.IsNullOrEmpty(query))
                {

                    DisplayVacantions(vacantions);
                    searchTextBox.Focus(); // Зберігаємо фокус на TextBox
                }
            }
            else if (citizenRadioButton.Checked)
            {
                citizens.Clear();
                citizens = GetCitizenData(query);
                if (!string.IsNullOrEmpty(query))
                {

                    DisplayCitizens(citizens);
                    searchTextBox.Focus(); // Зберігаємо фокус на TextBox
                }
            }
        }
    }
    public partial class Vacantion
    {
        public int ID { get; set; }
        public int EmployerID { get; set; }
        public string Post { get; set; }
        public double Salary { get; set; }
        public DateTime ReplacementDate { get; set; }
        public string TypeOfEmployment { get; set; }
        public string CompanyName { get; set; }

        public Vacantion(int id, int employerId, string post, double salary, DateTime replacementDate, string typeOfEmployment, string companyName)
        {
            ID = id;
            EmployerID = employerId;
            Post = post;
            Salary = salary;
            ReplacementDate = replacementDate;
            TypeOfEmployment = typeOfEmployment;
            CompanyName = companyName;
        }
    }
}
