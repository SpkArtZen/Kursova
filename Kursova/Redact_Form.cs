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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text.RegularExpressions;

namespace Kursova
{  
    public partial class Redact_Form : Form
    {
        SqlConnection connectionString = new SqlConnection(@"Data Source=ACER;Initial Catalog=Vacantion_kursosva;Integrated Security=True");
        DataBase dataBase = new DataBase();
        private Employer selectedEmployer; // Поле для зберігання об'єкта Employer
        List<string> phones = new List<string>();
        int ID { get; set; }
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();
        public Redact_Form(Employer employer)
        {
            InitializeComponent();
            selectedEmployer = employer; // Зберігання об'єкта при його передачі через конструктор
            name_emp.Text = employer.Name;
            email_emp.Text = employer.email;
            int ID = employer.ID;
            string query = "SELECT Phone, Comment FROM Phone WHERE ID_Employer = @ID_Employer";
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_Employer", employer.ID);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string phone = reader.GetInt32(0).ToString() ;
                    string comm = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    phones.Add(phone);
                    phoneBook[phone] = comm;
                    phones_emp.Items.Add(phone);
                }
                reader.Close();
            }

        }

        private void name_red_Click(object sender, EventArgs e)
        {
            string name = name_emp.Text;
            if (!string.IsNullOrEmpty(name))
            {
                int userId = selectedEmployer.ID;
                string query = "UPDATE Employer SET Name_employer = @NewName WHERE ID_Employer = @UserId";

                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewName", name);
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("Введіть пошту!", "Зміна пошти", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
        }

        private void email_red_Click(object sender, EventArgs e)
        {
            string email = email_emp.Text;
            if (!string.IsNullOrEmpty(email))
            {
                int userId = selectedEmployer.ID;
                string query = "UPDATE Employer SET email = @NewEmail WHERE ID_Employer = @UserId";

                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewEmail", email_emp);
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("Введіть пошту!", "Зміна пошти", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comm_red_Click(object sender, EventArgs e)
        {
            string comm = comment_phone_emp.Text.Trim();
            string selectedPhone = phones_emp.SelectedItem.ToString();
            string query = "UPDATE Phone SET Comment = @NewComm WHERE Phone = @Phone";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewComm", comm);
                command.Parameters.AddWithValue("@Phone", selectedPhone);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        private void phones_emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (phones_emp.SelectedIndex >= 0)
            {
                string selectedPhone = phones_emp.SelectedItem.ToString();
                if (phoneBook.ContainsKey(selectedPhone))
                {
                    comment_phone_emp.Text = phoneBook[selectedPhone];
                }
            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(text_phone.Text))
            {
                int phone = int.Parse(text_phone.Text.Trim());   
                // Додавання нового номера телефону до списку
                phones_emp.Items.Add(phone);
                string pattern = @"^\d{9}$";

                if (Regex.IsMatch(phone.ToString(), pattern))
                {
                    // Перевірка, чи існує вказаний ID_Employer
                    string queryCheckEmployer = "SELECT COUNT(*) FROM Employer WHERE ID_Employer = @ID_Employer";
                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    {
                        SqlCommand commandCheckEmployer = new SqlCommand(queryCheckEmployer, connection);
                        commandCheckEmployer.Parameters.AddWithValue("@ID_Employer", selectedEmployer.ID);
                        connection.Open();
                        int employerCount = (int)commandCheckEmployer.ExecuteScalar();

                        if (employerCount > 0)
                        {
                            string queryInsertPhone = "INSERT INTO Phone (Phone, Comment, ID_Employer) VALUES (@Phone, @Comment, @ID_Employer)";
                            using (SqlCommand commandInsertPhone = new SqlCommand(queryInsertPhone, connection))
                            {
                                commandInsertPhone.Parameters.AddWithValue("@Phone", phone);
                                commandInsertPhone.Parameters.AddWithValue("@Comment", comment_phone_emp.Text);
                                commandInsertPhone.Parameters.AddWithValue("@ID_Employer", selectedEmployer.ID);
                                commandInsertPhone.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            MessageBox.Show("ID_Employer не існує в таблиці Employer!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Невірний формат номеру!", "Додавання номеру", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                text_phone.Text = "";
                comment_phone_emp.Text = "";
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
           
            if (phones_emp.SelectedItem != null)
            {
                string selectedPhone = phones_emp.SelectedItem.ToString();
                string query = $"DELETE FROM Phone WHERE Phone = @Phone";

                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Phone", selectedPhone);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                phones_emp.Text = "";
                if (phones_emp.Items.Count > 0)
                {
                    int currentIndex = phones_emp.SelectedIndex;
                    phones_emp.Items.RemoveAt(currentIndex);
                    if (currentIndex < phones_emp.Items.Count)
                    {
                        phones_emp.SelectedIndex = currentIndex;
                    }
                    else if (phones_emp.Items.Count > 0)
                    {
                        phones_emp.SelectedIndex = currentIndex - 1;
                    }
                }
                if (phoneBook.ContainsKey(selectedPhone))
                {
                    phoneBook.Remove(selectedPhone);
                }
                phones.Remove(selectedPhone);
                selectedPhone = null;
            }
        }
    }
}
