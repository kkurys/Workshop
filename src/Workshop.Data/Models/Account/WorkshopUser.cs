using Microsoft.AspNetCore.Identity;
using System;

namespace Workshop.Data.Models.Account
{
    public class WorkshopUser: IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
