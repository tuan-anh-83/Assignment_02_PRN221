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
    public class DetailsModel : PageModel
    {
        private readonly IBookService _bookService;

        public DetailsModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _bookService.GetBooks() == null)
            {
                return NotFound();
            }

            var bookaccount = _bookService.GetBookProfileByID(id);
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
    }
}
