namespace Workshop.Api.ViewModels.Car
{
    public class UpdateCarRequestViewModel
    {
        public string Id { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
    }
}