using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Objects.Models;
using Repository;
using Services;

namespace Assi02_PRN221.Pages.Account
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountService _accountService = null;

        public DeleteModel(IAccountService accountService)
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

            var bookaccount = _accountService.GetBookById(id);

            if (bookaccount == null)
            {
                return NotFound();
            }
            else
            {
                BookManagementMember = bookaccount;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _accountService.GetListAccount() == null)
            {
                return NotFound();
            }
            var bookaccount = _accountService.GetBookById(id);

            if (bookaccount != null)
            {
                _accountService.deleteBookAccount(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
