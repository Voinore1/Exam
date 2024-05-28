using PropertyChanged;

namespace Exam.Data.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class Review
    {
        public int Id { get; set; }
        public string Reviews { get; set; }
        public int? Rating { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string RatingStr
        { 
            get 
            {
                if (Rating == null) { return $"Rating: N/A"; }
                else { return $"Rating: {Rating}/5"; }
            } 
        }

        ///////////////////////////////////////////////////

        public Book Book { get; set; }
        public User User { get; set; }

    }
}