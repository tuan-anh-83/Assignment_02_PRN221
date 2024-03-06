using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Objects.Models;
using Services;

namespace Assi02_PRN221.Pages.BookCate
{
    public class DetailsModel : PageModel
    {
        private readonly IBookCateService _bookCateService = null;

        public DetailsModel(IBookCateService bookCateService)
        {
            _bookCateService = bookCateService;
        }

        public BookCategory BookCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _bookCateService.GetBookCate() == null)
            {
                return NotFound();
            }

            var bookaccount = _bookCateService.GetBookCateByID(id);
            if (bookaccount == null)
            {
                return NotFound();
            }
            else
            {
                BookCategory = bookaccount;
            }
            return Page();
        }
    }
}
