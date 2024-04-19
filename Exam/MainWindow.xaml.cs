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

            modelBuilder.Entity<Book>().HasKey(x=>x.Id);

            modelBuilder.Entity<Book>().HasMany(x => x.Reviews)
                                       .WithOne(x => x.Book);

            modelBuilder.Entity<Book>().HasOne(x => x.Author)
                                       .WithMany(x => x.Books);

            modelBuilder.Entity<Book>().HasOne(x => x.Publisher)
                                       .WithMany(x => x.Books);

            modelBuilder.Entity<Book>().HasOne(x => x.Genre)
                                       .WithMany(x => x.Books);

            modelBuilder.Entity<Book>().HasMany(x => x.Orders)
                                       .WithMany(x => x.Books);

            modelBuilder.Entity<Users>().HasMany(x => x.Orders)
                                        .WithOne(x => x.User);

            modelBuilder.Entity<Users>().HasMany(x => x.Reviews)
                                        .WithOne(x => x.User);
            
            modelBuilder.Entity<Book>().Property(x => x.ISBN).HasMaxLength(14);
            modelBuilder.Entity<Book>().Property(x => x.Title).HasMaxLength(50);
            modelBuilder.Entity<Book>().Property(x => x.Rating).HasMaxLength(2);

            modelBuilder.Entity<Users>().Property(x=>x.Username).HasMaxLength(20);
            modelBuilder.Entity<Users>().Property(x => x.Password).HasMaxLength(20);

            modelBuilder.Entity<Orders>().Property(x=>x.OrderDate).HasDefaultValue(DateTime.Now.Date);
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
        public int Id { get; set; } 
        public int ISBN { get; set; }
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
        public ICollection<Orders>? Orders { get; set; }
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
        public decimal TotalPrice {
            get
            {
                decimal a = 0;
                foreach (var item in Books) {a += item.Price;}
                return a;
            }
            set {} }
        public int Quantity { get; set; }   

        //////////////////////////////////////////////////////

        public ICollection<Book> Books { get; set; }
        public Users User { get; set; }
    }

    public class Review
    {
        public int Id { get; set; }
        public string Reviews { get; set; }
        public int Rating { get; set; }

        ///////////////////////////////////////////////////

        public Book Book { get; set; }
        public Users User { get; set; } 

    }
}