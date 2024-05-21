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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shop
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        ViewModel vm;
        Exam.Data.Entities.User u;
        public Page2(Exam.Data.Entities.User u)
        {
            this.u = u;
            InitializeComponent();
            vm = new ViewModel(u);
            this.DataContext = vm;
        }
    }
}
