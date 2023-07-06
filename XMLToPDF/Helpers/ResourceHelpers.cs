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
