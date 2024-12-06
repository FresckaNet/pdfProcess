using System;
using System.IO;
using System.Text;
using DataAcces.Entities;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

public static class PdfTextExtractor
{
    public static string ExtractInformation(string pdfFilePath)
    {
        var newFile = new PdfWebFile();

        var pageText = new StringBuilder();
        using (PdfDocument pdfDocument = new PdfDocument(new PdfReader(pdfFilePath)))
        {
            var pageNumbers = pdfDocument.GetNumberOfPages();
            for (int i = 1; i <= pageNumbers; i++)
            {
                LocationTextExtractionStrategy strategy = new LocationTextExtractionStrategy();
                PdfCanvasProcessor parser = new PdfCanvasProcessor(strategy);
                parser.ProcessPageContent(pdfDocument.GetFirstPage());
                pageText.Append(strategy.GetResultantText());
            }
        }
        return pageText.ToString();
    }
}
