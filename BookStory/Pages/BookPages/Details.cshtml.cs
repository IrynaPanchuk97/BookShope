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
    public class DetailsModel : PageModel
    {
        private readonly UnitOfWork unitOfWork;
        public DetailsModel(BookStory.Models.ShopeContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public Book Book { get; set; }

        public IActionResult OnGetAsync(int id)
        {

            Book = unitOfWork.Books.Find(id);
            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
