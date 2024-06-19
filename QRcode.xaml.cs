using MessagingToolkit.QRCode.Codec;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace testik1212
{
    public partial class QRcode : Window
    {
        string saveResult;
        public QRcode()
        {
            InitializeComponent();
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
    }
}
