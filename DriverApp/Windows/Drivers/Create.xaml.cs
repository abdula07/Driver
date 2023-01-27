using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.IO;

namespace DriverApp.Windows.Drivers
{
    /// <summary>
    /// Логика взаимодействия для Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        Models.user12Entities context = (Models.user12Entities)App.Current.Properties["context"];
        Models.Drivers NewDriver = new Models.Drivers();

        public Create()
        {
            InitializeComponent();

            Driver.DataContext = NewDriver;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            context.Drivers.Add(NewDriver);
            


            context.SaveChanges().ToString();
            this.Close();
          
        }

        private void surnameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LoadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            var result = open.ShowDialog();
            if (result == true)
            {
                string filename = System.IO.Path.GetFileName(open.FileName);
                string path1 = Path.GetFullPath("Images");
                var path2 = path1.Substring(0, path1.Length - 17);
                var path = path2 + @"\Images\" + filename;
                 System.IO.File.Copy(open.FileName, path, true);
                NewDriver.Photo = filename;
               


            }
        }
    }
}
