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
    public class MyBookModel : PageModel
    {
        private readonly UnitOfWork unitOfWork;
        public MyBookModel(BookStory.Models.ShopeContext context)
        {
            unitOfWork = new UnitOfWork(context);

        }
        public IList<Book> Book { get;set; }

        public void OnGet()
        {
            Book = unitOfWork.Books.GetAllBookSomeUser(User.Identity.Name).ToList();
        }
        public async Task<IActionResult> OnPostPutAsync(int id)
        {
            User n = unitOfWork.Users.FindByLogin(User.Identity.Name);
            if (unitOfWork.Users.ExistBook(id, n.Id))
            {
                unitOfWork.Users.AddBook(id, n.Id);
                await unitOfWork.SaveChangesAsync();
            }
            return RedirectToAction("./MyBook", Book);

        }

    }
}
