using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Models;

namespace WebApplication9.Pages
{
    public class IndexModel : PageModel
    {
        UsersContext usersContext;

        public List<User> Users { set; get; }

        //private readonly ILogger<IndexModel> _logger;

        public IndexModel(UsersContext db)
        {
            usersContext = db;
            //_logger = logger;
        }

        public void OnGet()
        {
            Users = usersContext.Users.ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var user = await usersContext.Users.FindAsync(id);
            if(user != null)
            {
                usersContext.Users.Remove(user);
                await usersContext.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
