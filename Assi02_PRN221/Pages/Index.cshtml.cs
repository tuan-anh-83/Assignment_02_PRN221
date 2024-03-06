using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Objects.Models;
using Services;

namespace Assi02_PRN221.Pages
{
    public class IndexModel : PageModel
    {
        private string userId;
        private string password;
        private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public string Password { get => password; set => password = value; }
        [BindProperty]
        public string UserId { get => userId; set => userId = value; }

        [BindProperty]
        public BookManagementMember BookManagementMember { get; set; } = default!;

        public IActionResult OnPost()
        {
            string password = Request.Form["Password"];

            BookManagementMember account = _accountService.GetBookById(userId);

            if (account != null && password.Equals(account.Password))
            {
                return Redirect("Account");
            }
            return Redirect("Index");
        }
            /*else if (account.Role == 0)
            {
                HttpContext.Session.SetInt32("Role", (int)account.Role);
                HttpContext.Session.SetString("Account", JsonConvert.SerializeObject(account));
                if (HttpContext.Session.GetInt32("Role") == 0)
                {
                    return RedirectToPage("/CustomerPage/ListProfile");
                }
            }
            ViewData["notification"] = "You do not have permission to do this function!";*/
            //return Page();
        
    }
}
