﻿using System;
using System.Collections.Generic;

namespace Objects.Models
{
    public partial class Book
    {
        public Book()
        {
            BookBorrows = new HashSet<BookBorrow>();
        }

        public string BookId { get; set; } = null!;
        public string BookName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string BookCategoryId { get; set; } = null!;
        public string Author { get; set; } = null!;

        public virtual BookCategory BookCategory { get; set; } = null!;
        public virtual ICollection<BookBorrow> BookBorrows { get; set; }
    }
}
