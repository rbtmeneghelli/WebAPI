using Microsoft.AspNetCore.Http;
using SkiaSharp;
using WebAPI.Domain.Interfaces.Services.Tools;
using ZXing;
using ZXing.Common;
using ZXing.SkiaSharp;
using static System.Net.Mime.MediaTypeNames;
//using ZXing.SkiaSharp;

namespace WebAPI.Application.Services.Tools;

public class QRCodeService : IQRCodeService
{
    public string ReadQrCode(IFormFile file)
    {
        using var stream = file.OpenReadStream();
        SKBitmap bitmap = SKBitmap.Decode(stream);
        BarcodeReader reader = new BarcodeReader
        {
            AutoRotate = true,
            Options = new DecodingOptions
            {
                TryHarder = true
            }
        };

        var result = reader.Decode(bitmap);
        if (GuardClauses.ObjectIsNotNull(result))
        {
            Console.WriteLine("Conteúdo do código QR: " + result.Text);
            return result.Text;
        }
        else
        {
            Console.WriteLine("Não foi possível ler o código QR.");
        }

        return string.Empty;
    }

    public byte[] CreateQRCode(QRCodeFile qRCodeFile)
    {
        // Cria um objeto de codificação de código QR
        BarcodeWriter writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new EncodingOptions
            {
                Width = qRCodeFile.Width,
                Height = qRCodeFile.Height
            }
        };

        // Gera o código QR como uma imagem SKBitmap
        SKBitmap bitmap = writer.Write(qRCodeFile.Content);

        // Converte a imagem em bytes
        byte[] imageBytes;
        using (SKImage image = SKImage.FromBitmap(bitmap))
        using (SKData encodedData = image.Encode(SKEncodedImageFormat.Png, 100))
        {
            imageBytes = encodedData.ToArray();
        }

        return imageBytes;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
