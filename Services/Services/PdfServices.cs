using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Models;

namespace Services.Services
{
    public class PdfServices
    {
        public PdfFile readPdf (string filepath)
        {

            var pdfFile = new PdfFile ();

            pdfFile.path = filepath;

            //textExtractor = new PdfTextExtractor();

            //pdfFile.Text = textExtractor.ExtractInformation(pdfFile.path);

            return pdfFile;

        }

    }
}
