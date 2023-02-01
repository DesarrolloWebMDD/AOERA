using System.Collections.Generic;

namespace Application.Dto
{
    public class SoccerSubCategoryDto
    {
        public int Id { get; set; }
        public int SoccerCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public List<LigueDto> Ligues { get; set; }
    }
}
