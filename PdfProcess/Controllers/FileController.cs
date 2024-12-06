using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Services;

namespace PdfProcess.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {

        private readonly ILogger<FileController> _logger;
        private FileService fileService;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
            fileService = new FileService();
        }

        [HttpGet(Name = "read")]
        public IActionResult ReadFile(string fileName)
        {
            string text = fileService.ReadFileAsync(fileName).Result;
            if (text.Length>1)
                return Ok(new { content = text });
            else
                return BadRequest(new { message = "No se pudo leer el archivo." });
        }

        [HttpPost(Name = "upload")]
        public IActionResult Upload(FileUpload model)
        {
            bool fileUploaded = false;
            if (model.File != null && model.File.Length > 0)
                fileUploaded = fileService.UploadFileAsync(model).Result;
            else
                return BadRequest("No se selecciono archivo.");

            if (fileUploaded)
                return Ok(new { message = "Archivo cargado correctamente!" });
            else
                return BadRequest(new { message = "No se pudo cargar el archivo." });
        }
    }
}
