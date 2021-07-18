using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using WebApplication9.Models;

namespace WebApplication9.Pages
{
    public class EditModel : PageModel
    {
        UsersContext usersContext;
        [BindProperty]
        public User User { set; get; }

        public EditModel(UsersContext db)
        {
            usersContext = db;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            User = await usersContext.Users.FindAsync(id);

            if (User == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            usersContext.Attach(User).State = EntityState.Modified;

            await usersContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
