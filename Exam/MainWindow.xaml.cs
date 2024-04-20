using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
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

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            

            

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
}