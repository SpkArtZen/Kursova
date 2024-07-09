using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Kursova.Manage_Person;

namespace Kursova
{
    public partial class Redact_Form_cit : Form
    {
        SqlConnection connectionString = new SqlConnection(@"Data Source=ACER;Initial Catalog=Vacantion_kursosva;Integrated Security=True");
        DataBase dataBase = new DataBase();
        List<string> phones = new List<string>();
        int ID { get; set; }
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();
        private Citizen selectedCitizen;
        public Redact_Form_cit(Citizen citizen)
        {
            InitializeComponent();
            selectedCitizen = citizen;
            ID = selectedCitizen.ID;

            for (int i = DateTime.Now.Year; i >= 1900; i--)
            {
                year.Items.Add(i);
            }
            for (int i = 1; i <= 12; i++)
            {
                month.Items.Add(i);
                month_doc.Items.Add(i);
                month_doc_change.Items.Add(i);
            }
            for (int i = DateTime.Now.Year; i <= 2050; i++)
            {
                year_doc.Items.Add(i);
                year_doc_change.Items.Add(i);
            }
            // Додати дні в ComboBox для днів (в залежності від обраного місяця та року)
            month.SelectedIndexChanged += (sender, e) => UpdateDays();
            year.SelectedIndexChanged += (sender, e) => UpdateDays();

            UpdateDays(); // Оновити список днів для поточного місяця та року

            Task.Run(() =>
            {
                try
                {
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            LoadPhones();
                        });
                    }
                    else
                    {
                        LoadPhones();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

            year.MaxLength = 4;
            day.MaxLength = 2;
            month.MaxLength = 2;
            // Отримати рік, місяць і день з властивості Citizen.Date
            int year_cit = selectedCitizen.Date.Year;
            int month_cit = selectedCitizen.Date.Month;
            int day_cit = selectedCitizen.Date.Day;
            CheckInvadilityCrime();
            // Встановити значення в ComboBox
            this.year.SelectedItem = year_cit;
            this.month.SelectedItem = month_cit;
            this.day.SelectedItem = day_cit;
            name_text.Text = selectedCitizen.Name;
            surname_text.Text= selectedCitizen.Surname;
            adress_text.Text = selectedCitizen.Adress;
            add_doc_radio.Checked = true;
            type_doc.Items.Add("Паспорт");
            type_doc.Items.Add("Свідотство про народження");
            type_doc.Items.Add("Виписка про інвалідність");
            choose_doc.Items.Add("Паспорт");
            choose_doc.Items.Add("Свідотство про народження");
            choose_doc.Items.Add("Виписка про інвалідність");
            Update_Skills();
            ShowCitizenSkills();
            CItizen_skills_data.ReadOnly = true;
            CItizen_skills_data.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void CheckInvadilityCrime()
        {
            if(selectedCitizen.Invalidity)
            {
                checkInv.Checked = true;
            }
            else
            {
                checkInv.Checked = false;
            }
            if(selectedCitizen.Crime)
            {
                checkCrime.Checked = true;
            }
            else
            {
                checkCrime.Checked = false;
            }
        }
        private void LoadPhones()
        {
            string query = "SELECT Phone, Comment FROM Citizen_Phone WHERE ID_Citizen = @ID_Citizen";
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID_Citizen", selectedCitizen.ID);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string phone = reader.GetInt32(0).ToString();
                    string comm = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    phones.Add(phone);
                    phoneBook[phone] = comm;
                    phones_cit.Items.Add(phone);
                }
                reader.Close();
            }
        }
        private void UpdateDays()
        {
            if (year.SelectedItem != null && month.SelectedItem != null)
            {
                day.Items.Clear();
                int selectedYear = (int)year.SelectedItem;
                int selectedMonth = (int)month.SelectedItem;

                int daysInMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);
                for (int i = 1; i <= daysInMonth; i++)
                {
                    day.Items.Add(i);
                    day_doc.Items.Add(i);
                    day_doc_change.Items.Add(i);
                }
            }

        }
        private void Add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(text_phone.Text))
            {
                int phone = int.Parse(text_phone.Text.Trim());
                // Додавання нового номера телефону до списку
                phones_cit.Items.Add(phone);
                string pattern = @"^\d{9}$";

                if (Regex.IsMatch(phone.ToString(), pattern))
                {
                    // Перевірка, чи існує вказаний ID_Employer
                    string queryCheckCitizen = "SELECT COUNT(*) FROM Citizen WHERE ID_Citizen = @ID_Citizen";
                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    {
                        SqlCommand commandCheckCitizen = new SqlCommand(queryCheckCitizen, connection);
                        commandCheckCitizen.Parameters.AddWithValue("@ID_Citizen", selectedCitizen.ID);
                        connection.Open();
                        int employerCount = (int)commandCheckCitizen.ExecuteScalar();

                        if (employerCount > 0)
                        {
                            string queryInsertPhone = "INSERT INTO Citizen_Phone (Phone, Comment, ID_Citizen) VALUES (@Phone, @Comment, @ID_Citizen)";
                            using (SqlCommand commandInsertPhone = new SqlCommand(queryInsertPhone, connection))
                            {
                                commandInsertPhone.Parameters.AddWithValue("@Phone", phone);
                                commandInsertPhone.Parameters.AddWithValue("@Comment", Comment.Text);
                                commandInsertPhone.Parameters.AddWithValue("@ID_Citizen", selectedCitizen.ID);
                                commandInsertPhone.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            MessageBox.Show("ID_Citizen не існує в таблиці Citizen", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Невірний формат номеру!", "Додавання номеру", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                text_phone.Text = "";
                Comment.Text = "";
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {

            if (phones_cit.SelectedItem != null)
            {
                string selectedPhone = phones_cit.SelectedItem.ToString();
                string query = $"DELETE FROM Citizen_Phone WHERE Phone = @Phone";

                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Phone", selectedPhone);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                phones_cit.Text = "";
                if (phones_cit.Items.Count > 0)
                {
                    int currentIndex = phones_cit.SelectedIndex;
                    phones_cit.Items.RemoveAt(currentIndex);
                    if (currentIndex < phones_cit.Items.Count)
                    {
                        phones_cit.SelectedIndex = currentIndex;
                    }
                    else if (phones_cit.Items.Count > 0)
                    {
                        phones_cit.SelectedIndex = currentIndex - 1;
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

        private void phones_cit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (phones_cit.SelectedIndex >= 0)
            {
                string selectedPhone = phones_cit.SelectedItem.ToString();
                if (phoneBook.ContainsKey(selectedPhone))
                {
                    Comment.Text = phoneBook[selectedPhone];
                }
            }
        }

        private void Comm_manage_Click(object sender, EventArgs e)
        {
            string comm = Comment.Text.Trim();
            string selectedPhone = phones_cit.SelectedItem.ToString();
            string query = "UPDATE Citizen_Phone SET Comment = @NewComm WHERE Phone = @Phone";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewComm", comm);
                command.Parameters.AddWithValue("@Phone", selectedPhone);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void but_name_Click(object sender, EventArgs e)
        {
            string name = name_text.Text.Trim();
            string query = "UPDATE Citizen SET Name = @Name WHERE ID_Citizen = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@ID", ID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void butt_sur_Click(object sender, EventArgs e)
        {
            string surname = surname_text.Text;
            if (!string.IsNullOrEmpty(surname))
            {
                int userId = selectedCitizen.ID;
                string query = "UPDATE Citizen SET Surname = @Surname WHERE ID_Citizen = @UserId";

                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Surname", surname);
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

        private void butt__Click(object sender, EventArgs e)
        {
            string adress = adress_text.Text.Trim();
            string query = "UPDATE Citizen SET Adress = @Adress WHERE ID_Citizen = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Adress", adress);
                command.Parameters.AddWithValue("@ID", ID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void checkInv_CheckedChanged(object sender, EventArgs e)
        {
            string query;

            if (checkInv.Checked)
            {
                query = "UPDATE Citizen SET Invalidity = 1 WHERE ID_Citizen = @ID";
            }
            else
            {
                query = "UPDATE Citizen SET Invalidity = 0 WHERE ID_Citizen = @ID";
            }
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void checkCrime_CheckedChanged(object sender, EventArgs e)
        {
            string query;
            if (checkCrime.Checked)
            {
                query = "UPDATE Citizen SET Criminal_record = 1 WHERE ID_Citizen = @ID";
            }
            else
            {
                query = "UPDATE Citizen SET Criminal_record = 0 WHERE ID_Citizen = @ID";
            }
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void butt_date_Click(object sender, EventArgs e)
        {
            // Отримати індекси обраних елементів ComboBox
            int yearIndex = year.FindStringExact(year.Text);
            int monthIndex = month.FindStringExact(month.Text);
            int dayIndex = day.FindStringExact(day.Text);

            // Перевірити, чи вибрані елементи знайдено
            if (yearIndex == -1 || monthIndex == -1 || dayIndex == -1)
            {
                MessageBox.Show("Будь ласка, введіть коректну дату.");
                return;
            }

            // Отримати значення з ComboBox для року, місяця і дня
            int year_cit = Convert.ToInt32(year.Items[yearIndex]);
            int month_cit = Convert.ToInt32(month.Items[monthIndex]);
            int day_cit = Convert.ToInt32(day.Items[dayIndex]);

            // Створити об'єкт DateTime з отриманими значеннями
            DateTime birthdate = new DateTime(year_cit, month_cit, day_cit);

            string query = "UPDATE Citizen SET [Birthdate] = @Birthdate WHERE ID_Citizen = @ID";
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Birthdate", birthdate);
                command.Parameters.AddWithValue("@ID", ID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void add_doc_radio_CheckedChanged(object sender, EventArgs e)
        {
            if(add_doc_radio.Checked)
            {
                Update_panel.Visible = false;
                panel1.BringToFront();
            }
            else if (update_doc_radio.Checked)
            {
                Update_panel.Visible = true;
                PopulateDocumentComboBox(ID);
                panel2.BringToFront();
            }
        }
        private void PopulateDocumentComboBox(int userID)
        {
            // Очищення ComboBox перед додаванням нових значень
            choose_doc.Items.Clear();

            // Запит для отримання документів певного користувача
            string query = "SELECT type_of_document, issue_date, document_number FROM Document WHERE ID_Citizen = @userID";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userID", userID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Додавання документів до ComboBox
                while (reader.Read())
                {
                    string type = reader["type_of_document"].ToString();
                    string documentInfo = $"{type}";
                    choose_doc.Items.Add(documentInfo);
                }

                // Закриття ридера
                reader.Close();
            }
        }
        private void add_doc_Click(object sender, EventArgs e)
        {
            if (year_doc.SelectedItem != null && day_doc.SelectedItem != null && month_doc.SelectedItem != null && type_doc.SelectedItem != null && !string.IsNullOrEmpty(number_doc.Text))
            {
                int year_of_birth = (int)year_doc.SelectedItem;
                int day_of_birth = (int)day_doc.SelectedItem;
                int month_of_birth = (int)month_doc.SelectedItem;
                DateTime issueDate = new DateTime(year_of_birth, month_of_birth, day_of_birth);

                // Перевірка на унікальність номеру документа
                if (!IsDocumentNumberUnique(number_doc.Text) && !IsDocumentTypeUnique(type_doc.SelectedItem.ToString()))
                {
                    string queryAddDoc = "INSERT INTO Document (type_of_document, issue_date, document_number, ID_Citizen) VALUES (@type_of_document, @issue_date, @document_number, @ID)";
                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(queryAddDoc, connection);
                        command.Parameters.AddWithValue("@type_of_document", type_doc.SelectedItem);
                        command.Parameters.AddWithValue("@issue_date", issueDate);
                        command.Parameters.AddWithValue("@document_number", number_doc.Text);
                        command.Parameters.AddWithValue("@ID", ID);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("Документ такого типу чи номеру вже існує.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Заповність усі поля", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool IsDocumentTypeUnique(string document_type)
        {
            string query = "SELECT COUNT(*) FROM Document WHERE type_of_document = @document_type And ID_Citizen = @id";
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@document_type", document_type);
                command.Parameters.AddWithValue("@id", ID);
                connection.Open();
                int count = (int)command.ExecuteScalar();

                // Якщо кількість документів з таким номером більше 0, то номер не унікальний
                return count > 0;
            }
        }
        private bool IsDocumentNumberUnique(string documentNumber)
        {
            string query = "SELECT COUNT(*) FROM Document WHERE document_number = @document_number";
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@document_number", documentNumber);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                // Якщо кількість документів з таким номером більше 0, то номер не унікальний
                return count > 0;
            }
        }
        private void choose_doc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Отримання вибраного рядка з ComboBox
            string selectedDocumentType = choose_doc.SelectedItem.ToString();

            // Запит для отримання додаткових даних про вибраний документ
            string query = "SELECT issue_date, document_number FROM Document WHERE ID_Citizen = @userID AND type_of_document = @documentType";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userID", ID);
                command.Parameters.AddWithValue("@documentType", selectedDocumentType);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Заповнення полів з даними про вибраний документ
                if (reader.Read())
                {
                    DateTime issueDate = Convert.ToDateTime(reader["issue_date"]);
                    string documentNumber = reader["document_number"].ToString();

                    // Встановлення значень у відповідні ComboBox та TextBox
                    year_doc_change.Text = issueDate.Year.ToString();
                    month_doc_change.Text = issueDate.Month.ToString();
                    day_doc_change.Text = issueDate.Day.ToString();
                    number_doc_change.Text = documentNumber;
                }

                // Закриття ридера
                reader.Close();
            }
        }

        private void update_doc_Click(object sender, EventArgs e)
        {
            if(choose_doc.SelectedIndex != -1 && !string.IsNullOrWhiteSpace(number_doc_change.Text))
            {
                // Отримати індекси обраних елементів ComboBox
                int yearIndex = year_doc_change.FindStringExact(year_doc_change.Text);
                int monthIndex = month_doc_change.FindStringExact(month_doc_change.Text);
                int dayIndex = day_doc_change.FindStringExact(day_doc_change.Text);

                // Перевірити, чи вибрані елементи знайдено
                if (yearIndex == -1 || monthIndex == -1 || dayIndex == -1)
                {
                    MessageBox.Show("Будь ласка, введіть коректну дату.");
                    return;
                }
                // Отримати значення з ComboBox для року, місяця і дня
                int year_doc = Convert.ToInt32(year_doc_change.Items[yearIndex]);
                int month_doc = Convert.ToInt32(month_doc_change.Items[monthIndex]);
                int day_doc = Convert.ToInt32(day_doc_change.Items[dayIndex]);

                // Створити об'єкт DateTime з отриманими значеннями
                DateTime date = new DateTime(year_doc, month_doc, day_doc);
                int ID_Document = GetDocumentID(choose_doc.SelectedItem.ToString());
                string query = "UPDATE Document SET [issue_date] = @Date,[document_number] = @Number WHERE ID_Document = @ID";
                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Number", number_doc_change.Text);
                    command.Parameters.AddWithValue("@ID", ID_Document);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("Оберіть документ7");
            }
        }
        private int GetDocumentID(string type)
        {
            // Отримати ID_Document обраного документа
            int ID_Document = 0;
            string query = "SELECT ID_Document FROM Document WHERE type_of_document = @type AND ID_Citizen = @UserID";
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@type", type);
                command.Parameters.AddWithValue("@UserID", ID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ID_Document = reader.GetInt32(0); 
                }
                reader.Close();
            }
            return ID_Document;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (choose_doc.SelectedItem != null)
            {
                // Отримати ID_Document обраного документа
                string selectedDocument = choose_doc.SelectedItem.ToString();
                int ID_Document = GetDocumentID(selectedDocument);

                if (ID_Document != -1)
                {
                    string query = "DELETE FROM Document WHERE ID_Document = @DocID";
                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@DocID", ID_Document);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Документ успішно видалено.");
                            choose_doc.Text = "";
                            year_doc_change.Text = "";
                            month_doc_change.Text = "";
                            day_doc_change.Text = "";
                            number_doc_change.Text = "";
                            // Оновити ComboBox з документами
                            PopulateDocumentComboBox(ID);

                        }
                        else
                        {
                            MessageBox.Show("Не вдалося видалити документ.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не вдалося знайти ID документа.");
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть документ для видалення.");
            }
        }

        private void Add_Education_CheckedChanged(object sender, EventArgs e)
        {
            if(Add_Education.Checked)
            {
                panel8.Visible = false;
                panel7.BringToFront();

            }
            else if(Update_Education.Checked)
            {
                panel8.Visible = true;
                panel8.BringToFront();
                AddEduc();
            }
        }

        private void Add_Educ_Click(object sender, EventArgs e)
        {
            string educ_type = text_Type.Text;
            string educ_numb = text_number.Text;

            if (!string.IsNullOrWhiteSpace(educ_type) && !string.IsNullOrWhiteSpace(educ_numb))
            {
                string query = "INSERT INTO Education (Education_type, Education_doc_number, ID_Citizen) VALUES (@EducType, @EducNumber, @ID_Citizen)";

                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EducType", educ_type);
                    command.Parameters.AddWithValue("@EducNumber", educ_numb);
                    command.Parameters.AddWithValue("@ID_Citizen", ID); 

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Дані освіти додано успішно.");
                        ClearEducationFields();
                        AddEduc();
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося додати дані освіти.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.");
            }
        }
        private void ClearEducationFields()
        {
            text_Type.Text = string.Empty;
            text_number.Text = string.Empty;
        }
        private void AddEduc()
        {
            combo_type.Items.Clear();

            string query = "SELECT Education_type FROM Education Where ID_Citizen = @id";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", ID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string educationType = reader["Education_type"].ToString();
                    combo_type.Items.Add(educationType);
                }
            }
        }

        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_type.SelectedItem != null)
            {
                string selectedType = combo_type.SelectedItem.ToString();

                string query = "SELECT Education_doc_number FROM Education WHERE Education_type = @Type AND ID_Citizen = @ID";

                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Type", selectedType);
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        textBox1.Text = result.ToString();
                    }
                    else
                    {
                        textBox1.Text = "";
                    }
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (combo_type.SelectedItem != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                string selectedType = combo_type.SelectedItem.ToString();
                string docNumber = textBox1.Text;

                string query = "SELECT COUNT(*) FROM Education WHERE Education_type = @Type AND Education_doc_number = @DocNumber AND ID_Citizen = @ID";

                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Type", selectedType);
                    command.Parameters.AddWithValue("@DocNumber", docNumber);
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    if (count == 0)
                    {
                        query = "UPDATE Education SET Education_doc_number = @DocNumber WHERE Education_type = @Type AND ID_Citizen = @ID";

                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@DocNumber", docNumber);
                        command.Parameters.AddWithValue("@Type", selectedType);
                        command.Parameters.AddWithValue("@ID", ID);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Номер документа про освіту оновлено");
                        }
                        else
                        {
                            MessageBox.Show("Не вдалося оновити номер документа про освіту.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Документ з таким типом та номером вже існує.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть тип освіти та введіть номер документа.");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (combo_type.SelectedItem != null)
            {
                string selectedType = combo_type.SelectedItem.ToString();

                string query = "DELETE FROM Education WHERE Education_type = @Type AND ID_Citizen = @ID";

                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Type", selectedType);
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Запис освіти видалено");
                        AddEduc();
                        combo_type.Text = "";
                        textBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося видалити запис освіти.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть запис для видалення.");
            }
        }
        private bool avoidEvent = false;

        private void skill_box_TextChanged(object sender, EventArgs e)
        {
            if (!avoidEvent)
            {
                string input = skill_box.Text;

                // Зберегти позицію курсора
                int selectionStart = skill_box.SelectionStart;
                int selectionLength = skill_box.SelectionLength;

                // Очистити список елементів
                skill_box.Items.Clear();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    // Виконати запит до бази даних, щоб отримати схожі записи
                    string query = "SELECT Skill FROM Skills WHERE Skill LIKE @input";
                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@input", "%" + input + "%");

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        // Додати схожі записи до ComboBox
                        while (reader.Read())
                        {
                            skill_box.Items.Add(reader["Skill"].ToString());
                        }
                    }
                }
                else
                {
                    // Виконати запит до бази даних, щоб отримати схожі записи
                    string query = "SELECT Skill FROM Skills";
                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        // Додати схожі записи до ComboBox
                        while (reader.Read())
                        {
                            skill_box.Items.Add(reader["Skill"].ToString());
                        }
                    }
                }

                // Встановити введений текст як вміст ComboBox
                avoidEvent = true; // Вимкнути подію, щоб уникнути зациклювання
                skill_box.Text = input;
                avoidEvent = false; // Увімкнути подію знову

                // Вибрати весь текст у ComboBox, щоб користувач міг продовжити введення
                skill_box.Select(selectionStart, selectionLength);
            }
        }
        private void Update_Skills()
        {
            string query = "SELECT Skill FROM Skills";
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string skill = reader.GetString(0);
                    skill_box.Items.Add(skill);
                }
                reader.Close();
            }
        }

        private void skill_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!avoidEvent)
            {
                avoidEvent = true; // Вимкнути подію, щоб уникнути зациклювання

                if (skill_box.SelectedItem.ToString() == "Додати")
                {
                    // Створення нового вікна
                    Form addSkillForm = new Form();
                    addSkillForm.Text = "Додати нову навичку";

                    Label label = new Label();
                    label.Text = "Введіть назву навички:";
                    label.Location = new Point(10, 10);
                    addSkillForm.Controls.Add(label);

                    System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
                    textBox.Location = new Point(10, 30);
                    addSkillForm.Controls.Add(textBox);

                    System.Windows.Forms.Button addButton = new System.Windows.Forms.Button();
                    addButton.Text = "Додати";
                    addButton.Location = new Point(10, 60);
                    addButton.Click += (s, ev) =>
                    {
                        if (!string.IsNullOrWhiteSpace(textBox.Text))
                        {

                            // Додати нову навичку до бази даних
                            AddNewSkill(textBox.Text);

                            // Оновити список навичок у ComboBox
                            Update_Skills();

                            addSkillForm.Close();
                        }
                        else
                        {
                            MessageBox.Show("Будь ласка, введіть назву навички.");
                        }
                    };
                    addSkillForm.Controls.Add(addButton);

                    addSkillForm.ShowDialog();
                }
                else
                {
                    skill_box.Text = skill_box.SelectedItem.ToString();
                }

                avoidEvent = false; // Увімкнути подію знову
            }
        }
        private void AddNewSkill(string newSkill)
        {
            string query = "INSERT INTO Skills (Skill) VALUES (@skill)";
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@skill", newSkill);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void button_sentSkill_Click(object sender, EventArgs e)
        {
            if(!(skill_box.SelectedIndex != -1))
            {
                return;
            }
            string selectedSkill = skill_box.SelectedItem.ToString();
            int skillID = GetSkillID(selectedSkill);

            if (skillID != -1)
            {
                if (!SkillExistsForCitizen(skillID))
                {
                    string query = "INSERT INTO Citizen_Skills (ID_Citizen, ID_Skill) VALUES (@ID, @SkillID)";

                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@ID", ID);
                        command.Parameters.AddWithValue("@SkillID", skillID);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Навичку успішно додано");
                            ShowCitizenSkills();
                            CItizen_skills_data.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                        else
                        {
                            MessageBox.Show("Не вдалося додати навичку.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Громадянин вже має цю навичку.");
                }
            }
            else
            {
                MessageBox.Show("Не вибрано навичку для додавання.");
            }
        }

        private bool SkillExistsForCitizen(int skillID)
        {
            string query = "SELECT COUNT(*) FROM Citizen_Skills WHERE ID_Citizen = @ID AND ID_Skill = @SkillID";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@SkillID", skillID);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }
        private int GetSkillID(string skill)
        {
            int skillID = -1;
            string query = "SELECT ID_Skill FROM Skills WHERE Skill = @Skill";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Skill", skill);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    skillID = reader.GetInt32(0);
                }

                reader.Close();
            }

            return skillID;
        }

        private void ShowCitizenSkills()
        {
            string query = "SELECT Skills.Skill FROM Citizen_Skills " +
                           "JOIN Skills ON Citizen_Skills.ID_Skill = Skills.ID_Skill " +
                           "WHERE ID_Citizen = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);

                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                CItizen_skills_data.DataSource = dataTable;
                CItizen_skills_data.Columns[0].HeaderText = "Навичка";
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CItizen_skills_data.Rows[e.RowIndex].Selected = true;
            }
        }
        private void Remove_skill_Click(object sender, EventArgs e)
        {
            if (CItizen_skills_data.SelectedRows.Count > 0)
            {
                string selectedSkill = CItizen_skills_data.SelectedRows[0].Cells[0].Value.ToString();
                int skillID = GetSkillID(selectedSkill);

                if (skillID != -1)
                {
                    string query = "DELETE FROM Citizen_Skills WHERE ID_Citizen = @ID AND ID_Skill = @SkillID";

                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@ID", ID);
                        command.Parameters.AddWithValue("@SkillID", skillID);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Навичку успішно видалено");
                            ShowCitizenSkills();
                        }
                        else
                        {
                            MessageBox.Show("Не вдалося видалити навичку.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Навичка не знайдена.");
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть у таблиці одну навичку для видалення.");
            }
        }

        private void add_skill_to_data_Click(object sender, EventArgs e)
        {
            string newSkill = skill_box.Text.Trim();

            if (!string.IsNullOrEmpty(newSkill))
            {
                if (!IsSkillExists(newSkill))
                {
                    AddSkill(newSkill);
                    Update_Skills();
                }
                else
                {
                    MessageBox.Show("Ця навичка вже існує!", "Помилка");
                }
            }
            else
            {
                MessageBox.Show("Введіть назву навички!", "Помилка");
            }
        }
        private void AddSkill(string skill)
        {
            string query = "INSERT INTO Skills (Skill) VALUES (@skill)";
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@skill", skill);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Навичку успішно додано!", "Інформація");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сталася помилка при додаванні навички:\n" + ex.Message, "Помилка");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedSkill = skill_box.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedSkill))
            {
                if (MessageBox.Show("Ви впевнені, що хочете видалити цю навичку?", "Видалення навички",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteSkill(selectedSkill);
                    Update_Skills();
                }
            }
            else
            {
                MessageBox.Show("Виберіть навичку для видалення!", "Помилка");
            }
        }
        private void DeleteSkill(string skill)
        {
            string deleteCitizenSkillsQuery = "DELETE FROM Citizen_Skills WHERE ID_Skill = (SELECT ID_Skill FROM Skills WHERE Skill = @skill)";
            string deleteSkillQuery = "DELETE FROM Skills WHERE Skill = @skill";

            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(deleteCitizenSkillsQuery, connection);
                command.Parameters.AddWithValue("@skill", skill);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сталася помилка при видаленні навички з таблиці Citizen_Skills:\n" + ex.Message, "Помилка");
                    return;
                }

                command.CommandText = deleteSkillQuery;

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Навичку успішно видалено!", "Інформація");
                    }
                    else
                    {
                        MessageBox.Show("Навичку не видалено. Вона відсутня в базі даних.", "Помилка");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сталася помилка при видаленні навички з таблиці Skills:\n" + ex.Message, "Помилка");
                }
            }
        }
        private bool IsSkillExists(string skill)
        {
            string query = "SELECT COUNT(*) FROM Skills WHERE Skill = @skill";
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@skill", skill);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void Redact_Form_cit_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені, що хочете закрити вікно?", "Закриття програми", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Відміна закриття форми
            }
            else if (result == DialogResult.Yes)
            {
                Manage_Person mp = (Manage_Person)Application.OpenForms["Manage_Person"];
                if (mp != null)
                {
                    mp.Enabled = true;
                    mp.Focus(); // Фокусуємося на формі Form1
                }
            }
        }
    }
}
