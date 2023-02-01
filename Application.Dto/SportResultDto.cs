namespace Application.Dto
{
    public class SportResultDto
    {
        public int Id { get; set; }
        public int SportId { get; set; }
        public string TypeText { get; set; }
        public int? ExtraValue { get; set; }
        public decimal? PointResult { get; set; }
        public int? TypeResult { get; set; }
        public bool? Result { get; set; }
        public bool? State { get; set; }
        public SportsDto Sport { get; set; }
    }
}
