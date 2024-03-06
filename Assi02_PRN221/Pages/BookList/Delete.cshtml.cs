using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Objects.Models;
using Services;

namespace Assi02_PRN221.Pages.BookList
{
    public class DeleteModel : PageModel
    {
        private readonly IBookService _iBookService = null;

        public DeleteModel(IBookService iBookService)
        {
            _iBookService = iBookService;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _iBookService.GetBooks() == null)
            {
                return NotFound();
            }

            var bookaccount = _iBookService.GetBookProfileByID(id);

            if (bookaccount == null)
            {
                return NotFound();
            }
            else
            {
                Book = bookaccount;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _iBookService.GetBooks() == null)
            {
                return NotFound();
            }
            var bookaccount = _iBookService.GetBookProfileByID(id);

            if (bookaccount != null)
            {
                _iBookService.DeleteBookProfile(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
