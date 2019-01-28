using System;
using Workshop.Common.Enums;
using Workshop.Data.Models.Account;

namespace Workshop.Data.Models.CarHelp
{
    public class CarHelpEntry
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public CarHelpStatus Status { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid CarId { get; set; }
        public virtual WorkshopUser Employee { get; set; }
        public virtual Car.Car Car { get; set; }
    }
}