using System.Collections.Generic;

namespace Application.Dto
{
    public class SportResultCreateDto
    {
        public int Indicator { get; set; }
        public List<SportsListDto> SportsList { get; set; }
    }
}
