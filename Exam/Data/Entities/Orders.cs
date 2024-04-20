namespace Exam.Data.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice
        {
            get
            {
                decimal a = 0;
                foreach (var item in Books) { a += item.Price; }
                return a;
            }
            set { }
        }

        //////////////////////////////////////////////////////

        public ICollection<Book> Books { get; set; }
        public Users User { get; set; }
    }
}