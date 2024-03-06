using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Objects.Models;
using Services;

namespace Assi02_PRN221.Pages.BookBorrowList
{
    public class IndexModel : PageModel
    {
        private readonly IBookBorrowService _iBookBorrowService = null;

        public IndexModel(IBookBorrowService iBookBorrowService)
        {
            _iBookBorrowService = iBookBorrowService;
        }

        public IList<BookBorrow> BookBorrow { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_iBookBorrowService.GetBookBorrows() != null)
            {
                BookBorrow = _iBookBorrowService.GetBookBorrows();
            }
        }
    }
}
