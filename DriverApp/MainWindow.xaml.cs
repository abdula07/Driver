using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace DriverApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Models.user12Entities context = new Models.user12Entities();

        public MainWindow()
        {
            App.Current.Properties["context"] = context;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource driversViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("driversViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            driversViewSource.Source = context.Drivers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Windows.Drivers.Create().Show();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            System.Windows.Data.CollectionViewSource driversViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("driversViewSource")));

            driversViewSource.Source = context.Drivers.ToList();
        }

        private void EditPhoto(object sender, RoutedEventArgs e)
        {
            var selectedDriver = driversDataGrid.SelectedItem as Models.Drivers;
            OpenFileDialog open = new OpenFileDialog();
            var result = open.ShowDialog();
            if (result == true)
            {
                string filename = System.IO.Path.GetFileName(open.FileName);
                string path1 = Path.GetFullPath("Images");
                var path2 = path1.Substring(0, path1.Length - 17);
                var path = path2 + @"\Images\" + filename;
                System.IO.File.Copy(open.FileName, path, true);
                selectedDriver.Photo = filename;
                context.SaveChanges();

                System.Windows.Data.CollectionViewSource driversViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("driversViewSource")));

                driversViewSource.Source = context.Drivers.ToList();
            }
        }
    }
}
