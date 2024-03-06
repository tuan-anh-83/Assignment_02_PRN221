using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Objects.Models;
using Services;

namespace Assi02_PRN221.Pages.BookCate
{
    public class IndexModel : PageModel
    {
        private readonly IBookCateService _iBookCateService = null;

        public IndexModel(IBookCateService iBookCateService)
        {
            _iBookCateService = iBookCateService;
        }

        public IList<BookCategory> BookCategory { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_iBookCateService.GetBookCate() != null)
            {
                BookCategory = _iBookCateService.GetBookCate();
            }
        }
    }
}
