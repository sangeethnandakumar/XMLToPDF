using DinkToPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToPDF
{
    public static class PDFEngine
    {
        public static void Generate(string html, string pdfPath)
        {
            var converter = new SynchronizedConverter(new PdfTools());

            converter.PhaseChanged += Converter_PhaseChanged;
            converter.ProgressChanged += Converter_ProgressChanged;
            converter.Finished += Converter_Finished;
            converter.Warning += Converter_Warning;
            converter.Error += Converter_Error;

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                },
                Objects = {
                    new ObjectSettings() {
                        //PagesCount = true,
                        HtmlContent = html,
                        WebSettings = { DefaultEncoding = "utf-8" },
                        //HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                        //FooterSettings = { FontSize = 9, Right = "Page [page] of [toPage]" }
                    }
                }
            };

            byte[] pdf = converter.Convert(doc);

            using (FileStream stream = new FileStream(pdfPath, FileMode.Create))
            {
                stream.Write(pdf, 0, pdf.Length);               
            }
        }

        private static void Converter_Error(object sender, DinkToPdf.EventDefinitions.ErrorArgs e)
        {
            Console.WriteLine("[ERROR] {0}", e.Message);
        }

        private static void Converter_Warning(object sender, DinkToPdf.EventDefinitions.WarningArgs e)
        {
            Console.WriteLine("[WARN] {0}", e.Message);
        }

        private static void Converter_Finished(object sender, DinkToPdf.EventDefinitions.FinishedArgs e)
        {
            Console.WriteLine("Conversion {0} ", e.Success ? "successful" : "unsucessful");
            Console.WriteLine("-----------------------------------------------------------------");
        }

        private static void Converter_ProgressChanged(object sender, DinkToPdf.EventDefinitions.ProgressChangedArgs e)
        {
            Console.WriteLine("Progress changed {0}", e.Description);
        }

        private static void Converter_PhaseChanged(object sender, DinkToPdf.EventDefinitions.PhaseChangedArgs e)
        {
            Console.WriteLine("Phase changed {0} - {1}", e.CurrentPhase, e.Description);
        }
    }
}