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

namespace Assi02_PRN221.Pages.BookBorrowList
{
    public class EditModel : PageModel
    {
        private readonly IBookBorrowService _iBookBorrowService = null;

        public EditModel(IBookBorrowService iBookBorrowService)
        {
            _iBookBorrowService = iBookBorrowService;
        }

        [BindProperty]
        public BookBorrow BookBorrow { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _iBookBorrowService.GetBookBorrows() == null)
            {
                return NotFound();
            }

            var staffaccount = _iBookBorrowService.GetBookBorrowByID(id);
            if (staffaccount == null)
            {
                return NotFound();
            }
            BookBorrow = staffaccount;
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
                _iBookBorrowService.UpdateBookBorrow(BookBorrow);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;

            }

            return RedirectToPage("./Index");
        }
    }
}
