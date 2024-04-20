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
        public int Rating
        {
            get { int a = 0; foreach (var item in Reviews) { a += item.Rating; } return a / Reviews.Count; }
        }
        public int Sheets { get; set; }
        public string Description { get; set; } 

        /////////////////////

        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public Genres Genre { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Orders>? Orders { get; set; }
    }
}