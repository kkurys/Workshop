using System;
using System.Collections.Generic;

namespace Workshop.Data.Models.Car
{
    public class Car
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual ICollection<CarImage> Images { get; set; }
    }
}
