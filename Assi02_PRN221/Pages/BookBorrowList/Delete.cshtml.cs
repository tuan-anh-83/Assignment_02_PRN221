using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Objects.Models;

namespace Assi02_PRN221.Pages.BookBorrowList
{
    public class DeleteModel : PageModel
    {
        private readonly Objects.Models.BookManagementContext _context;

        public DeleteModel(Objects.Models.BookManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public BookBorrow BookBorrow { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.BookBorrows == null)
            {
                return NotFound();
            }

            var bookborrow = await _context.BookBorrows.FirstOrDefaultAsync(m => m.BookBorrowId == id);

            if (bookborrow == null)
            {
                return NotFound();
            }
            else 
            {
                BookBorrow = bookborrow;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.BookBorrows == null)
            {
                return NotFound();
            }
            var bookborrow = await _context.BookBorrows.FindAsync(id);

            if (bookborrow != null)
            {
                BookBorrow = bookborrow;
                _context.BookBorrows.Remove(BookBorrow);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
