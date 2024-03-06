using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Objects.Models;
using Services;

namespace Assi02_PRN221.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly IBookService _bookService = null;

        public EditModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _bookService.GetBooks() == null)
            {
                return NotFound();
            }

            var staffaccount = _bookService.GetBookProfileByID(id);
            if (staffaccount == null)
            {
                return NotFound();
            }
            Book = staffaccount;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            try
            {
                _bookService.UpdateBookProfile(Book);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;

            }

            return RedirectToPage("./Index");
        }
    }
}
