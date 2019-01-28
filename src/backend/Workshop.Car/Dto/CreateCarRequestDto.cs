using System.ComponentModel.DataAnnotations.Schema;
using Workshop.Data.Models.Account;

namespace Workshop.Cars.Dto
{
    public class CreateCarRequestDto
    {
        public int Year { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public WorkshopUser User { get; set; }
    }
}
