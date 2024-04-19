using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;

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

    public class BookShop : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string str = "Data Source=DESKTOP-16BU9SR\\SQLEXPRESS;Initial Catalog=BookShop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

            optionsBuilder.UseSqlServer(str);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasKey(x=>x.ISBN);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }  
        public DbSet<Genres> Genres { get; set; }   
        public DbSet<Users> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }

    public class Book   
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int Stock { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public int Sheets { get; set; } 

        /////////////////////

        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public Genres Genre { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        ////////////////////////////

        public ICollection<Book>? Books { get; set; }

    }

    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //////////////////////////////////

        public ICollection<Book>? Books { get; set; }

    }

    public class Genres
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //////////////////////////////////////

        public ICollection<Book>? Books { get; set; }
    }

    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        ///////////////////////////////////////

        public ICollection<Orders>? Orders { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }

    public class Orders
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }   

        //////////////////////////////////////////////////////

        public ICollection<Book> Books { get; set; }

    }

    public class Review
    {
        public int Id { get; set; }
        public string Reviews { get; set; }
        public int Rating { get; set; }

        ///////////////////////////////////////////////////

        public Book Book { get; set; }

    }
}