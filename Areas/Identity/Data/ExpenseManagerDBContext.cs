using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.Areas.Identity.Data;
using ExpenseManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.Data
{
    public class ExpenseManagerDBContext : IdentityDbContext<ExpenseManagerUser>
    {
        public ExpenseManagerDBContext(DbContextOptions<ExpenseManagerDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<ExpenseModel> Expenses { get; set; } //wlasciwosc Exoenses typu Dbset
    }
}
