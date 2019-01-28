using Workshop.Common.Enums;

namespace Workshop.CarHelp.Dto
{
    public class UpdateCarHelpEntryRequestDto
    {
        public string CarHelpId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public CarHelpStatus Status { get; set; }
    }
}