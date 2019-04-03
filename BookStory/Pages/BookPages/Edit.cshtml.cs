using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStory.Models;
using BookStory.Repository;

namespace BookStory.Pages.BookPages
{
    public class EditModel : PageModel
    {
        private readonly UnitOfWork unitOfWork;

        public EditModel(BookStory.Models.ShopeContext context) => unitOfWork = new UnitOfWork(context);


        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            unitOfWork.Books.Update(Book);

            try
            {
                await unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id) => (unitOfWork.Books.Find(id) != null) ? true : false;

    }
}
