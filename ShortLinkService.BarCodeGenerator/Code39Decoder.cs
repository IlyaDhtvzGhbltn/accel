using System;
using System.Linq;
using System.Drawing;
using System.Text.RegularExpressions;
using ShortLinkService.Dto.Interfaces;
using System.Threading.Tasks;

namespace ShortLinkService.BarCodeGenerator.Decoding
{
    public class Code39Decoder : IBitmapCodeGenerator
    {
        private readonly int lineBetweenChars = 1;
        private readonly int linesInOneChar = 15;
        private readonly Regex regex = new Regex("^[\\w, \\d, \\s]{0,}$");


        public Bitmap GenerateCode(string regularText, int resizeParameter)
        {
            // Any Code39 starts and ends with an asterisk.
            // Between two chars in code39 stay one white small line.

            //All small white lines between chars width
            int dividesWidth = (regularText.Length - 1) * lineBetweenChars;

            // Any Code39 character contains 15 small lines.
            int width = (regularText.Length * lineBetweenChars * linesInOneChar) + dividesWidth;
            using (var code39 = new Bitmap(width, 1))
            {
                int betweenCharsSpace = 0;
                for (int charIndx = 0; charIndx < regularText.Length; charIndx++)
                {
                    char @char = regularText[charIndx];
                    var item = Code39Constants.Code39CharSet.FirstOrDefault(x => x.Value == @char);
                    bool[] trueFallseArr = item.Key;

                    for (int flagIndx = 0; flagIndx < trueFallseArr.Length; flagIndx++)
                    {
                        var color = Code39Constants.BlackWhitePixel[trueFallseArr[flagIndx]];
                        for (int pxPos = 0; pxPos < lineBetweenChars; pxPos++)
                        {
                            code39.SetPixel((charIndx * linesInOneChar * lineBetweenChars) + flagIndx + pxPos + betweenCharsSpace, 0, color);
                        }
                    }
                    betweenCharsSpace += lineBetweenChars;
                }
                return Resize(code39, resizeParameter);
            }
        }

        private void Validate(string decodedText) 
        {
            bool valid = regex.IsMatch(decodedText);
            if (!valid)
            {
                throw new FormatException("Decoded Text contains invalid characters. Only latin, digits and spaces supported.");
            }
        }

        private Bitmap Resize(Bitmap b, int height = 30) 
        {
            Bitmap resized = new Bitmap(b, new Size(b.Width, height));
            return resized;
        }
    }
}
