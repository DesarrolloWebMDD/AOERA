using System.Collections.Generic;

namespace Application.Dto
{
    public class SoccerCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public List<SoccerSubCategoryDto> SoccerSubCategorys { get; set; }
    }
}
