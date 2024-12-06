using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Services.Models;

namespace Services.Services
{
    public class FileService
    {

        public async Task<string> ReadFileAsync(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "uploads", fileName);

            return PdfTextExtractor.ExtractInformation(filePath);
        }

        public async Task<bool> UploadFileAsync(FileUpload fileUpload)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "uploads", fileUpload.File.FileName);
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fileUpload.File.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
