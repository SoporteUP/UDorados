using System.Net.Mail;
using System.Net;

namespace DoradosBlazor.Server.Services
{
    public interface IEmailService
    {
        Task<bool> EnviarCorreoConAdjunto(
            string smtpServidor, int puerto, string correoRemitente, string contraseña,
            string destinatario, string asunto, string cuerpo,
            List<(string FileName, byte[] FileData)> adjuntos);
    }

    public class EmailService : IEmailService
    {
        public async Task<bool> EnviarCorreoConAdjunto(
            string smtpServidor, int puerto, string correoRemitente, string contraseña,
            string destinatario, string asunto, string cuerpo,
            List<(string FileName, byte[] FileData)> adjuntos)
        {
            try
            {
                using var smtp = new SmtpClient
                {
                    Host = smtpServidor,
                    Port = puerto,
                    Credentials = new NetworkCredential(correoRemitente, contraseña),
                    EnableSsl = true
                };

                var mensaje = new MailMessage
                {
                    From = new MailAddress(correoRemitente),
                    Subject = asunto,
                    Body = cuerpo,
                    IsBodyHtml = true
                };
                mensaje.To.Add(destinatario);

                if (adjuntos != null)
                {
                    foreach (var (fileName, fileData) in adjuntos)
                    {
                        var stream = new MemoryStream(fileData);
                        mensaje.Attachments.Add(new Attachment(stream, fileName));
                    }
                }

                await smtp.SendMailAsync(mensaje);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error enviando correo: {ex.Message}");
                Console.WriteLine($"🧠 StackTrace: {ex.StackTrace}");
                return false;
            }
        }
    }
}