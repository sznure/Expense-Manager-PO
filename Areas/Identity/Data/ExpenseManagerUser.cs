using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
//klasa opisująca urzytkowników
namespace ExpenseManager.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ExpenseManagerUser class
    public class ExpenseManagerUser : IdentityUser   //klasa expensemanageruser dziedziczy automatycznie z identitiy user
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
    }
}
