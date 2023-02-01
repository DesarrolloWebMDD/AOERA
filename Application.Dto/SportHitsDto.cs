using System;
using System.Collections.Generic;

namespace Application.Dto
{
    public class SportHitsDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? HitType { get; set; } //Individual o Combinada
        public int? PointsHit { get; set; }
        public decimal? PointsEarn { get; set; }
        public bool? HitsState { get; set; }
        public bool? FinalyResult { get; set; }
        public bool? State { get; set; }
        public string Code { get; set; }
        public List<SportHitsDetailDto> SportHitsDetails { get; set; }
    }
}
