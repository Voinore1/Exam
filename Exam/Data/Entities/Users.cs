namespace Exam.Data.Entities
{
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
}