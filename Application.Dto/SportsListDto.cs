using System;

namespace Application.Dto
{
    public class SportsListDto
    {
        public int Id { get; set; }
        public string Hour { get; set; }
        public DateTime DateHour { get; set; }
        public string DeportText { get; set; }
        public int? StateSport { get; set; }
        public bool State { get; set; }
        public LigueDto Ligue { get; set; }
    }
}
