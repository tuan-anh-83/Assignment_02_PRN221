using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Objects.Models;

namespace Assi02_PRN221.Pages.BookBorrowList
{
    public class CreateModel : PageModel
    {
        private readonly Objects.Models.BookManagementContext _context;

        public CreateModel(Objects.Models.BookManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId");
        ViewData["MemberId"] = new SelectList(_context.BookManagementMembers, "MemberId", "MemberId");
            return Page();
        }

        [BindProperty]
        public BookBorrow BookBorrow { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BookBorrows == null || BookBorrow == null)
            {
                return Page();
            }

            _context.BookBorrows.Add(BookBorrow);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
