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
        ViewModel vm;
        Users u;
        public Page1(Users u)
        {   
            this.u = u;
            InitializeComponent();
            vm = new ViewModel(u);
            this.DataContext = vm;
        }

    }
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        private BookShopDB bookDB = new BookShopDB();
        private List<Book> books;
        private List<Orders> orders;
        private List<Book> orderedBooks = new();
        private Users u;

        private RelayCommand sortAuthor;
        private RelayCommand sortName;
        private RelayCommand sortISBN;
        private RelayCommand sortGenre;
        private RelayCommand addBook;
        private RelayCommand showReview;
        private RelayCommand cancelOrder;
        private RelayCommand acceptOrder;
        public ViewModel(Users u)
        {
            this.u = u;
            books = bookDB.Books.Include(x=>x.Author).Include(x=>x.Publisher).Include(x=>x.Genre).Include(x=>x.Reviews).ToList();
            orders = bookDB.Orders.ToList();
            SelBook = books[0];

            sortAuthor = new RelayCommand((o)=>sortAu(), (o)=>true);
            sortName = new RelayCommand((o) => sortbyName(), (o) => true);
            sortISBN = new RelayCommand((o) => sortbyISBN(), (o) => true);
            sortGenre = new RelayCommand((o) => sortGe(), (o) => true);
            addBook = new RelayCommand((o) => addToOrderBook(), (o) => SelBook != null);
            showReview = new RelayCommand((o) => showReviews(), (o) => SelBook != null);
            cancelOrder = new RelayCommand((o) => clearOrder(), (o) => orderedBooks.Any());
            acceptOrder = new RelayCommand((o) => acceptOrders(), (o) => orderedBooks.Any());
        }

        public ICollection<Book> Books => books;
        public ICollection<Book> OrderedBooks => orderedBooks;
        public Book SelBook { get; set; }
        public string TotalCost
        {
            get
            {
                return orderedBooks.Count == 0 ? "Total price: 0" : $"Total price: ${OrderedBooks.Sum(x=>x.Price)}";
            } 
        }

        public RelayCommand CancelOrder => cancelOrder;
        public RelayCommand AddToOrderBook => addBook;
        public RelayCommand ShowReviews => showReview;
        public RelayCommand AcceptOrder => acceptOrder;

        #region SelectedBookBindings
        /// commands
        public RelayCommand sortAuCmd => sortAuthor;
        public RelayCommand sortGeCmd => sortGenre;
        public RelayCommand sortISBNCmd => sortISBN;
        public RelayCommand sortNameCmd => sortName;

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
        #endregion

        public void acceptOrders()
        {
            Orders o = new Orders() { Books = orderedBooks, Userss = u, UserId = u.Id };
            bookDB.Orders.Add(o);
            bookDB.SaveChanges();
            orderedBooks.Clear();
        }
        public void clearOrder()
        {
            orderedBooks.Clear();
        }
        public void showReviews()
        { 
            Window2 w = new Window2(SelBook.Id);
            w.Show();
        }
        public void addToOrderBook()
        {
            orderedBooks.Add(SelBook);
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
