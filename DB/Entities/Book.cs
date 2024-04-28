﻿using PropertyChanged;

namespace Exam.Data.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class Book
    {
        public int Id { get; set; }
        public long ISBN { get; set; }
        public string Title { get; set; }
        public int Stock { get; set; }
        public int PublishedYear { get; set; }
        public decimal Price { get; set; }
        public int Rating
        {
            get { int a = 0;if (Reviews.Count > 0) { foreach (var item in Reviews) { a += item.Rating; } return a / Reviews.Count; } else return 0; }
        }
        public int Sheets { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }    
        ////////////////////
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public Genres Genre { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Orders>? Orders { get; set; }
        public override string ToString()
        {
            return $"{Title} ${Price}";
        }

    }
}