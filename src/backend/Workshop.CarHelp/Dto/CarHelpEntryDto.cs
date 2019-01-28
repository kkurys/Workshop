using System;
using Workshop.Common.Enums;

namespace Workshop.CarHelp.Dto
{
    public class CarHelpEntryDto
    {
        public string CarHelpId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public CarHelpStatus Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}