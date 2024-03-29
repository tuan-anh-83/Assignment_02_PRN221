﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Objects.Models;
using Services;

namespace Assi02_PRN221.Pages.BookBorrowList
{
    public class CreateModel : PageModel
    {
        private readonly IBookBorrowService _bookBorrowService;

        public CreateModel(IBookBorrowService bookBorrowService)
        {
            _bookBorrowService = bookBorrowService;
        }

        /*public IActionResult OnGet()
        {
        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId");
        ViewData["MemberId"] = new SelectList(_context.BookManagementMembers, "MemberId", "MemberId");
            return Page();
        }*/

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookBorrow BookBorrow { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _bookBorrowService.GetBookBorrows() == null || BookBorrow == null)
            {
                return Page();
            }

            _bookBorrowService.AddBookBorrow(BookBorrow);
            //  await _accountService.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
