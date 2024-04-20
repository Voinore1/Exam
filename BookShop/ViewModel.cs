using bookShop;
using Exam.Data;
using Exam.Data.Entities;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace bookShop
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        private IObservable<BookShopDB> BookShop = new();

        private User user = new();


        private RelayCommand loginCommand;

        public ViewModel()
        {

            loginCommand = new RelayCommand((o) => Login(),(o) => Username != null && Password != null);
        }
        

        public string Password { get; set; }
        public string Username { get; set; }
        public string Error { get; set; }


        public ICommand LoginCmd => loginCommand;

        public void Login()
        {
            var u = BookShop.Users.FirstOrDefault(x => x.Username == Username);
            if (u == null || u.Password != Password) { Error = "Password or username are incorect!"; }
            else {
                user.username = u.Username;
                user.password = u.Password;
                Error = "";
                ShopWindow shopWindow = new(this);
                shopWindow.Show();
            }
            
        }

    }

    public class User
    {
        public string username { get; set; }
        public string password { get; set; }    

    }
    
}