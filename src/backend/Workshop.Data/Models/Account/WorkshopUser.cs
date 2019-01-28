using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Workshop.Data.Models.CarHelp;

namespace Workshop.Data.Models.Account
{
    public class WorkshopUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Car.Car> Cars { get; set; }
        public virtual ICollection<CarHelpEntry> CallHelpEntries { get; set; }
    }
}