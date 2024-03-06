﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects.Models;

namespace Services
{
    public interface IBookBorrowService
    {
        List<BookBorrow> GetBookBorrows();
        void AddBookBorrow(BookBorrow book);

        BookBorrow GetBookBorrowByID(string bookId);

        void DeleteBookBorrow(string bookId);

        void UpdateBookBorrow(BookBorrow book);

        public List<BookBorrow> SearchMember(string name);
    }
}
