﻿using PropertyChanged;

namespace Exam.Data.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class Order
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
        }
        public int UserId { get; set; } 

        //////////////////////////////////////////////////////

        public ICollection<Book> Books { get; set; }
        public User User { get; set; }

    }
}