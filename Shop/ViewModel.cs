using Exam.Data;
using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using System.Net;

namespace Shop
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        private BookShopDB bookDB = new BookShopDB();
        private List<Book> books;
        private List<Orders> orders;
        private List<Book> orderedBooks = new();
        private Users u;

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

            addBook = new RelayCommand((o) => addToOrderBook(), (o) => SelBook != null);
            showReview = new RelayCommand((o) => showReviews(), (o) => SelBook != null);
            cancelOrder = new RelayCommand((o) => clearOrder(), (o) => orderedBooks.Any());
            acceptOrder = new RelayCommand((o) => acceptOrders(), (o) => orderedBooks.Any());
        }

        public ICollection<Book> Books => books;
        public ICollection<Book> OrderedBooks => orderedBooks;
        public ICollection<Review> SelBookReviews => bookDB.Reviews.Where(x => x.BookId == SelBook.Id).ToList();
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

        public void acceptOrders()
        {
            foreach (var item in orderedBooks)
            {
                item.Stock -= 1;
            }
            Orders o = new Orders() { Books = orderedBooks, UserId = u.Id };
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
            Window2 w = new Window2(this);
            w.Show();
            
        }
        public void addToOrderBook()
        {
            orderedBooks.Add(SelBook);
        }

    }

}
