using Exam.Data;
using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace Shop
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        private BookShopDB bookDB = new BookShopDB();
        private ObservableCollection<Book> books;
        private ObservableCollection<Orders> myOrders;
        private ObservableCollection<Book> orderedBooks = new();
        private ObservableCollection<Review> myReviews;

        private User u;
        

        private RelayCommand addBook;
        private RelayCommand showReview;
        private RelayCommand cancelOrder;
        private RelayCommand acceptOrder;

        public ViewModel(User u)
        {
            this.u = u;

            books = new ObservableCollection<Book>( bookDB.Books
                .Include(x => x.Author)
                .Include(x => x.Publisher)
                .Include(x => x.Genre)
                .Include(x => x.Reviews)
                .ToList());

            myReviews = new ObservableCollection<Review>( bookDB.Reviews
                .Where(x => x.UserId == u.Id)
                .Include(x => x.Book)
                .ToList()
                );

            myOrders = new ObservableCollection<Orders>(bookDB.Orders
                .Where(x=>x.UserId == u.Id)
                .Include(x=>x.Books)
                .ToList()
                );


            SelBook = books[0];

            addBook = new RelayCommand((o) => addToOrderBook(), (o) => SelBook != null);
            showReview = new RelayCommand((o) => showReviews(), (o) => SelBook != null);
            cancelOrder = new RelayCommand((o) => clearOrder(), (o) => orderedBooks.Any());
            acceptOrder = new RelayCommand((o) => acceptOrders(), (o) => orderedBooks.Any());
        }

        public ICollection<Book> Books => books;
        public ICollection<Book> OrderedBooks => orderedBooks;
        public ICollection<Review> SelBookReviews => bookDB.Reviews.Where(x => x.BookId == SelBook.Id).Include(x => x.User).ToList();
        public ICollection<Review> MyReviews => myReviews;
        public ICollection<Book> myOrderedBooks 
        { 
            get
            {
                ObservableCollection<Book> b = new ObservableCollection<Book>();
                foreach (var item in myOrders) 
                {
                    foreach (var book in item.Books)
                    {
                        if (!b.Contains(book))
                        {
                            Review r;
                            if (book.Reviews.Where(x => x.UserId == u.Id).ToArray().Count() == 0)
                            {
                                r = new Review()
                                {
                                    Id = 1,
                                    Reviews = "no review",
                                    Book = book,
                                    BookId = book.Id,
                                    Rating = null,
                                    User = u, 
                                    UserId = u.Id
                                };
                                book.MyReview = r;
                            }
                            else
                            {
                                r = book.Reviews.Where(x => x.UserId == u.Id).ToArray()[0];
                                book.MyReview = r;
                            }

                            b.Add(book); 
                        }
                    }
                }

                return b;
            }
        }
        public Book SelBook { get; set; }
        public string TotalCost
        {
            get
            {
                return orderedBooks.Count == 0 ? "Total price: $0" : $"Total price: ${OrderedBooks.Sum(x=>x.Price)}";
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
            Window2 w = new(this);
            w.Show();
            
        }
        public void addToOrderBook()
        {
            orderedBooks.Add(SelBook);
        }

    }

}
