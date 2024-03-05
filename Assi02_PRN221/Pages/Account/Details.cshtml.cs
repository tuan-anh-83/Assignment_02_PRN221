using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Objects.Models;

namespace Assi02_PRN221.Pages.Account
{
    public class DetailsModel : PageModel
    {
        private readonly Objects.Models.BookManagementContext _context;

        public DetailsModel(Objects.Models.BookManagementContext context)
        {
            _context = context;
        }

      public BookManagementMember BookManagementMember { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.BookManagementMembers == null)
            {
                return NotFound();
            }

            var bookmanagementmember = await _context.BookManagementMembers.FirstOrDefaultAsync(m => m.MemberId == id);
            if (bookmanagementmember == null)
            {
                return NotFound();
            }
            else 
            {
                BookManagementMember = bookmanagementmember;
            }
            return Page();
        }
    }
}
