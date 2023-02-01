using System;
using System.Collections.Generic;

namespace Application.Dto
{
    public class SportsDto
    {
        public int Id { get; set; }
        public string Hour { get; set; }
        public DateTime DateHour { get; set; }
        public string DeportText { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public decimal? PointA { get; set; }
        public decimal? PointB { get; set; }
        public string TieText { get; set; }
        public decimal? PointTie { get; set; }
        public string Goal1Text { get; set; }
        public decimal? PointGoal1 { get; set; }
        public string Goal2Text { get; set; }
        public decimal? PointGoal2 { get; set; }
        public string Goal3Text { get; set; }
        public decimal? PointGoal3 { get; set; }
        public string Goal4Text { get; set; }
        public decimal? PointGoal4 { get; set; }
        //public string Goal5Text { get; set; }
        //public decimal PointGoal5 { get; set; }
        public string Goal_1Text { get; set; }
        public decimal? PointGoal_1 { get; set; }
        public string Goal_2Text { get; set; }
        public decimal? PointGoal_2 { get; set; }
        public string Goal_3Text { get; set; }
        public decimal? PointGoal_3 { get; set; }
        public string Goal_4Text { get; set; }
        public decimal? PointGoal_4 { get; set; }
        //public string Goal_5Text { get; set; }
        //public decimal PointGoal_5 { get; set; }
        public string TeamLE { get; set; }
        public decimal? PointLE { get; set; }
        public string TeamEV { get; set; }
        public decimal? PointEV { get; set; }
        public string GoalSi { get; set; }
        public decimal? PointSI { get; set; }
        public string GoalNo { get; set; }
        public decimal? PointNO { get; set; }
        public bool? StateSelect { get; set; }
        public int? StateSport { get; set; }

        public bool? SelectTeamA { get; set; } = false;
        public bool? SelectTie { get; set; } = false;
        public bool? SelectTeamB { get; set; } = false;
        public bool? SelectGoal1 { get; set; } = false;
        public bool? SelectGoal_1 { get; set; } = false;
        public bool? SelectGoal2 { get; set; } = false;
        public bool? SelectGoal_2 { get; set; } = false;
        public bool? SelectGoal3 { get; set; } = false;
        public bool? SelectGoal_3 { get; set; } = false;
        public bool? SelectGoal4 { get; set; } = false;
        public bool? SelectGoal_4 { get; set; } = false;
        public bool? SelectTeamLE { get; set; } = false;
        public bool? SelectTeamEV { get; set; } = false;
        public bool? SelectGG1 { get; set; } = false;
        public bool? SelectGG2 { get; set; } = false;
        public int? LigueId { get; set; }
        public List<SportResultDto> SportResults { get; set; }
    }
}
