using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoradosBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PDFController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public PDFController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("subir")]
        public async Task<IActionResult> SubirPDF(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
                return BadRequest("Archivo inválido.");

            var rutaCarpeta = Path.Combine(_env.WebRootPath, "uploads", "pdf");
            if (!Directory.Exists(rutaCarpeta))
                Directory.CreateDirectory(rutaCarpeta);

            var nombreArchivo = archivo.FileName;
            var rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

            using (var stream = new FileStream(rutaCompleta, FileMode.Create))
            {
                await archivo.CopyToAsync(stream);
            }

            var rutaRelativa = $"/uploads/pdf/{archivo.FileName}";
            return Ok(new { ruta = rutaRelativa });
        }
    }
}
