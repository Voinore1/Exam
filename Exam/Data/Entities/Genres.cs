namespace Exam.Data.Entities
{
    public class Genres
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //////////////////////////////////////

        public ICollection<Book>? Books { get; set; }
    }
}