using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStory.Models;
using BookStory.Repository;

namespace BookStory.Pages.BookPages
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork unitOfWork;

        public IndexModel(BookStory.Models.ShopeContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await unitOfWork.Books.GetAllAsync();
        }
    }
}
