using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tasprof.Components.SpotifyChart.Models;

namespace Tasprof.Components.SpotifyChart.Services
{
    /// <summary>
    /// Default file export service to Excel
    /// </summary>
    public class SpotifyChartExportService : ISpotifyChartExportService
    {
        /// <summary>
        /// Export chart to excel file
        /// </summary>
        /// <param name="spotifyChart"></param>
        public void ExportChart(Models.SpotifyChart spotifyChart , string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Chart");

                // create header row
                IRow headerRow = sheet.CreateRow(0);
                headerRow.CreateCell(0).SetCellValue("Pos");
                headerRow.CreateCell(1).SetCellValue("Artist");
                headerRow.CreateCell(2).SetCellValue("Title");

                foreach (var spotifyChartItem in spotifyChart.Items)
                {
                    IRow row = sheet.CreateRow(spotifyChartItem.Position);
                    row.CreateCell(0).SetCellValue(spotifyChartItem.Position);
                    row.CreateCell(1).SetCellValue(spotifyChartItem.Artist);
                    row.CreateCell(2).SetCellValue(spotifyChartItem.Title);
                }

                workbook.Write(fs);
            }
    }
}
}
