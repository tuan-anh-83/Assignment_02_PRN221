using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Objects.Models;
using Services;

namespace Assi02_PRN221.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _iAccountService = null;

        public IndexModel(IAccountService iAccountService)
        {
            _iAccountService = iAccountService;
        }

        public IList<BookManagementMember> BookManagementMember { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_iAccountService.GetListAccount() != null)
            {
                BookManagementMember = _iAccountService.GetListAccount();
            }
        }
    }
}
