﻿using Exam.Data.Entities;
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
        Users u;
        public Window1(Users u)
        {
            InitializeComponent();
            this.u = u;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page1 page = new(u);
            this.mainFrame.Navigate(page);
        }
        
    }
}
