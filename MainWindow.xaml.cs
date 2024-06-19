using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySqlX.XDevAPI.Common;
using Mysqlx.Sql;
using System.Data.SqlClient;
using System.Transactions;

namespace testik1212
{
    public class Patient
    {
        public string MedicalCard { get; set; }
        public string Name { get; set; }
        public string SubName { get; set; }
        public string ThirdName { get; set; }
        public string Gender { get; set; } //число
        public string Date_of_BIFTH { get; set; }
        public string Address { get; set; }
        public string Seria_and_Number { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
        public Image Photo { get; set; }
        public string SNILS { get; set; }
        public string SNILS_DATE_OVER { get; set; }
        public string DATA_LAST_REQUEST { get; set; }
        public string DATA_NEXT_REQUEST { get; set; }
        public string medical_type_event { get; set; }
    }
    public partial class MainWindow : Window
    {
        static private MySqlConnection conn;
        private string connstring = ("Server=localhost; Port=3306; Database=business_meds; Username=root; Password=123456");
        public MainWindow()
        {

            InitializeComponent();

            conn = new MySqlConnection(connstring);

            Vivod();
        }
        public void Vivod()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connstring))
                {
                conn.Open();

                string sql = "SELECT * FROM patients";

                List<Patient> patients = new List<Patient>();

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Patient patient = new Patient
                            {
                                MedicalCard = reader["Номер медицинской карты пациента"].ToString(),
                                Name = reader["Имя"].ToString(),
                                SubName = reader["Фамилия"].ToString(),
                                ThirdName = reader["Отчество"].ToString(),
                                Gender = reader["Пол пациента"].ToString(),
                                //Date_of_BIFTH = reader["date_of_BIFTH"].ToString(),
                                Address = reader["Адрес пациента"].ToString(),
                                //Seria_and_Number = reader["seria_and_number"].ToString(),
                                Phone_number = reader["Телефонный номер пациента"].ToString(),
                                Email = reader["Электронный адрес пациента"].ToString(),
                                //фото пропуск
                                SNILS = reader["Номер страхового полиса пациента"].ToString(),
                                SNILS_DATE_OVER = reader["Дата окончания действия страхового полиса пациента"].ToString(),
                                DATA_LAST_REQUEST = reader["Дата последнего обращения пациента в медицинское учреждение"].ToString(),
                                DATA_NEXT_REQUEST = reader["Дата следующего назначенного визита пациента"].ToString(),
                                //medical_type_event = reader["medical_type_event"].ToString(),
                            };
                            patients.Add(patient);
                        }
                    }
                }
                    myDataGrid.ItemsSource = patients;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message + "\n\rТакие вот дела...");
            }
        }

        private void Vivod(object sender, RoutedEventArgs e)
        {
            Vivod();
            
        }
    }
}