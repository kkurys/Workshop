using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Workshop.Data.Models.Account
{
    public class WorkshopUser: IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Car.Car> Cars { get; set; }
    }
}
