using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects.Models;

namespace Repository
{
    public interface IBookCateRepository
    {
        List<BookCategory> GetBookCate();
        void AddBookCate(BookCategory book);

        BookCategory GetBookCateByID(string bookId);

        void DeleteBookCate(string bookId);

        void UpdateBookCate(BookCategory book);

        List<BookCategory> SearchBookCate(string name);
    }
}
