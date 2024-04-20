namespace Exam.Data.Entities
{
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
}