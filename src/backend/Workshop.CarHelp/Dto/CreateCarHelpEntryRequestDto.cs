using Workshop.Common.Enums;
using Workshop.Data.Models.Account;

namespace Workshop.CarHelp.Dto
{
    public class CreateCarHelpEntryRequestDto
    {
        public string CarId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public WorkshopUser Employee { get; set; }
        public CarHelpStatus Status { get; set; }
    }
}