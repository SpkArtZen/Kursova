using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursova
{
    public partial class Log_in : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=ACER;Initial Catalog=Vacantion_kursosva;Integrated Security=True");
        DataBase dataBase = new DataBase();
        public Log_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            to_reg.Font = new Font(to_reg.Font, FontStyle.Underline);
        }

        private void Log_in_Load(object sender, EventArgs e)
        {
            password_text.PasswordChar = '*';
            login_text.MaxLength = 255;
            password_text.MaxLength = 255;
            
        }
        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
        private void enter_button_Click(object sender, EventArgs e)
        {
            string loginUser = login_text.Text;
            string passwordUser = password_text.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query_str = $"select id_acc, login, password from Accounts where login = '{loginUser}' and password = '{passwordUser}'";
            SqlCommand comm = new SqlCommand(query_str, dataBase.getConnection());
            adapter.SelectCommand = comm;
            adapter.Fill(table);
            if(table.Rows.Count >= 1) 
            {
                MessageBox.Show("Ви увійшли до аккаунту!", "Вхід", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 frm1 = new Form1();
                this.Hide();
                frm1.ShowDialog();                
            }
            else
            {

                MessageBox.Show("Помилка входу до аккаунту!", "Вхід", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void to_reg_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Hide();
        }
    }
}
