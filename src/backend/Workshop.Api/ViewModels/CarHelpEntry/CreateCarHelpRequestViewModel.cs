using Workshop.Common.Enums;

namespace Workshop.Api.ViewModels.CarHelpEntry
{
    public class CreateCarHelpRequestViewModel
    {
        public string CarId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public CarHelpStatus Status { get; set; }
    }
}
