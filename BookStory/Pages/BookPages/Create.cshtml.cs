using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStory.Models;
using BookStory.Repository;

namespace BookStory.Pages.BookPages
{
    public class CreateModel : PageModel
    {
        private readonly UnitOfWork unitOfWork;

        public CreateModel(BookStory.Models.ShopeContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            unitOfWork.Books.Create(Book);
            await unitOfWork.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}