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
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork unitOfWork;

        public DeleteModel(BookStory.Models.ShopeContext context)
        {
            unitOfWork= new UnitOfWork(context);
        }

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGetAsync(int id)
        {

            Book =  unitOfWork.Books.Find(id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Book = unitOfWork.Books.Find(id);

            if (Book != null)
            {
                unitOfWork.Books.Delete(unitOfWork.Books.Find(id));
                await unitOfWork.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
