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

namespace testik1212
{
    public partial class Registration : Window
    {
        static private MySqlConnection conn;
        private string connstring = ("Server=localhost; Port=3306; Database=business_meds; Username=root; Password=123456");
        public Registration()
        {
            InitializeComponent();
            gender.Items.Add("мужской");
            gender.Items.Add("женский");
        }
        private void enter_data(object sender, RoutedEventArgs e)
        {
            int gend = 0;
            if (med_card.Text != "" && name.Text != "" && subname.Text != "" && thirdname.Text != "" && gender.Text != "" && address.Text != "" && phone.Text != "" && email.Text != "")
            {
                try
                {
                    conn = new MySqlConnection(connstring);
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO patients(name, subname, thirdname, gender, address, phone_number, email, medical_card ) VALUES" +
                    "(@pn, @ps, @pt, @pg, @pa, @pp, @pe, @pmed )"; // или patients вместо databaseSource

                    if (gender.Text == "мужской")
                    {
                        gend = 1;
                    }
                    else
                    {
                        gend = 2;
                    }

                    cmd.Parameters.Add("@pn", MySqlDbType.VarChar).Value = name.Text;
                    cmd.Parameters.Add(@"ps", MySqlDbType.VarChar).Value = subname.Text;
                    cmd.Parameters.Add(@"pt", MySqlDbType.VarChar).Value = thirdname.Text;
                    cmd.Parameters.Add(@"pg", MySqlDbType.VarChar).Value = gend;
                    cmd.Parameters.Add(@"pa", MySqlDbType.VarChar).Value = address.Text;
                    cmd.Parameters.Add(@"pp", MySqlDbType.VarChar).Value = phone.Text;
                    cmd.Parameters.Add(@"pe", MySqlDbType.VarChar).Value = email.Text;
                    cmd.Parameters.Add(@"pmed", MySqlDbType.VarChar).Value = med_card.Text;

                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Пользователь {name.Text} {subname.Text} {thirdname.Text} сохранён!");

                    name.Text = "";
                    subname.Text = "";
                    thirdname.Text = "";
                    gend = 0;
                    gender.Text = "";
                    address.Text = "";
                    phone.Text = "";
                    email.Text = "";
                    med_card.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Хм..." + ex, "\n\rТакая вот ошибка");
                }
            }
            else { MessageBox.Show("Не заполнены все поля!"); }
        }
        private void ShowPatientsList(object sender, RoutedEventArgs e)
        {
            MainWindow list_patients = new MainWindow();
            list_patients.Show();
        }
        private void search_patients(object sender, RoutedEventArgs e)
        {

        }
    }
}
