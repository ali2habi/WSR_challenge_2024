using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Authentication;

namespace testik1212
{
    public partial class Auth : Window
    {
        static private MySqlConnection conn;
        private string connstring = ("Server=localhost; Port=3306; Database=business_meds; Username=root; Password=123456");
        public Auth()
        {
            InitializeComponent();
            WorkSpace.Visibility = Visibility.Hidden;
        }
        private void TryLogin(object sender, RoutedEventArgs e)
        {
            if ((login.Text != null && login.Text.Length > 0) && (password.Password != null && password.Password.Length > 0))
            {
                try
                {
                    string sql = "SELECT * FROM vrach";
                    conn = new MySqlConnection(connstring);
                    conn.Open();
                    
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT login, password FROM vrach WHERE login = @uL AND password = @uP;";

                    cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login.Text;
                    cmd.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password.Password;

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string storedLogin = reader["login"].ToString();
                            string storedPassword = reader["password"].ToString();

                            if (storedLogin == login.Text && storedPassword == password.Password)
                            {
                                //AuthGrid.Visibility = Visibility.Hidden;
                                WorkSpace workspace = new WorkSpace();
                                workspace.Show();
                                this.Close();
                                //WorkSpace.Visibility = Visibility.Visible;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Пароль {password.Password} или {login.Text} не подходит!");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка:\n" + ex);
                }
            }
            else
            {
                MessageBox.Show("Не заполнены поля!");
            }
        }
    }
}
