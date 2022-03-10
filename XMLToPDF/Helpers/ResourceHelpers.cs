using Ghostscript.NET;
using Ghostscript.NET.Rasterizer;
using System.Drawing;
using System.Drawing.Imaging;

namespace XMLToPDF.Helpers
{
    public static class ResourceHelpers
    {
        public static string ConvertTiffToJpeg(string base64)
        {
            var bitMap = Base64ToBitmap(base64);
            MemoryStream ms = new MemoryStream();
            bitMap.Save(ms, ImageFormat.Jpeg);
            byte[] byteImage = ms.ToArray();
            var SigBase64 = Convert.ToBase64String(byteImage);
            return SigBase64;
        }
        public static List<string> ConvertPDFToJpegs(string base64)
        {
            var result = new List<string>();
            int desired_dpi = 120;
            byte[] byteBuffer = Convert.FromBase64String(base64);

            GhostscriptVersionInfo gvi = new GhostscriptVersionInfo(@"gsdll64.dll");
            using (var rasterizer = new GhostscriptRasterizer())
            {
                rasterizer.Open(new MemoryStream(byteBuffer), gvi, false);
                for (var pageNumber = 1; pageNumber <= rasterizer.PageCount; pageNumber++)
                {
                    var img = rasterizer.GetPage(desired_dpi, pageNumber);
                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, ImageFormat.Jpeg);
                    byte[] byteImage = ms.ToArray();
                    var SigBase64 = Convert.ToBase64String(byteImage);
                    result.Add(SigBase64);
                }
            }
            return result;
        }

        private static Bitmap Base64ToBitmap(string base64String)
        {
            Bitmap bmpReturn = null;
            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);
            memoryStream.Position = 0;
            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);
            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;
            return bmpReturn;
        }

    }
}
