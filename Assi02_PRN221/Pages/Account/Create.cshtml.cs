using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Objects.Models;
using Services;

namespace Assi02_PRN221.Pages.Account
{
    public class CreateModel : PageModel
    {
        // private readonly Objects.Models.BookManagementContext _context;
        private readonly IAccountService _accountService;

        public CreateModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookManagementMember BookManagementMember { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _accountService.GetListAccount() == null || BookManagementMember == null)
            {
                return Page();
            }

            _accountService.addBookAccount(BookManagementMember);
          //  await _accountService.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
