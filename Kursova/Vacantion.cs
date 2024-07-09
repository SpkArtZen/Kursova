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
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Text.RegularExpressions;

namespace Kursova
{
    public partial class Vacantion : Form
    {
        SqlConnection connectionString = new SqlConnection(@"Data Source=ACER;Initial Catalog=Vacantion_kursosva;Integrated Security=True");
        DataBase dataBase = new DataBase();
        private int selectedVacantionId;
        public Vacantion()
        {
            InitializeComponent();
            LoadEmployers();
            comboBox_EmploymentType.Items.Add("Повна зайнятість");
            comboBox_EmploymentType.Items.Add("Неповна зайнятість");
            FillVacantionComboBox();
            FillCitizenComboBox();
        }
        private void LoadEmployers()
        {
            comboBox_Employer.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                string query = "SELECT ID_Employer, email FROM Employer";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int employerId = reader.GetInt32(0);
                            string email = reader.GetString(1);
                            comboBox_Employer.Items.Add(new EmployerItem(employerId, email));
                        }
                    }
                }
            }
            comboBox_Employer.DisplayMember = "email";
            comboBox_Employer.ValueMember = "ID_Employer";
        }
        public class EmployerItem
        {
            public int EmployerId { get; set; }
            public string Email { get; set; }

            public EmployerItem(int employerId, string email)
            {
                EmployerId = employerId;
                Email = email;
            }

            public override string ToString()
            {
                return Email;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string position = textBox_Position.Text;
            string company = textBox_Company.Text;
            int salary = 0;
            DateTime currentDate = DateTime.Now;
            if (!int.TryParse(textBox_Salary.Text, out salary))
            {
                MessageBox.Show("Введіть коректну зарплатню.");
                return;
            }
            string employmentType = comboBox_EmploymentType.SelectedItem.ToString();
            EmployerItem selectedEmployer = (EmployerItem)comboBox_Employer.SelectedItem;
            int employerId = selectedEmployer.EmployerId;

            if (string.IsNullOrWhiteSpace(position) || string.IsNullOrWhiteSpace(company) || string.IsNullOrWhiteSpace(employmentType) || (employerId == 0))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                string query = "INSERT INTO Vacantion (ID_Employer, Post, Salary, Replacement_date, Type_of_employment, Company_name) VALUES (@Employer, @Position, @Salary, @Date, @EmploymentType, @Company)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Position", position);
                    command.Parameters.AddWithValue("@Company", company);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@Date", currentDate);
                    command.Parameters.AddWithValue("@EmploymentType", employmentType);
                    command.Parameters.AddWithValue("@Employer", employerId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Вакансія успішно додана.");
                            FillVacantionComboBox();
                        }
                        else
                        {
                            MessageBox.Show("Не вдалося додати вакансію.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка: " + ex.Message);
                    }
                }
            }
        }
        private void FillVacantionComboBox()
        {
            allVacantions.Items.Clear();
            string query = "SELECT ID_vacantion, Post, Company_name, Salary, Replacement_date " +
                           "FROM Vacantion";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int vacantionId = reader.GetInt32(0);
                        string post = reader.GetString(1);
                        string company = reader.GetString(2);
                        int salary = reader.GetInt32(3);
                        DateTime date = reader.GetDateTime(4);

                        string item = $"{vacantionId}, {post}, {company}, {salary}, {date.ToShortDateString()}";
                        comboBoxVacantions.Items.Add(item); // Додавання рядка до ComboBox
                        allVacantions.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void FillCitizenComboBox()
        {
            string query = "SELECT ID_Citizen, Name, Surname, Birthdate, Adress " +
                           "FROM Citizen";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int CitizenID = reader.GetInt32(0);
                        string Name = reader.GetString(1);
                        string Surname = reader.GetString(2);
                        DateTime date = reader.GetDateTime(3);
                        string adress = reader.GetString(4);
                        string item = $"{CitizenID}, {Name}, {Surname}, {date.ToShortDateString()}, {adress}";
                        allCitizen.Items.Add(item); // Додавання рядка до ComboBox
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void buttonDeleteVacantion_Click(object sender, EventArgs e)
        {
            if (comboBoxVacantions.SelectedIndex != -1)
            {
                // Отримати обраний рядок з ComboBox
                string selectedVacantionInfo = comboBoxVacantions.SelectedItem.ToString();

                // Розділити рядок, щоб взяти ID вакансії
                string[] parts = selectedVacantionInfo.Split(',');

                if (parts.Length >= 5)
                {
                    int selectedVacantionId;
                    if (int.TryParse(parts[0], out selectedVacantionId))
                    {
                        // Видалити вакансію з бази даних
                        string query = "DELETE FROM Vacantion WHERE ID_vacantion = @vacantionId";

                        using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                        {
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@vacantionId", selectedVacantionId);

                            try
                            {
                                connection.Open();
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Вакансію успішно видалено!");
                                    comboBoxVacantions.Items.RemoveAt(comboBoxVacantions.SelectedIndex);
                                    comboBoxVacantions.Text = "";
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Помилка: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося визначити ID вакансії!");
                    }
                }
                else
                {
                    MessageBox.Show("Неправильний формат рядка в ComboBox!");
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть вакансію для видалення!");
            }
        }

        private void Add_Vacantion_CheckedChanged(object sender, EventArgs e)
        {
            if (Add_Vacantion.Checked)
            {
                panel3.Visible = true;
                panel4.Visible = false;
            }
            else if (Manage_Vacantion.Checked)
            {
                panel4.Visible = true;
                panel4.BringToFront();
            }
        }
       
        
        private void allVacantions_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void add_citizen_Click(object sender, EventArgs e)
        {
            if (allVacantions.SelectedIndex != -1 && allCitizen.SelectedIndex != -1)
            {
                string selectedVacantionInfo = allVacantions.SelectedItem.ToString();
                int vacantionId = int.Parse(selectedVacantionInfo.Split(',')[0]);

                string selectedCitizenInfo = allCitizen.SelectedItem.ToString();
                int citizenId = int.Parse(selectedCitizenInfo.Split(',')[0]);

                string query = "INSERT INTO Citizen_Vacantion (ID_Citizen, ID_vacantion) VALUES (@citizenId, @vacantionId)";

                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@citizenId", citizenId);
                    command.Parameters.AddWithValue("@vacantionId", vacantionId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Громадянина успішно підписано на вакансію");
                            UpdateDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Не вдалося підписати громадянина на вакансію.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть вакансію і громадянина!");
            }
        }
        private void UpdateDataGridView()
        {
            if (allVacantions.SelectedIndex != -1)
            {
                string selectedVacantionInfo = allVacantions.SelectedItem.ToString();
                int selectedVacantionId = int.Parse(selectedVacantionInfo.Split(',')[0]);

                string query = "SELECT cv.ID_vacantion, cv.ID_Citizen, c.ID_Citizen AS [ID громадянина], " +
                               "v.Post, v.Company_name, v.Replacement_date, c.Name, c.Surname " +
                               "FROM Citizen_Vacantion cv " +
                               "INNER JOIN Vacantion v ON cv.ID_vacantion = v.ID_vacantion " +
                               "LEFT JOIN Citizen c ON cv.ID_Citizen = c.ID_Citizen " +
                               "WHERE cv.ID_vacantion = @vacantionId";

                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@vacantionId", selectedVacantionId);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("ID вакансії", typeof(int));
                        dataTable.Columns.Add("ID громадянина", typeof(int));
                        dataTable.Columns.Add("Посада", typeof(string));
                        dataTable.Columns.Add("Назва компанії", typeof(string));
                        dataTable.Columns.Add("Дата розміщення", typeof(string));
                        dataTable.Columns.Add("Ім'я громадянина", typeof(string));
                        dataTable.Columns.Add("Прізвище громадянина", typeof(string));

                        while (reader.Read())
                        {
                            int vacantionId = reader.IsDBNull(0) ? -1 : reader.GetInt32(0);
                            int citizenId = reader.IsDBNull(1) ? -1 : reader.GetInt32(1);
                            int citizenId2 = reader.IsDBNull(2) ? -1 : reader.GetInt32(2);
                            string post = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            string companyName = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            DateTime date = reader.GetDateTime(5);
                            string firstName = reader.IsDBNull(6) ? "" : reader.GetString(6);
                            string lastName = reader.IsDBNull(7) ? "" : reader.GetString(7);

                            dataTable.Rows.Add(vacantionId, citizenId2, post, companyName, date.ToShortDateString(), firstName, lastName);
                            
                        }

                        dataGridView1.DataSource = dataTable;

                        reader.Close();
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка: " + ex.Message);
                    }
                }
            }
        }


        private void Delete_citizen_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int vacantionId;
                if (dataGridView1.SelectedRows[0].Cells["ID вакансії"].Value != DBNull.Value && dataGridView1.SelectedRows[0].Cells["ID вакансії"].Value != null)
                {
                    vacantionId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID вакансії"].Value);
                }
                else
                {
                    MessageBox.Show("ID вакансії недійсне.");
                    return;
                }

                int citizenId;
                if (dataGridView1.SelectedRows[0].Cells["ID громадянина"].Value != DBNull.Value && dataGridView1.SelectedRows[0].Cells["ID громадянина"].Value != null)
                {
                    citizenId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID громадянина"].Value);
                }
                else
                {
                    MessageBox.Show("ID громадянина недійсне.");
                    return;
                }

                DeleteCitizenFromVacantion(citizenId, vacantionId);
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть запис для видалення.");
            }
        }
        private void DeleteCitizenFromVacantion(int citizenId, int vacantionId)
        {
            string query = "DELETE FROM Citizen_Vacantion WHERE ID_Citizen = @citizenId AND ID_vacantion = @vacantionId";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@citizenId", citizenId);
                command.Parameters.AddWithValue("@vacantionId", vacantionId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Громадянина успішно видалено з вакансії");
                        UpdateDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося видалити громадянина з вакансії.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message);
                }
            }
        }

        private void Vacantion_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
   
