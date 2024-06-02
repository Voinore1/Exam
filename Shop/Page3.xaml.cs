using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shop
{
    
    public partial class Page3 : Page
    {
        ViewModel ViewModel;
        DataGridColumn column;
        public Page3(ViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            this.DataContext = ViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DG1.ItemsSource = null;
            DG1.Columns.Clear();
            DG1.ItemsSource = ViewModel._Books;
            DG1.Columns[6].Visibility = Visibility.Collapsed;
            DG1.Columns[12].Visibility = Visibility.Collapsed;
            DG1.Columns[13].Visibility = Visibility.Collapsed;
            DG1.Columns[14].Visibility = Visibility.Collapsed;
            DG1.Columns[15].Visibility = Visibility.Collapsed;
            DG1.Columns[16].Visibility = Visibility.Collapsed;
            DG1.Columns[17].Visibility = Visibility.Collapsed;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DG1.ItemsSource = null;
            DG1.Columns.Clear();
            DG1.ItemsSource = ViewModel._Orders;
            DG1.Columns[4].Visibility = Visibility.Collapsed;
            DG1.Columns[5].Visibility = Visibility.Collapsed;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DG1.ItemsSource = null;
            DG1.Columns.Clear();
            DG1.ItemsSource = ViewModel._Users;
            DG1.Columns[4].Visibility = Visibility.Collapsed;
            DG1.Columns[5].Visibility = Visibility.Collapsed;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DG1.ItemsSource = null;
            DG1.Columns.Clear();
            DG1.ItemsSource = ViewModel._Author;
            DG1.Columns[2].Visibility = Visibility.Collapsed;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DG1.ItemsSource = null;
            DG1.Columns.Clear();
            DG1.ItemsSource = ViewModel._Genres;
            DG1.Columns[2].Visibility = Visibility.Collapsed;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            DG1.ItemsSource = null;
            DG1.Columns.Clear();
            DG1.ItemsSource = ViewModel._Publishers;
            DG1.Columns[2].Visibility = Visibility.Collapsed;

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            DG1.ItemsSource = null;
            DG1.Columns.Clear();
            DG1.ItemsSource = ViewModel._Reviews;
            DG1.Columns[6].Visibility = Visibility.Collapsed;
            DG1.Columns[7].Visibility = Visibility.Collapsed;
        }

    }
}
