using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Kursova
{
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();
        DataAccess dataAccess; // Додано поле для екземпляру класу DataAccess

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            SqlConnection connectionString = new SqlConnection(@"Data Source=ACER;Initial Catalog=Vacantion_kursosva;Integrated Security=True");
            string connect = @"Data Source=ACER;Initial Catalog=Vacantion_kursosva;Integrated Security=True";
            dataAccess = new DataAccess(connect); // Ініціалізуємо екземпляр класу DataAccess
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені, що хочете закрити вікно?", "Закриття програми", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Відміна закриття форми
            }
            else if (result == DialogResult.Yes)
            {
                e.Cancel = false;
                Application.Exit();
            }
        }

        private void Add_person_Click(object sender, EventArgs e)
        {
            Add_Person add_Person = new Add_Person();
            add_Person.Show();
            this.Enabled = false;
        }

        private void Manage_person_Click(object sender, EventArgs e)
        {
            Manage_Person man_per = new Manage_Person();
            man_per.Show();
            this.Enabled = false;
        }

        private void Vacantion_Click(object sender, EventArgs e)
        {
            Vacantion vac = new Vacantion();
            vac.Show();
            this.Enabled = false;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            Search serch = new Search();
            serch.Show();
            this.Enabled = false;
        }

        private void To_declare_Click(object sender, EventArgs e)
        {
            // Створюємо текст для звіту
            StringBuilder reportText = new StringBuilder();

            // Додаємо дані про популярні навички
            reportText.AppendLine("Найпопулярніші навички:");
            var popularSkills = dataAccess.GetPopularSkills(3); // Викликаємо метод через екземпляр класу DataAccess
            foreach (var skill in popularSkills)
            {
                reportText.AppendLine($"{skill.Name}: {skill.Count} осіб");
            }
            reportText.AppendLine();

            // Додаємо дані про кількість громадян, що шукають роботу у певному місті
            reportText.AppendLine("Кількість громадян, що шукають роботу у певному місті:");
            var citizensByCity = dataAccess.GetCitizensByCity(); // Викликаємо метод через екземпляр класу DataAccess
            foreach (var city in citizensByCity)
            {
                reportText.AppendLine($"{city.City}: {city.Count} осіб");
            }
            reportText.AppendLine();

            // Додаємо дані про компанію з найбільшою кількістю вакансій
            reportText.AppendLine("Компанія з найбільшою кількістю вакансій:");
            string companyWithMostVacancies = dataAccess.GetCompanyWithMostVacancies(); // Викликаємо метод через екземпляр класу DataAccess
            reportText.AppendLine(companyWithMostVacancies);
            reportText.AppendLine();

            // Додаємо дані про компанію з найбільшими зарплатами
            reportText.AppendLine("Компанія з найбільшими зарплатами:");
            string companyWithHighestSalaries = dataAccess.GetCompanyWithHighestSalaries(); // Викликаємо метод через екземпляр класу DataAccess
            reportText.AppendLine(companyWithHighestSalaries);
            reportText.AppendLine();

           
            // Відкриваємо вікно вибору файлу для збереження звіту
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстові файли (*.txt)|*.txt";
            saveFileDialog.Title = "Зберегти звіт";
            saveFileDialog.ShowDialog();

            // Зберігаємо звіт у вибраний файл
            if (saveFileDialog.FileName != "")
            {
                File.WriteAllText(saveFileDialog.FileName, reportText.ToString());
                MessageBox.Show("Звіт збережено успішно!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    public class SkillCount
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class CityCount
    {
        public string City { get; set; }
        public int Count { get; set; }
    }

    public class DataAccess
    {
        private readonly string connectionString;

        public DataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<SkillCount> GetPopularSkills(int count)
        {
            List<SkillCount> popularSkills = new List<SkillCount>();

            string query = $"SELECT TOP {count} s.Skill, COUNT(*) AS Count " +
                           "FROM Citizen_Skills cs " +
                           "JOIN Skills s ON cs.ID_Skill = s.ID_Skill " +
                           "GROUP BY s.Skill " +
                           "ORDER BY Count DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SkillCount skillCount = new SkillCount
                    {
                        Name = reader.GetString(0),
                        Count = reader.GetInt32(1)
                    };
                    popularSkills.Add(skillCount);
                }

                reader.Close();
            }

            return popularSkills;
        }


        public List<CityCount> GetCitizensByCity()
        {
            List<CityCount> citizensByCity = new List<CityCount>();

            string query = $"SELECT Adress, COUNT(*) AS Count " +
                           "FROM Citizen " +
                           "GROUP BY Adress";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CityCount cityCount = new CityCount
                    {
                        City = reader.GetString(0),
                        Count = reader.GetInt32(1)
                    };
                    citizensByCity.Add(cityCount);
                }

                reader.Close();
            }

            return citizensByCity;
        }

        public string GetCompanyWithMostVacancies()
        {
            string companyWithMostVacancies = "";

            string query = $"SELECT TOP 1 Company_name " +
                           "FROM Vacantion " +
                           "GROUP BY Company_name " +
                           "ORDER BY COUNT(*) DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    companyWithMostVacancies = reader.GetString(0);
                }

                reader.Close();
            }

            return companyWithMostVacancies;
        }

        public string GetCompanyWithHighestSalaries()
        {
            string companyWithHighestSalaries = "";

            string query = $"SELECT TOP 1 Company_name " +
                           "FROM Vacantion " +
                           "ORDER BY Salary DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    companyWithHighestSalaries = reader.GetString(0);
                }

                reader.Close();
            }

            return companyWithHighestSalaries;
        }
    }

}
