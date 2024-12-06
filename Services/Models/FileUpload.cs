using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Forms.Form.Element;
using Microsoft.AspNetCore.Http;

namespace Services.Models
{
    public class FileUpload 
    { 
        public required IFormFile File { get; set; }
    }
}
