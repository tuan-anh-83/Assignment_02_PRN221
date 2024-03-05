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
    public class DetailsModel : PageModel
    {
        private readonly IAccountService _accountService;

        public DetailsModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

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
    }
}
