using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication9.Models;

namespace WebApplication9.Pages
{
    public class CreateModel : PageModel
    {
        UsersContext usersContext;
        [BindProperty]
        public User User { set; get; }

        public CreateModel(UsersContext db)
        {
            usersContext = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                usersContext.Users.Add(User);
                await usersContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
