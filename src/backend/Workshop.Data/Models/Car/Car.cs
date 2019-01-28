using System;
using System.Collections.Generic;
using Workshop.Data.Models.Account;
using Workshop.Data.Models.CarHelp;

namespace Workshop.Data.Models.Car
{
    public class Car
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid OwnerId { get; set; }
        public virtual WorkshopUser Owner { get; set; }
        public virtual ICollection<CarImage> Images { get; set; }
        public virtual ICollection<CarHelpEntry> CallHelpEntries { get; set; }
    }
}