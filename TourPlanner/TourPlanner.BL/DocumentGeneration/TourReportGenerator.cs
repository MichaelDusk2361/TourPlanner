using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using TourPlanner.Model;

namespace TourPlanner.BL.DocumentGeneration
{
    public class TourReportGenerator : IDisposable
    {
        private readonly Document _document;


        public TourReportGenerator(string path)
        {
            _document = new(new(new PdfWriter(path)));
        }

        public void AddTour(Tour tour)
        {
            Paragraph listHeader = new Paragraph($"{tour.Name}")
            .SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD))
            .SetFontSize(14)
            .SetBold()
            .SetFontColor(ColorConstants.BLUE);
            List list = new List()
                    .SetSymbolIndent(12)
                    .SetListSymbol("\u2022")
                    .SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD));
            list.Add(new ListItem($"Description: {tour.Description}"))
                    .Add(new ListItem($"Start: {tour.Start}"))
                    .Add(new ListItem($"Destination: {tour.Destination}"))
                    .Add(new ListItem($"Transport type: {tour.TransportType}"))
                    .Add(new ListItem($"Tour Distance: {tour.TourDistance}"))
                    .Add(new ListItem($"Estimated Time: {tour.EstimatedTime}"))
                    .Add(new ListItem($"Image Path: {tour.ImageUrl}"))
                    .Add(new ListItem($"Id: {tour.Id}"));

            _document.Add(listHeader);
            _document.Add(list);

            _document.Add(new AreaBreak());
        }

        public void AddTourLogs(List<TourLog> tourLogs)
        {
            Paragraph tableHeader = new Paragraph("List of Tour Logs")
            .SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN))
            .SetFontSize(18)
            .SetBold()
            .SetFontColor(ColorConstants.GREEN);
            _document.Add(tableHeader);
            Table table = new Table(UnitValue.CreatePercentArray(6)).UseAllAvailableWidth();
            table.AddHeaderCell(getHeaderCell("Date"));
            table.AddHeaderCell(getHeaderCell("Comment"));
            table.AddHeaderCell(getHeaderCell("Difficulty"));
            table.AddHeaderCell(getHeaderCell("CompletionsTime"));
            table.AddHeaderCell(getHeaderCell("Rating"));
            table.AddHeaderCell(getHeaderCell("Id"));
            table.SetFontSize(14).SetBackgroundColor(ColorConstants.WHITE);
            foreach (var item in tourLogs)
            {
                table.AddCell(item.Date.ToString());   
                table.AddCell(item.Comment.ToString());   
                table.AddCell(item.Difficulty.ToString());   
                table.AddCell(item.CompletionTime.ToString());   
                table.AddCell(item.Rating.ToString());   
                table.AddCell(item.Id.ToString());   
            }
            
            _document.Add(table);

            _document.Add(new AreaBreak());
        }

        public void AddTourImage(Tour tour)
        {
            Paragraph imageHeader = new Paragraph("Route")
            .SetFont(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN))
            .SetFontSize(18)
            .SetBold()
            .SetFontColor(ColorConstants.GREEN);
            _document.Add(imageHeader);
            if (File.Exists(tour.ImageUrl))
            {
                ImageData imageData = ImageDataFactory.Create(tour.ImageUrl);
                _document.Add(new Image(imageData));
                _document.Add(new AreaBreak());
            }
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
