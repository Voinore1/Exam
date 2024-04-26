using Exam.Data;
using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        ViewModel vm = new();
        public Page1()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

    }
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        private BookShopDB bookDB = new BookShopDB();
        private List<Book> books;

        private RelayCommand sortAuthor;
        private RelayCommand sortName;
        private RelayCommand sortISBN;
        private RelayCommand sortGenre;
        public ViewModel()
        {
            books = bookDB.Books.Include(x=>x.Author).Include(x=>x.Publisher).Include(x=>x.Genre).Include(x=>x.Reviews).ToList();
            SelBook = books[0];
            sortAuthor = new RelayCommand((o)=>sortAu(), (o)=>true);
        }

        public ICollection<Book> Books => books;
        public Book SelBook { get; set; }
        public RelayCommand sortAuCmd => sortAuthor;
        public RelayCommand sortGeCmd => sortGenre;
        public RelayCommand sortISBNCmd => sortISBN;
        public RelayCommand sortNameCmd => sortName;

        #region SelectedBookBindings
        public string SelBookPublished
        {
            get
            {
                return SelBook == null ? "" : $"Published by {SelBook.Publisher.Name} in {SelBook.PublishedYear}";
            }
        }
        public string SelBookTitle
        {
            get
            {
                return SelBook == null ? "" : $"{SelBook.Title} By {SelBook.Publisher.Name}";
            }
        }
        public string SelBookCost
        {
            get
            {
                return SelBook == null ? "" : $"Cost: {SelBook.Price}$";
            }
        }
        public string SelBookSheets
        {
            get
            {
                return SelBook == null ? "" : $"{SelBook.Sheets} sheets of {SelBook.Genre.Name}";
            }
        }
        public string SelBookRating
        {
            get
            {
                return !SelBook.Reviews.Any() ? "Rating: N/A" : $"Rating: {SelBook.Rating}";
            }
        }
        public string SelBookDescription
        {
            get
            {
                return SelBook == null ? "" : $"Description: {SelBook.Description}";
            }
        }
        #endregion

        public void sortAu()
        {
            books = books.OrderBy(x => x.Author).ToList();
        }
        public void sortGe()
        {
            books = books.OrderBy(x => x.Genre).ToList();
        }
        public void sortbyName()
        {
            books = books.OrderBy(x => x.Title).ToList();
        }
        public void sortbyISBN()
        {
            books = books.OrderBy(x => x.ISBN).ToList();
        }

    }
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }

}
