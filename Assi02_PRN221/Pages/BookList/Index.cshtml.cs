﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Objects.Models;
using Services;

namespace Assi02_PRN221.Pages.BookList
{
    public class IndexModel : PageModel
    {

        private readonly IBookService _iBookService = null;

        public IndexModel(IBookService iBookService)
        {
            _iBookService = iBookService;
        }

        public IList<Book> Book { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_iBookService.GetBooks() != null)
            {
                Book = _iBookService.GetBooks();
            }
        }

    }
}
