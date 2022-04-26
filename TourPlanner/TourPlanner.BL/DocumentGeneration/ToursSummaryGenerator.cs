using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Model;

namespace TourPlanner.BL.DocumentGeneration
{
    public class ToursSummaryGenerator : IDisposable
    {
        private readonly Document _document;
        private readonly Table _table;

        public ToursSummaryGenerator(string path)
        {
            _document = new(new(new PdfWriter(path)));
            Paragraph tableHeader = new Paragraph("Statistical Analysis of Tours")
            .SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN))
            .SetFontSize(18)
            .SetBold()
            .SetFontColor(ColorConstants.GREEN);
            _document.Add(tableHeader);

            _table = new Table(UnitValue.CreatePercentArray(4)).UseAllAvailableWidth();
            _table.AddHeaderCell(getHeaderCell("Tour Name"));
            _table.AddHeaderCell(getHeaderCell("avg Time"));
            _table.AddHeaderCell(getHeaderCell("avg Rating"));
            _table.AddHeaderCell(getHeaderCell("avg Difficulty"));
            _table.SetFontSize(14).SetBackgroundColor(ColorConstants.WHITE);
        }


        public void AddStatisticalAnalysis(Tour tour, List<TourLog> tourLogs)
        {

            float averageTime = 0;
            float averageRating = 0;
            float averageDifficulty = 0;

            foreach (TourLog log in tourLogs)
            {
                if (int.TryParse(log.CompletionTime, out int time))
                {
                    averageTime += time;
                }

                averageDifficulty += log.Difficulty;
                averageRating += log.Rating;
            }

            if (tourLogs.Count > 0)
            {
                averageTime /= tourLogs.Count;
                averageRating /= tourLogs.Count;
                averageDifficulty /= tourLogs.Count;
            }

            _table.AddCell(tour.Name);
            _table.AddCell(averageTime.ToString());
            _table.AddCell(averageRating.ToString());
            _table.AddCell(averageDifficulty.ToString());
        }

        private static Cell getHeaderCell(string s)
        {
            return new Cell().Add(new Paragraph(s)).SetBold().SetBackgroundColor(ColorConstants.GRAY);
        }

        #region IDisposable
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _document.Add(_table);
                    _document.Close();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
