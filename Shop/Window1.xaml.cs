using Exam.Data.Entities;
using System;
using System.Collections.Generic;
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

namespace Shop
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        User u;
        ViewModel ViewModel;
        public Window1(User u)
        {
            InitializeComponent();
            this.u = u;
            ViewModel = new ViewModel(u);
            this.DataContext = ViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page1 page = new(ViewModel);
            this.mainFrame.Navigate(page);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Page2 p = new(ViewModel);
            this.mainFrame.Navigate(p);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Page3 p = new(ViewModel);
            this.mainFrame.Navigate(p);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }
    }
}
