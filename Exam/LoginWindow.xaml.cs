using System.Reflection.Emit;
using System.Text;
using System.Windows;
using Exam.Data;

namespace Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookShop bookShop = new();
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}