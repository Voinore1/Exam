using Exam.Data.Entities;
using System.Windows;

namespace Shop
{
    
    public partial class Window3 : Window
    {
        private ViewModel _viewModel;
        public Window3(ViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            this.DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
