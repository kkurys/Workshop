using System.Collections.Generic;

namespace Workshop.Cars.Dto
{
    public class CarListingDto
    {
        public int TotalCount { get; set; }
        public List<CarDto> Cars { get; set; }
    }
}