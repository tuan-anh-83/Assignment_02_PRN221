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
    public class DetailsModel : PageModel
    {
        private readonly IBookBorrowService _iBookBorrowService = null;

        public DetailsModel(IBookBorrowService iBookBorrowService)
        {
            _iBookBorrowService = iBookBorrowService;
        }

        public BookBorrow BookBorrow { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _iBookBorrowService.GetBookBorrows() == null)
            {
                return NotFound();
            }

            var bookaccount = _iBookBorrowService.GetBookBorrowByID(id);
            if (bookaccount == null)
            {
                return NotFound();
            }
            else
            {
                BookBorrow = bookaccount;
            }
            return Page();
        }
    }
}
