using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace WebApplication9.Models
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { set; get; }
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
