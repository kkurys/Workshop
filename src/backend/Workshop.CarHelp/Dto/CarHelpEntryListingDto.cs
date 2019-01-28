using System.Collections.Generic;

namespace Workshop.CarHelp.Dto
{
    public class CarHelpEntryListingDto
    {
        public int TotalCount { get; set; }
        public List<CarHelpEntryDto> CarHelpEntries { get; set; }
    }
}