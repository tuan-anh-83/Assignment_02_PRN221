using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Objects.Models;
using Services;

namespace Assi02_PRN221.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly IAccountService _accountServie;

        [BindProperty]
        public string MemberId { get; set; }

        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string FullName { get; set; }
        public SignUpModel(IAccountService accountServie)
        {
            _accountServie = accountServie;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

                if (_accountServie.GetBookById(MemberId) != null)
                {

                    ViewData["Message"] = "UserID already exists!";
                    return Page();
                }


                BookManagementMember acc = new BookManagementMember
                {
                    MemberId = MemberId,
                    Password = Password,
                    Email = Email,
                    FullName = FullName,
                    MemberRole = 3
                };

                _accountServie.addBookAccount(acc);

                return RedirectToPage("/Index");
            }


            return Page();
        }
    }
}
