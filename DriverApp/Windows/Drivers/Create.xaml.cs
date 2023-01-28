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
            if (nameTextBox.Text.Length <= 0) {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (surnameTextBox.Text.Length <= 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (middlenameTextBox.Text.Length <= 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (pasportTextBox.Text.Length <= 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (adressTextBox.Text.Length <= 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (adressLifeTextBox.Text.Length <= 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (companyTextBox.Text.Length <= 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (jobnameTextBox.Text.Length <= 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (emailTextBox.Text.Length <= 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
           
            if (NewDriver.Photo == null)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (descriptionTextBox.Text.Length <= 0)
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
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
