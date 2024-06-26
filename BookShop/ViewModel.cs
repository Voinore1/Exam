﻿using bookShop;
using Exam.Data;
using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        private BookShopDB BookShop = new();

        private User user = new();


        private RelayCommand loginCommand;

        public ViewModel()
        {
            var q = new BookShopDB();

            Books = q.Users.ToList();

            loginCommand = new RelayCommand((o) => Login(),(o) => Username != null && Password != null);
        }
        


        public ObservableCollection<object> Books { get; set; }
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
                //ShopWindow shopWindow = new(this);
                //shopWindow.Show();
            }
            
        }

    }

    public class User
    {
        public string username { get; set; }
        public string password { get; set; }    

    }
    
}