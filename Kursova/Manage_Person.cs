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
using System.Xml.Linq;

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


        private List<Employer> GetEmployersData(string quer)
        {
            List<Employer> employers = new List<Employer>();

            string query = $"SELECT E.ID_Employer, E.Name_employer, E.email " +
                           $"FROM Employer E " +
                           $"WHERE E.email Like '%{quer}%' OR E.Name_employer Like '%{quer}%'";

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
                           $"WHERE Name Like '%{quer}%' OR Surname Like '%{quer}%' OR Adress Like '%{quer}%'";

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

                Button removeButton = new Button();
                removeButton.Text = "Видалити";
                removeButton.Top = manageButton.Top  +34;
                removeButton.Left = manageButton.Left;
                removeButton.Width = 75;
                removeButton.Height = 35;

                manageButton.Click += (sender, e) => { EditEmployer(employer); };
                removeButton.Click += (sender, e) => { RemoveEmployer(employer); };

                panel.Controls.Add(nameLabel);
                panel.Controls.Add(idLabel);
                panel.Controls.Add(emailLabel);
                panel.Controls.Add(manageButton);
                panel.Controls.Add(removeButton);
                manageButton.BringToFront();
                removeButton.BringToFront();
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

                Button removeButton = new Button();
                removeButton.Text = "Видалити";
                removeButton.Top = manageButton.Top + 33;
                removeButton.Left = manageButton.Left;
                removeButton.Width = 75;
                removeButton.Height = 35;
                removeButton.Click += (sender, e) => { RemoveCitizen(citizen); };

                panel.Controls.Add(nameLabel);
                panel.Controls.Add(surLabel);
                panel.Controls.Add(datelLabel);
                panel.Controls.Add(adresslLabel);
                panel.Controls.Add(manageButton);
                panel.Controls.Add(removeButton);
                manageButton.BringToFront();
                removeButton.BringToFront();
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

        private void search_Box_TextChanged(object sender, EventArgs e)
        {
            if (radioB_emp.Checked)
            {
                string quer = search_Box.Text.Trim();
                employers.Clear();
                employers = GetEmployersData(quer);

                if (!string.IsNullOrEmpty(quer))
                {
                    ClearTabControl(tabControl);
                    DisplayEmployers(employers);
                    search_Box.Focus(); // Зберігаємо фокус на TextBox
                }
            }
            else if (radioB_cit.Checked)
            {
                string quer = search_Box.Text.Trim();
                citizens.Clear();
                citizens = GetCitizenData(quer);

                if (!string.IsNullOrEmpty(quer))
                {
                    ClearTabControl(tabControl);
                    DisplayCitizens(citizens);
                    search_Box.Focus(); // Зберігаємо фокус на TextBox
                }
            }
        }
        private void RemoveEmployer(Employer employer)
        {
            // Питаємо користувача, чи він впевнений, що хоче видалити роботодавця
            DialogResult result = MessageBox.Show("Ви впевнені, що бажаєте видалити цього роботодавця? Ця дія є незворотньою.", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Видаляємо всі вакансії, пов'язані з цим роботодавцем
                string deleteVacantionsQuery = "DELETE FROM Vacantion WHERE ID_Employer = @employerId";

                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(deleteVacantionsQuery, connection);
                    command.Parameters.AddWithValue("@employerId", employer.ID);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка при видаленні вакансій: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Видаляємо всі номери телефонів, пов'язані з цим роботодавцем
                string deletePhonesQuery = "DELETE FROM Phone WHERE ID_Employer = @employerId";

                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(deletePhonesQuery, connection);
                    command.Parameters.AddWithValue("@employerId", employer.ID);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка при видаленні номерів телефонів: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Видаляємо самого роботодавця
                string deleteEmployerQuery = "DELETE FROM Employer WHERE ID_Employer = @employerId";

                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(deleteEmployerQuery, connection);
                    command.Parameters.AddWithValue("@employerId", employer.ID);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Роботодавця успішно видалено.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tabControl.TabPages.Clear();
                            string quer = search_Box.Text.Trim();
                            employers.Clear();
                            employers = GetEmployersData(quer);

                            if (!string.IsNullOrEmpty(quer))
                            {
                                ClearTabControl(tabControl);
                                DisplayEmployers(employers);
                                search_Box.Focus(); // Зберігаємо фокус на TextBox
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не вдалося видалити роботодавця.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка при видаленні роботодавця: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void RemoveCitizen(Citizen citizen)
        {
            if (MessageBox.Show("Ви впевнені, що бажаєте видалити цього громадянина?", "Видалення громадянина",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteCitizenSkills(citizen.ID);
                DeleteCitizenPhones(citizen.ID);
                DeleteCitizenDocuments(citizen.ID);
                DeleteCitizenEducations(citizen.ID);
                DeleteCitizenVacantions(citizen.ID);
                DeleteCitizen(citizen.ID);
            }
        }

        private void DeleteCitizenSkills(int citizenId)
        {
            string query = "DELETE FROM Citizen_Skills WHERE ID_Citizen = @citizenId";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@citizenId", citizenId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка під час видалення навичок громадянина: " + ex.Message);
                }
            }
        }

        private void DeleteCitizenPhones(int citizenId)
        {
            string query = "DELETE FROM Citizen_Phone WHERE ID_Citizen = @citizenId";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@citizenId", citizenId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка під час видалення номерів телефонів громадянина: " + ex.Message);
                }
            }
        }

        private void DeleteCitizenDocuments(int citizenId)
        {
            string query = "DELETE FROM Document WHERE ID_Citizen = @citizenId";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@citizenId", citizenId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка під час видалення документів громадянина: " + ex.Message);
                }
            }
        }

        private void DeleteCitizenEducations(int citizenId)
        {
            string query = "DELETE FROM Education WHERE ID_Citizen = @citizenId";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@citizenId", citizenId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка під час видалення освіти громадянина: " + ex.Message);
                }
            }
        }

        private void DeleteCitizenVacantions(int citizenId)
        {
            string query = "DELETE FROM Citizen_Vacantion WHERE ID_Citizen = @citizenId";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@citizenId", citizenId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка під час видалення вакансій громадянина: " + ex.Message);
                }
            }
        }

        private void DeleteCitizen(int citizenId)
        {
            string query = "DELETE FROM Citizen WHERE ID_Citizen = @citizenId";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@citizenId", citizenId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Громадянина успішно видалено");
                        tabControl.TabPages.Clear();
                        string quer = search_Box.Text.Trim();
                        citizens.Clear();
                        citizens = GetCitizenData(quer);

                        if (!string.IsNullOrEmpty(quer))
                        {
                            ClearTabControl(tabControl);
                            DisplayCitizens(citizens);
                            search_Box.Focus(); // Зберігаємо фокус на TextBox
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося видалити громадянина.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка під час видалення громадянина: " + ex.Message);
                }
            }
        }

        private void Manage_Person_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Manage_Person_Load(object sender, EventArgs e)
        {

        }
    }
    public partial class Employer
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
    public partial class Citizen
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date { get; set; }
        public string Adress { get; set; }
        public bool Invalidity { get; set; }
        public bool Crime { get; set; }
        public List<int> Phones { get; set; } // Додавання телефону
        public List<string> Education { get; set; } // Додавання освіти
        public List<string> Skills { get; set; } // Додавання навичок
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
        public Citizen(int iD, string name, string surname, DateTime date, string adress, List<int> phone, List<string> education, List<string> skills, bool invalidity, bool crime)
        {
            ID = iD;
            Name = name;
            Surname = surname;
            Date = date;
            Adress = adress;
            Phones = phone; // Додано телефон
            Education = education; // Додано освіту
            Skills = skills; // Додано навички
            Invalidity = invalidity;
            Crime = crime;
        }
    }
}
