using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Objects.Models;

namespace Assi02_PRN221.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly Objects.Models.BookManagementContext _context;

        public EditModel(Objects.Models.BookManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookManagementMember BookManagementMember { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.BookManagementMembers == null)
            {
                return NotFound();
            }

            var bookmanagementmember =  await _context.BookManagementMembers.FirstOrDefaultAsync(m => m.MemberId == id);
            if (bookmanagementmember == null)
            {
                return NotFound();
            }
            BookManagementMember = bookmanagementmember;
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

            _context.Attach(BookManagementMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookManagementMemberExists(BookManagementMember.MemberId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookManagementMemberExists(string id)
        {
          return (_context.BookManagementMembers?.Any(e => e.MemberId == id)).GetValueOrDefault();
        }
    }
}
