using System.Drawing;
using System.Threading.Tasks;

namespace ShortLinkService.Dto.Interfaces
{
    public interface IBitmapCodeGenerator
    {
        /// <summary>
        /// Generates some Code by value and returns Bitmap code representation.
        /// Exact format (Barcode, QRCode etc) depends on implementation.
        /// </summary>
        /// <param name="value">Original link</param>
        /// <param name="resizeParam">Resize parameter sets Height</param>
        /// <returns></returns>
        Bitmap GenerateCode(string value, int resizeParam);
    }
}
