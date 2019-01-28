using System;
using System.Collections.Generic;

namespace Workshop.Cars.Dto
{
    public class CarDto
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public List<CarImageDto> Images { get; set; }
    }
}