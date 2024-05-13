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

namespace Kursova
{
    public partial class Registration : Form
    {
        DataBase dataBase = new DataBase();
        public Registration()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            password_text.PasswordChar = '*';
            rep_pas.PasswordChar = '*';
            login_text.MaxLength = 255;
            password_text.MaxLength = 255;
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void reg_button_Click(object sender, EventArgs e)
        {
            string login = login_text.Text;
            string password = password_text.Text;
            string rep_password = rep_pas.Text;

            if((password == rep_password) && (!CheckUser(login, password)))
            {
                MessageBox.Show("Помилка реєстрації", "Реєстрація", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string query_str = $"insert into Accounts(login, password) values ('{login}', '{password}')";

                SqlCommand command = new SqlCommand(query_str, dataBase.getConnection());

                dataBase.openConnection();
                if(command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Ви зареєструвалися", "Реєстрація", MessageBoxButtons.OK);
                    Log_in lg = new Log_in();
                    lg.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Помилка реєстрації", "Реєстрація", MessageBoxButtons.OK);
                }
                dataBase.closeConnection();
            }                      
        }
        private bool CheckUser(string log, string pas)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query_str = $"select id_acc, login, password from Accounts where login = '{log}' and password = '{pas}'";
            SqlCommand comm = new SqlCommand(query_str, dataBase.getConnection());
            adapter.SelectCommand = comm;
            adapter.Fill(table);
            if (table.Rows.Count > 1)
            {
                MessageBox.Show("Цей користувач вже існує", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
