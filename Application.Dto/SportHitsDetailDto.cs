namespace Application.Dto
{
    public class SportHitsDetailDto
    {
        public int Id { get; set; }
        public int? HitId { get; set; }
        public int MatchId { get; set; }
        public int BetTypeId { get; set; }
        public string BetTypeResult { get; set; }
        public decimal PointGame { get; set; }
        public string PlayGameText { get; set; }
        public bool? FinalyResult { get; set; }
        public bool? State { get; set; }
    }
}
