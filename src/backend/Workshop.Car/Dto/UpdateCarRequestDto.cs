namespace Workshop.Cars.Dto
{
    public class UpdateCarRequestDto
    {
        public string Id { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
    }
}