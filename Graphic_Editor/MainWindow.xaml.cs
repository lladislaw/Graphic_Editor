using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;




namespace Graphic_Editor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
      
        }



        private void button_open_image_Click(object sender, RoutedEventArgs e)
        {
            /* OpenFileDialog openFileDialog = new OpenFileDialog();

             openFileDialog.Filter = "All files (*.*)|*.*|PNG (*.png)|*.png|JPG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp|JPEG (*.jpeg)|*.jpeg";

             if (openFileDialog.ShowDialog() == true)
             {
                 FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                 BitmapImage loadImage = new BitmapImage();
                 loadImage.BeginInit();
                 loadImage.UriSource = new Uri(fileInfo.FullName);
                 loadImage.EndInit();
                 Image_box.Source = loadImage;


             } */
            MessageBox.Show("Здесь будет реализовано открытие файла!");
            MemoryStream memoStream = new MemoryStream();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "bmp рисунок (*.bmp)|*.bmp|" +
                "Jpg рисунок (*.jpg, *.jpeg)|*.jpg; *.jpeg|" +
                "Png рисунок (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string file_name = openFileDialog.FileName;
                string path = System.IO.Path.GetFullPath(file_name);
                using (FileStream fs = File.OpenRead(file_name))
                {
                    fs.CopyTo(memoStream);
                    BitmapImage bmi = new BitmapImage();
                    bmi.BeginInit();
                    bmi.StreamSource = memoStream;
                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                    bmi.UriSource = new Uri(fileInfo.FullName);
                    bmi.EndInit();
                    ImageBrush brush = new ImageBrush(bmi);
                    DrawingCanvas.Background = brush;
                    fs.Close();
                }
            }
        }



        private void button_save_image_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Image"; // Имя по-умолчанию
            saveFileDialog.DefaultExt = ".jpg"; // Расширение по-умолчанию
            saveFileDialog.Filter = "PNG (*.png)|*.png|JPG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp|JPEG (*.jpeg)|*.jpeg"; // Фильтр по расширениям
        
            if (saveFileDialog.ShowDialog() == true)
            {
                JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
                jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(Image_box.Source as BitmapSource));
                using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    jpegBitmapEncoder.Save(fileStream);
            }
            /*  // Настраиваем параметры диалога
              SaveFileDialog saveFileDialog = new SaveFileDialog();
              saveFileDialog.FileName = "Image"; // Имя по-умолчанию
              saveFileDialog.DefaultExt = ".jpg"; // Расширение по-умолчанию
              saveFileDialog.Filter = "PNG (*.png)|*.png|JPG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp|JPEG (*.jpeg)|*.jpeg"; // Фильтр по расширениям

              // Показываем диалог пользователю
              Nullable<bool> result = saveFileDialog.ShowDialog();

              // Обработка результата работы диалога
              if (result == true)
              {
                  // Получаем из диалога полное имя файла
                  string filename = saveFileDialog.FileName;
                  //Данные для записи. Тут для примера, это должно быть за пределами данного кода
                  string someText = "TEXT";
                  // Сохраняем someText в файле, с полученным из диалога, именем
                  File.WriteAllText(filename, someText); */
        }

        private void btn_PenColor_Click(object sender, RoutedEventArgs e)
        {

           
        }
    }
    }


