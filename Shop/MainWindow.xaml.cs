using Exam.Data;
using System.Windows;

namespace Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private BookShopDB bookShopDB = new();


        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var u = bookShopDB.Users.FirstOrDefault(x => x.Username == Username_TB.Text);
            if (u == null || u.Password != Password_TB.Password) { Error_TB.Text = "Password or username are incorect!"; }
            else
            {
                Error_TB.Text = "";
                Window1 w = new(u);
                w.Show();
                this.Close();
            }
        }
        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            var u = new Exam.Data.Entities.User() { Username = Username_TB.Text, Password = Password_TB.Password, IsAdmin = false};
            try
            {
                bookShopDB.Users.Add(u);
                bookShopDB.SaveChanges();
            }
            catch (Exception ex)    
            {
                MessageBox.Show("This username is used");
                return;
            }
                Error_TB.Text = "";
            Window1 w = new(u);
                w.Show();
                this.Close();
            
        }

        private void Change1_Click(object sender, RoutedEventArgs e)
        {
            name_L.Content = "Sign up";
            ChangeBtn.Content = "Have account?";
            LogRegBtn.Content = "Sign up";
            Error_TB.Text = "";
            ChangeBtn.Click -= Change1_Click;
            LogRegBtn.Click -= Login_Click;
            ChangeBtn.Click += Change2_Click;
            LogRegBtn.Click += Reg_Click;
        }
        private void Change2_Click(object sender, RoutedEventArgs e)
        {
            name_L.Content = "Login";
            ChangeBtn.Content = "Doesn't have account?";
            LogRegBtn.Content = "Login";
            Error_TB.Text = "";
            ChangeBtn.Click -= Change2_Click;
            LogRegBtn.Click -= Reg_Click;
            ChangeBtn.Click += Change1_Click;
            LogRegBtn.Click += Login_Click;
        }
    }

}