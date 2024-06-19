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
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using MessagingToolkit.QRCode.Codec;
using System.Drawing;
using System.IO;
using Microsoft.Win32;
using MessagingToolkit.QRCode.Codec.Data;
using static testik1212.WorkSpace;

namespace testik1212
{
    public class SearchPatient
    {
        public string MedicalCard { get; set; }
        public string Name { get; set; }
        public string SubName { get; set; }
        public string ThirdName { get; set; }
        public string Gender { get; set; } //число
        public string Address { get; set; }
        public string Phone_number { get; set; }
        public string Email { get; set; }
        public string CREATE_medical_card_DATA { get; set; }
        //public Image Photo { get; set; }
        public string SNILS { get; set; }
        public string SNILS_DATE_OVER { get; set; }
        public string DATA_LAST_REQUEST { get; set; }
        public string DATA_NEXT_REQUEST { get; set; }
        public string medical_type_event { get; set; }
    }
    public partial class WorkSpace : Window
    {
        string saveResult;
        static private MySqlConnection conn;
        private string connstring = ("Server=localhost; Port=3306; Database=business_meds; Username=root; Password=123456");
        public WorkSpace()
        {
            InitializeComponent();
            Hide_Windows();
            gender.Items.Add("мужской");
            gender.Items.Add("женский");
        }
        private void Register_Patient(object sender, RoutedEventArgs e)
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
                    "(@pn, @ps, @pt, @pg, @pa, @pp, @pe, @pmed )";

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

        private void OnRegistrationClicked(object sender, RoutedEventArgs e)
        {
            RegPatient.Visibility = Visibility.Visible;
            Gospitalization.Visibility = Visibility.Hidden;
            QR_zone.Visibility = Visibility.Hidden;
        }
        public void Hide_Windows()
        {
            Work_Space.Visibility = Visibility.Visible;
            RegPatient.Visibility = Visibility.Hidden;
            Gospitalization.Visibility = Visibility.Hidden;
            QR_zone.Visibility = Visibility.Hidden;
        }

        private void OnSearch_PatientClicked(object sender, RoutedEventArgs e)
        {
            if (searcher_patient.Text != null && searcher_patient.Text.Length > 1)
            {
                try
                {
                    conn = new MySqlConnection(connstring);
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "SELECT * FROM patients WHERE name = @sp;";
                    cmd.Parameters.Add("@sp", MySqlDbType.VarChar).Value = searcher_patient.Text;

                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<SearchPatient> list_patients = new List<SearchPatient>(); // Move this line outside the while loop

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SearchPatient patient = new SearchPatient
                            {
                                MedicalCard = reader["medical_card"].ToString(),
                                Name = reader["name"].ToString(),
                                SubName = reader["subname"].ToString(),
                                ThirdName = reader["thirdname"].ToString(),
                                Gender = reader["gender"].ToString(),
                                Address = reader["address"].ToString(),
                                Phone_number = reader["phone_number"].ToString(),
                                Email = reader["email"].ToString(),
                                CREATE_medical_card_DATA = reader["CREATE_medical_card_DATA"].ToString(),
                                SNILS = reader["SNILS"].ToString(),
                                SNILS_DATE_OVER = reader["SNILS_DATE_OVER"].ToString(),
                                DATA_LAST_REQUEST = reader["DATA_LAST_REQUEST"].ToString(),
                                DATA_NEXT_REQUEST = reader["DATA_NEXT_REQUEST"].ToString(),
                            };
                            list_patients.Add(patient);
                        }
                        result_searcher.ItemsSource = list_patients;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Хм..." + ex, "\n\rТакая вот ошибка");
                }
            }
            else { MessageBox.Show("Неверное заполнение."); }
        }

        private void OnList_PatientsClicked(object sender, RoutedEventArgs e)
        {
            //MainWindow list_patients = new MainWindow();
            //list_patients.Show();
        }
        private void IsGospitalizeClicked(object sender, RoutedEventArgs e)
        {
            RegPatient.Visibility = Visibility.Hidden;
            Gospitalization.Visibility = Visibility.Visible;
            QR_zone.Visibility = Visibility.Hidden;
        }
        private void ScanQR(object sender, RoutedEventArgs e)
        {
            RegPatient.Visibility = Visibility.Hidden;
            Gospitalization.Visibility = Visibility.Hidden;
            QR_zone.Visibility = Visibility.Visible;
        }
        private void Encode(object sender, RoutedEventArgs e)
        {
            if (QR_encode.Text != "")
            {
                string qrtext = QR_encode.Text;
                QRCodeEncoder encoder = new QRCodeEncoder();
                Bitmap qrcode = encoder.Encode(qrtext, Encoding.UTF8);

                MemoryStream memoryStream = new MemoryStream();
                qrcode.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

                memoryStream.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                QR_image.Source = bitmapImage;

                QR_encode.Text = null;
                saveResult = qrtext;
                QR_result.Content = saveResult;
            }
            else
            {
                QR_result.Content = "Поле пустое!";
            }
        }
        private void Decode(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;

                //Загрузка QR-кода изображения
                Bitmap qrCodeBitmap = new Bitmap(filename);
                QRCodeDecoder decoder = new QRCodeDecoder();
                string decodedText = decoder.decode(new QRCodeBitmapImage(qrCodeBitmap), Encoding.UTF8);

                //Отображение распознанного текста
                MessageBox.Show("Распознанный текст: " + decodedText);
                QR_result.Content = decodedText;
            }
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            if (QR_image.Source != null)
            {
                try
                {
                    var encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)QR_image.Source));

                    string fullPath = System.IO.Path.GetFullPath(@"QR_codes\" + saveResult + ".png");
                    using (var stream = File.Create(fullPath))
                        encoder.Save(stream);

                    MessageBox.Show($"Успешно загружено по пути:\n{fullPath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Хм...\n" + ex, "\n\rТакая вот ошибка");
                }
            }
            else
            {
                QR_result.Content = "Для начала создайте QR код!";
            }
        }
        private void searcher_patient_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searcher_patient.Text != null)
            {
                try
                {
                    conn = new MySqlConnection(connstring);
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "SELECT * FROM patients WHERE name like @sp;";
                    cmd.Parameters.Add("@sp", MySqlDbType.VarChar).Value = "%" + searcher_patient.Text + "%";

                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<SearchPatient> list_patients = new List<SearchPatient>(); // Move this line outside the while loop

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SearchPatient patient = new SearchPatient
                            {
                                MedicalCard = reader["medical_card"].ToString(),
                                Name = reader["name"].ToString(),
                                SubName = reader["subname"].ToString(),
                                ThirdName = reader["thirdname"].ToString(),
                                Gender = reader["gender"].ToString(),
                                Address = reader["address"].ToString(),
                                Phone_number = reader["phone_number"].ToString(),
                                Email = reader["email"].ToString(),
                                CREATE_medical_card_DATA = reader["CREATE_medical_card_DATA"].ToString(),
                                SNILS = reader["SNILS"].ToString(),
                                SNILS_DATE_OVER = reader["SNILS_DATE_OVER"].ToString(),
                                DATA_LAST_REQUEST = reader["DATA_LAST_REQUEST"].ToString(),
                                DATA_NEXT_REQUEST = reader["DATA_NEXT_REQUEST"].ToString(),
                            };
                            list_patients.Add(patient);
                        }
                        result_searcher.ItemsSource = list_patients;
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Хм..." + ex, "\n\rТакая вот ошибка");
                    Console.WriteLine(ex);
                }
            }
            else { MessageBox.Show("Неверное заполнение."); }
        }
    }
}
