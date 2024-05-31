using PropertyChanged;

namespace Exam.Data.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class User
    {
       
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;

        ///////////////////////////////////////

        public ICollection<Order>? Orders { get; set; }
        public ICollection<Review>? Reviews { get; set; }

    }
}