using SpreadsheetLight;
using System;
using System.IO;
using System.Collections.Generic;
using Application.Dto;

namespace Application.MainModule.Util
{
    public class ExcelReader
    {

        public List<SportsDto> ReadExcelSports(UploadFileDto request, string path)
        {
            var data = new List<SportsDto>();
            int row = 2;
            if (request.LigueId > 0)
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                using (var stream = new FileStream(path + request.FileName, FileMode.Create, FileAccess.Write))
                {
                    stream.Write(Convert.FromBase64String(request.Base64));
                    stream.Close();
                }
                SLDocument sl = new SLDocument(path + request.FileName);
                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(row, 1)))
                {
                    data.Add(new SportsDto
                    {
                        Hour = sl.GetCellValueAsString(row, 1),
                        DateHour = sl.GetCellValueAsDateTime(row, 2),
                        DeportText = sl.GetCellValueAsString(row, 3),
                        TeamA = sl.GetCellValueAsString(row, 4),
                        TeamB = sl.GetCellValueAsString(row, 5),
                        PointA = sl.GetCellValueAsDecimal(row, 6),
                        PointB = sl.GetCellValueAsDecimal(row, 7),
                        TieText = sl.GetCellValueAsString(row, 8),
                        PointTie = sl.GetCellValueAsDecimal(row, 9),
                        Goal1Text = sl.GetCellValueAsString(row, 10),
                        PointGoal1 = sl.GetCellValueAsDecimal(row, 11),
                        Goal2Text = sl.GetCellValueAsString(row, 12),
                        PointGoal2 = sl.GetCellValueAsDecimal(row, 13),
                        Goal3Text = sl.GetCellValueAsString(row, 14),
                        PointGoal3 = sl.GetCellValueAsDecimal(row, 15),
                        Goal4Text = sl.GetCellValueAsString(row, 16),
                        PointGoal4 = sl.GetCellValueAsDecimal(row, 17),
                        Goal_1Text = sl.GetCellValueAsString(row, 18),
                        PointGoal_1 = sl.GetCellValueAsDecimal(row, 19),
                        Goal_2Text = sl.GetCellValueAsString(row, 20),
                        PointGoal_2 = sl.GetCellValueAsDecimal(row, 21),
                        Goal_3Text = sl.GetCellValueAsString(row, 22),
                        PointGoal_3 = sl.GetCellValueAsDecimal(row, 23),
                        Goal_4Text = sl.GetCellValueAsString(row, 24),
                        PointGoal_4 = sl.GetCellValueAsDecimal(row, 25),
                        TeamLE = sl.GetCellValueAsString(row, 26),
                        PointLE = sl.GetCellValueAsDecimal(row, 27),
                        TeamEV = sl.GetCellValueAsString(row, 28),
                        PointEV = sl.GetCellValueAsDecimal(row, 29),
                        GoalSi = sl.GetCellValueAsString(row, 30),
                        PointSI = sl.GetCellValueAsDecimal(row, 31),
                        GoalNo = sl.GetCellValueAsString(row, 32),
                        PointNO = sl.GetCellValueAsDecimal(row, 33),
                        StateSelect = false,
                        StateSport = 0
                    });
                    row++;
                }
            }

            return data;
        }

    }
}
