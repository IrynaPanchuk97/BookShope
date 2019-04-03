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
    public class DeleteMyBookModel : PageModel
    {
        private readonly UnitOfWork unitOfWork;


        public DeleteMyBookModel(BookStory.Models.ShopeContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

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

        public async Task<IActionResult> OnPostAsync(int id)
        {

            if (Book != null)
            {
                User user = unitOfWork.Users.FindByLogin(User.Identity.Name);
                unitOfWork.Users.DeleteBook(id, user.Id);
                await unitOfWork.SaveChangesAsync();
            }

            return RedirectToPage("./MyBook");
        }
    }
}
