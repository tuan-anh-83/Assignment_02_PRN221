﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly IBookBorrowService _bookBorrowService = null;

        public DeleteModel(IBookBorrowService bookBorrowService)
        {
            _bookBorrowService = bookBorrowService;
        }

        [BindProperty]
        public BookBorrow BookBorrow { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _bookBorrowService.GetBookBorrows() == null)
            {
                return NotFound();
            }

            var bookaccount = _bookBorrowService.GetBookBorrowByID(id);

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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _bookBorrowService.GetBookBorrows() == null)
            {
                return NotFound();
            }
            var bookaccount = _bookBorrowService.GetBookBorrowByID(id);

            if (bookaccount != null)
            {
                _bookBorrowService.DeleteBookBorrow(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
