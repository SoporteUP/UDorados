using QRCoder;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace DoradosBlazor.Client.Services
{
    public class QRService
    {
        public async Task<string> GenerarQRAsync(string texto)
        {
            return await Task.Run(() =>
            {
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(texto, QRCodeGenerator.ECCLevel.Q))
                using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
                {
                    byte[] qrCodeImage = qrCode.GetGraphic(20);
                    string base64Image = Convert.ToBase64String(qrCodeImage);
                    return $"data:image/png;base64,{base64Image}";
                }
            });
        }
    }
}
