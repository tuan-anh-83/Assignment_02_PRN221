using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Objects.Models;
using Repository;
using Services;

namespace Assi02_PRN221.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly IAccountService _accountService = null;

        public EditModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public BookManagementMember BookManagementMember { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _accountService.GetListAccount() == null)
            {
                return NotFound();
            }

            var staffaccount = _accountService.GetBookById(id);
            if (staffaccount == null)
            {
                return NotFound();
            }
            BookManagementMember = staffaccount;
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
                _accountService.UpdateBookProfile(BookManagementMember);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;

            }

            return RedirectToPage("./Index");
        }
    }
}
