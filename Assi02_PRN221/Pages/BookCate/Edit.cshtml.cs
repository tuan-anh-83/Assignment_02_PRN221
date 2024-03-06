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

namespace Assi02_PRN221.Pages.BookCate
{
    public class EditModel : PageModel
    {
        private readonly IBookCateService _iBookCateService = null;

        public EditModel(IBookCateService iBookCateService)
        {
            _iBookCateService = iBookCateService;
        }

        [BindProperty]
        public BookCategory BookCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _iBookCateService.GetBookCate() == null)
            {
                return NotFound();
            }

            var staffaccount = _iBookCateService.GetBookCateByID(id);
            if (staffaccount == null)
            {
                return NotFound();
            }
            BookCategory = staffaccount;
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
                _iBookCateService.UpdateBookCate(BookCategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;

            }

            return RedirectToPage("./Index");
        }
    }
}
