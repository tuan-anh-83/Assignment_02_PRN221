using System;
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
        private readonly IBookService _bookService;

        public CreateModel(IBookService bookService)
        {
            _bookService = bookService;
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
            if (!ModelState.IsValid || _bookService.GetBooks() == null || Book == null)
            {
                return Page();
            }

            _bookService.AddBookProfile(Book);
            //  await _accountService.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
