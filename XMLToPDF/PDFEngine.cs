namespace XMLToPDF
{
    public static class PDFEngine
    {
        public static void Generate(string html, string pdfPath)
        {
            using (var converter = new ChromeHtmlToPdfLib.Converter())
            {
                // Set the pixel dimensions of the HTML content to achieve a DPI of 300
                converter.SetWindowSize(2550, 3300); // 11 inches * 300 pixels per inch
                converter.ConvertToPdf(html, pdfPath, new ChromeHtmlToPdfLib.Settings.PageSettings
                {
                    PrintBackground = true,
                    PaperWidth = 8.5, // A4 width in inches
                    PaperHeight = 11, // A4 height in inches
                    Scale= 1,
                });
            }
        }
    }
}