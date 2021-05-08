using System;
using ExpenseManager.Areas.Identity.Data;
using ExpenseManager.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ExpenseManager.Areas.Identity.IdentityHostingStartup))]
namespace ExpenseManager.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ExpenseManagerDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ExpenseManagerDBContextConnection")));
                /*Ustawienia hasła, zeby nie trzeba było potwierdzać rejestracji przez email */
                services.AddDefaultIdentity<ExpenseManagerUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    })
                    .AddEntityFrameworkStores<ExpenseManagerDBContext>();
            });
        }
    }
}