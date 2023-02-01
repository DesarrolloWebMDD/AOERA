namespace Application.Dto
{
    public class UserPointDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int UserId { get; set; }
        public decimal? MembershipPoint { get; set; } = 0;
        public decimal? ChargingPoints { get; set; } = 0;
        public decimal? MissingPoints { get; set; } = 0;
        public decimal? AccumulatedPoints { get; set; } = 0;
        public decimal? PointAll { get; set; } = 0;
        public bool? State { get; set; }
    }
}
