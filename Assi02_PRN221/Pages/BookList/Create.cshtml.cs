﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Objects.Models;
using Services;

namespace Assi02_PRN221.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly IBookService _iBookService = null;

        public CreateModel(IBookService iBookService)
        {
            _iBookService = iBookService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _iBookService.GetBooks() == null || _iBookService == null)
            {
                return Page();
            }

            _iBookService.AddBookProfile(Book);
            //  await _accountService.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
