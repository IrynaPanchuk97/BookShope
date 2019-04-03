using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BookStory.Models;
using BookStory.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BookStory.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly UnitOfWork unitOfWork;
        private readonly UserManager<IdentityUser> manager;

        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger, UserManager<IdentityUser> manager, ShopeContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
            unitOfWork = new UnitOfWork(context);
            this.manager = manager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return Page();
            }
        }
        public async Task<IActionResult> OnPostDelete(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User delete account");
            if (returnUrl != null)
            {
                unitOfWork.Users.Delete(User.Identity.Name);
                await unitOfWork.SaveChangesAsync();
                var user = await manager.FindByNameAsync(User.Identity.Name);
                await _signInManager.UserManager.DeleteAsync(user);
                return LocalRedirect(returnUrl);
            }
            else
            {
                return Page();
            }
        }

    }
}