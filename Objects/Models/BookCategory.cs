﻿using System;
using System.Collections.Generic;

namespace Objects.Models
{
    public partial class BookCategory
    {
        public BookCategory()
        {
            Books = new HashSet<Book>();
        }

        public string BookCategoryId { get; set; } = null!;
        public string BookGenreType { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
