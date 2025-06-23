using DoradosBlazor.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DoradosBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorreosController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public CorreosController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("enviar")]
        public async Task<IActionResult> EnviarCorreo([FromForm] CorreoRequest request, [FromForm] IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("⚠️ ModelState inválido:");
                foreach (var kvp in ModelState)
                {
                    Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value.Errors.Select(e => e.ErrorMessage))}");
                }
                return BadRequest("Modelo inválido.");
            }

            if (file == null || file.Length == 0)
            {
                Console.WriteLine("❗ Archivo PDF no recibido.");
                return BadRequest("Debe adjuntar un archivo PDF.");
            }

            var adjuntos = new List<(string FileName, byte[] FileData)>();

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                adjuntos.Add((file.FileName, memoryStream.ToArray()));
            }

            var resultado = await _emailService.EnviarCorreoConAdjunto(
                request.SmtpServidor, request.Puerto, request.CorreoRemitente, request.Contraseña,
                request.Destinatario, request.Asunto, request.CuerpoCorreo, adjuntos
            );

            if (!resultado)
            {
                Console.WriteLine("❌ Falló el envío del correo.");
                return StatusCode(500, "Error al enviar el correo.");
            }

            Console.WriteLine("✅ Correo enviado exitosamente.");
            return Ok("Correo enviado exitosamente.");
        }
    }

    public class CorreoRequest
    {
        public string SmtpServidor { get; set; }
        public int Puerto { get; set; }
        public string CorreoRemitente { get; set; }
        public string Contraseña { get; set; }
        public string Destinatario { get; set; }
        public string Asunto { get; set; }
        public string CuerpoCorreo { get; set; }
    }
}
