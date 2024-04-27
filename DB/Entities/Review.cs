namespace Exam.Data.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Reviews { get; set; }
        public int Rating { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; } 

        ///////////////////////////////////////////////////

        public Book Book { get; set; }
        public Users User { get; set; }

    }
}