using System;

namespace Workshop.Data.Models.Car
{
    public class CarImage
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string Image { get; set; }
        public virtual Car Car { get; set; }
    }
}