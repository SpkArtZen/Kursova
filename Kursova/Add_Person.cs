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
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SqlTypes;

namespace Kursova
{
    public partial class Add_Person : Form
    {
        List<string> phone_emp_list = new List<string>();
        List<string> phone_cit_list = new List<string>();
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=ACER;Initial Catalog=Vacantion_kursosva;Integrated Security=True");
        DataBase dataBase = new DataBase();
        Dictionary<string, string> phoneBook_emp = new Dictionary<string, string>();
        Dictionary<string, string> phoneBook_cit = new Dictionary<string, string>();
        public Add_Person()
        {
            InitializeComponent();

            phone_emp_text.MaxLength = 10;
            Citizen_phone_box.MaxLength = 10;
            Citizen_richBox.ReadOnly = true;
            Citizen_panel.Visible = true;
            Employer_panel.BackColor = Color.FromArgb(255, 255, 255, 255);
            year.MaxLength = 4;
            day.MaxLength = 2;
            month.MaxLength = 2;
            // Додати роки в ComboBox для років

            Task.Run(() =>
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        for (int i = DateTime.Now.Year; i >= 1900; i--)
                        {
                            year.Items.Add(i);
                        }
                        for (int i = 1; i <= 12; i++)
                        {
                            month.Items.Add(i);
                        }
                        // Додати дні в ComboBox для днів (в залежності від обраного місяця та року)
                        month.SelectedIndexChanged += (sender, e) => UpdateDays();

                        year.SelectedIndexChanged += (sender, e) => UpdateDays();

                        UpdateDays(); // Оновити список днів для поточного місяця та року
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

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
                }
            }

        }
        private void Add_Person_FormClosing(object sender, FormClosingEventArgs e)
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


        private void check_employer_CheckedChanged(object sender, EventArgs e)
        {
            if (check_citizen.Checked)
            {
                Employer_panel.Visible = false;
                Citizen_panel.Visible = true;
                phone_list_emp.ReadOnly = true;
                Citizen_panel.BringToFront();
            }
            else if (check_employer.Checked)
            {
                Citizen_panel.Visible = true;
                Employer_panel.Visible = true;
                phone_list_emp.ReadOnly = true;
                Employer_panel.BringToFront();
                Employer_panel.BackColor = Color.FromArgb(0, 255, 255, 255);
                Employer_panel.BackColor = SystemColors.GradientInactiveCaption;
            }
        }

        private void addphone_Click(object sender, EventArgs e)
        {
            string phone = phone_emp_text.Text;
            string comment = comment_box.Text;
            bool is_Numeric = int.TryParse(phone, out _);
            // Регулярний вираз для перевірки, чи містить рядок рівно 10 цифр
            string pattern = @"^\d{10}$";
            if ((Check_phone_number(phone) && is_Numeric && Regex.IsMatch(phone, pattern)))
            {
                // Шукаємо порожній рядок для вставки нового номера
                int emptyLineIndex = -1;
                for (int i = 0; i < phone_list_emp.Lines.Length; i++)
                {
                    if (string.IsNullOrEmpty(phone_list_emp.Lines[i]))
                    {
                        emptyLineIndex = i;
                        break;
                    }
                }

                // Вставляємо новий номер на знайдене місце
                if (emptyLineIndex != -1)
                {
                    // Додаємо новий номер телефону та коментар до списку
                    phone_emp_list.Add(phone);
                    phoneBook_emp[phone] = comment;

                    Task.Run(() =>
                    {
                        try
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                StringBuilder newText = new StringBuilder();
                                for (int i = 0; i < phone_list_emp.Lines.Length; i++)
                                {
                                    if (i != emptyLineIndex)
                                        newText.AppendLine(phone_list_emp.Lines[i]);
                                    else
                                        newText.AppendLine(phone + "\t" + comment);
                                }
                                phone_list_emp.Text = newText.ToString();
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    });

                    phone_emp_text.Text = "";
                    comment_box.Text = "";
                }
                else
                {
                    phone_emp_list.Add(phone);
                    phoneBook_emp[phone] = comment;

                    Task.Run(() =>
                    {
                        try
                        {
                            BeginInvoke((MethodInvoker)delegate
                            {
                                phone_list_emp.AppendText(phone + "\t" + comment + "\n");
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    });

                    phone_emp_text.Text = "";
                    comment_box.Text = "";

                }
            }
            else
            {
                MessageBox.Show("Некоректний номер телефону!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool Check_phone_number(string phone)
        {
            foreach (string s in phone_emp_list)
            {
                if (s == phone)
                {
                    return false;
                }
            }
            return true;
        }

        private void add_Employer_Click(object sender, EventArgs e)
        {

            string name = name_employer_text_box.Text;
            string email = emp_email.Text;
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(email))
            {
                if (!Regex.IsMatch(email, emailPattern))
                {
                    MessageBox.Show("Некоректно введена пошта", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!CheckEmployerEmail(email))
                {
                    string query_str = $"insert into Employer(Name_employer, email) OUTPUT INSERTED.ID_Employer values ('{name}', '{email}')";
                    SqlCommand command = new SqlCommand(query_str, dataBase.getConnection());
                    dataBase.openConnection();
                    int employerID = Convert.ToInt32(command.ExecuteScalar()); // Отримання ID_Employer
                    dataBase.closeConnection();

                    foreach (string phone in phone_emp_list)
                    {
                        if (!CheckEmployerPhone(phone))
                        {
                            return;
                        }
                        else
                        {
                            query_str = $"INSERT INTO Phone (Phone, Comment, ID_Employer) VALUES ('{phone}', '{phoneBook_emp[phone]}', {employerID})";
                            command = new SqlCommand(query_str, dataBase.getConnection());
                            dataBase.openConnection();
                            command.ExecuteNonQuery();
                            dataBase.closeConnection();
                        }
                    }
                    MessageBox.Show("Роботодавець зареєструвався", "Реєстрація", MessageBoxButtons.OK);
                    name_employer_text_box.Clear();
                    emp_email.Clear();
                    phone_emp_list.Clear();
                    phoneBook_emp.Clear();
                    phone_list_emp.Clear();

                }
                else
                {
                    MessageBox.Show("Роботодавець з такою електронною поштою вже існує", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    emp_email.Clear();
                    phone_emp_list.Clear();
                    phoneBook_emp.Clear();
                    phone_list_emp.Clear();
                }
            }

        }
        private bool CheckEmployerEmail(string email)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query_str = $"SELECT * FROM Employer WHERE email = '{email}'";
            SqlCommand comm = new SqlCommand(query_str, dataBase.getConnection());
            adapter.SelectCommand = comm;
            adapter.Fill(table);

            // Перевірка, чи таблиця порожня
            if (table.Rows.Count == 0)
            {
                return false;
            }

            return true;
        }
        private bool CheckEmployerPhone(string phone)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query_str = $"select Phone, Comment, ID_Employer from Phone where Phone = '{phone}'";
            SqlCommand comm = new SqlCommand(query_str, dataBase.getConnection());
            adapter.SelectCommand = comm;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show($"Телефон {phone} вже зареєстровано на роботодавця", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void remove_phone_Click(object sender, EventArgs e)
        {
            phone_list_emp.ReadOnly = false;

            // Отримуємо індекс рядка, на якому знаходиться курсор
            int lineIndex = phone_list_emp.GetLineFromCharIndex(phone_list_emp.SelectionStart);

            string selectedText = phone_list_emp.Lines[lineIndex];

            if (!string.IsNullOrEmpty(selectedText))
            {
                phone_list_emp.SelectedText = "";
                phone_emp_list.Remove(selectedText);

                if (phoneBook_emp.ContainsKey(selectedText))
                {
                    phoneBook_emp.Remove(selectedText);
                }
                // Зміщуємо вміст усіх наступних рядків вгору на один рядок
                Task.Run(() =>
                {
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            StringBuilder newText = new StringBuilder();
                            for (int i = 0; i < phone_list_emp.Lines.Length; i++)
                            {
                                if (i != lineIndex)
                                    newText.AppendLine(phone_list_emp.Lines[i]);
                            }
                            phone_list_emp.Text = newText.ToString();
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

            phone_list_emp.ReadOnly = true;

        }
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Отримуємо індекс рядка, на якому знаходиться курсор
                int lineIndex = phone_list_emp.GetLineFromCharIndex(phone_list_emp.SelectionStart);

                // Перевіряємо, чи не є поточний рядок порожнім
                if (string.IsNullOrWhiteSpace(phone_list_emp.Lines[lineIndex]))
                {
                    // Видаляємо порожній рядок перед додаванням нового значення
                    phone_list_emp.Text = phone_list_emp.Text.Remove(phone_list_emp.GetFirstCharIndexFromLine(lineIndex), phone_list_emp.Lines[lineIndex].Length + 1);
                }
            }
        }
        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Отримуємо індекс символа за допомогою координат миші
            int charIndex = phone_list_emp.GetCharIndexFromPosition(e.Location);
            // Отримуємо номер рядка, на якому знаходиться цей символ
            int lineIndex = phone_list_emp.GetLineFromCharIndex(charIndex);
            // Отримуємо початковий і кінцевий індекси рядка
            int lineStart = phone_list_emp.GetFirstCharIndexFromLine(lineIndex);
            int lineEnd = phone_list_emp.GetFirstCharIndexFromLine(lineIndex + 1);
            // Виділяємо весь рядок
            phone_list_emp.Select(lineStart, lineEnd - lineStart);
        }

        private void Add_cit_phone_Click(object sender, EventArgs e)
        {
            string phone = Citizen_phone_box.Text;
            string comment = Citizen_comment.Text;
            bool is_Numeric = int.TryParse(phone, out _);
            // Регулярний вираз для перевірки, чи містить рядок рівно 10 цифр
            string pattern = @"^\d{10}$";
            if ((Check_phone_number_Citizen(phone) && is_Numeric && Regex.IsMatch(phone, pattern)))
            {
                // Шукаємо порожній рядок для вставки нового номера
                int emptyLineIndex = -1;
                for (int i = 0; i < Citizen_richBox.Lines.Length; i++)
                {
                    if (string.IsNullOrEmpty(Citizen_richBox.Lines[i]))
                    {
                        emptyLineIndex = i;
                        break;
                    }
                }

                // Вставляємо новий номер на знайдене місце
                if (emptyLineIndex != -1)
                {
                    // Додаємо новий номер телефону та коментар до списку
                    phone_cit_list.Add(phone);
                    phoneBook_cit[phone] = comment;

                    Task.Run(() =>
                    {
                        try
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                StringBuilder newText = new StringBuilder();
                                for (int i = 0; i < Citizen_richBox.Lines.Length; i++)
                                {
                                    if (i != emptyLineIndex)
                                        newText.AppendLine(Citizen_richBox.Lines[i]);
                                    else
                                        newText.AppendLine(phone + "\t" + comment);
                                }
                                Citizen_richBox.Text = newText.ToString();
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    });

                    Citizen_phone_box.Text = "";
                    Citizen_comment.Text = "";
                }
                else
                {
                    phone_cit_list.Add(phone);
                    phoneBook_cit[phone] = comment;

                    Task.Run(() =>
                    {
                        try
                        {
                            BeginInvoke((MethodInvoker)delegate
                            {
                                Citizen_richBox.AppendText(phone + "\t" + comment + "\n");
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    });

                    Citizen_phone_box.Text = "";
                    Citizen_comment.Text = "";

                }
            }
            else
            {
                MessageBox.Show("Некоректний номер телефону!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool Check_phone_number_Citizen(string phone)
        {
            foreach (string s in phone_cit_list)
            {
                if (s == phone)
                {
                    return false;
                }
            }
            return true;
        }

        private void Remove_cit_phone_Click(object sender, EventArgs e)
        {
            Citizen_richBox.ReadOnly = false;

            // Отримуємо індекс рядка, на якому знаходиться курсор
            int lineIndex = Citizen_richBox.GetLineFromCharIndex(Citizen_richBox.SelectionStart);

            string selectedText = Citizen_richBox.Lines[lineIndex];

            if (!string.IsNullOrEmpty(selectedText))
            {
                Citizen_phone_box.SelectedText = "";
                phone_cit_list.Remove(selectedText);

                if (phoneBook_cit.ContainsKey(selectedText))
                {
                    phoneBook_cit.Remove(selectedText);
                }
                // Зміщуємо вміст усіх наступних рядків вгору на один рядок
                Task.Run(() =>
                {
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            StringBuilder newText = new StringBuilder();
                            for (int i = 0; i < Citizen_richBox.Lines.Length; i++)
                            {
                                if (i != lineIndex)
                                    newText.AppendLine(Citizen_richBox.Lines[i]);
                            }
                            Citizen_richBox.Text = newText.ToString();
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

            Citizen_richBox.ReadOnly = true;
        }

        private void Add_Citizen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Adress.Text) && string.IsNullOrEmpty(name_Citizen.Text) && string.IsNullOrEmpty(surname_Citizen.Text) && year.SelectedItem == null && month.SelectedItem == null && day.SelectedItem == null)
            {
                MessageBox.Show("Заповніть усі порожні поля!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string name_cit = name_Citizen.Text;
                string surname_cit = surname_Citizen.Text;
                string adress = Adress.Text;
                int year_of_birth = (int)year.SelectedItem;
                int day_of_birth = (int)day.SelectedItem;
                int month_of_birth = (int)month.SelectedItem;
                int invalid = 0;
                int crime = 0;
                if (Invalidity.Checked == true)
                {
                    invalid = 1;
                }
                if (Crimely.Checked == true)
                {
                    crime = 1;
                }
                string birthDate = $"{year_of_birth:0000}-{month_of_birth:00}-{day_of_birth:00}";
                string query_str = $"insert into Citizen(Name, Surname, Birthdate, Adress, " +
                    $"Invalidity, Criminal_record) OUTPUT INSERTED.ID_Citizen values " +
                    $"('{name_cit}', '{surname_cit}', '{birthDate}','{adress}','{invalid}','{crime}')";
                SqlCommand command = new SqlCommand(query_str, dataBase.getConnection());
                dataBase.openConnection();
                int citizenID = Convert.ToInt32(command.ExecuteScalar());
                dataBase.closeConnection();


                foreach (string phone in phone_cit_list)
                {
                    if (!CheckCitizenPhone(phone))
                    {
                        MessageBox.Show($"Увага, номер {phone} не було додано!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        query_str = $"INSERT INTO Citizen_phone (Phone, Comment, ID_Citizen) VALUES ('{phone}', '{phoneBook_cit[phone]}', {citizenID})";
                        command = new SqlCommand(query_str, dataBase.getConnection());
                        dataBase.openConnection();
                        command.ExecuteNonQuery();
                        dataBase.closeConnection();
                       
                    }
                }
                name_Citizen.Clear();
                surname_Citizen.Clear();
                Adress.Clear();
                Invalidity.Checked = false;
                Crimely.Checked = false;
                phone_cit_list.Clear();
                phoneBook_cit.Clear();
                Citizen_richBox.Clear();
                year.Items.Clear();
                day.Items.Clear();
                month.Items.Clear();    
            }
        }
        private bool CheckCitizenPhone(string phone)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query_str = $"SELECT * FROM Citizen_phone WHERE Phone = '{phone}'";
            SqlCommand comm = new SqlCommand(query_str, dataBase.getConnection());
            adapter.SelectCommand = comm;
            adapter.Fill(table);

            // Перевірка, чи таблиця порожня
            if (table.Rows.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}