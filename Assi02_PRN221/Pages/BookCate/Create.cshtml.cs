using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Objects.Models;
using Services;

namespace Assi02_PRN221.Pages.BookCate
{
    public class CreateModel : PageModel
    {
        private readonly IBookCateService _bookCateService;

        public CreateModel(IBookCateService bookCateService)
        {
            _bookCateService = bookCateService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookCategory BookCategory { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _bookCateService.GetBookCate() == null || BookCategory == null)
            {
                return Page();
            }

            _bookCateService.AddBookCate(BookCategory);
            //  await _accountService.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
