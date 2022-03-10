using DinkToPdf;
using PDF.Layout;
using Razor.Templating.Core;
using System.Xml.Serialization;
using XMLToPDF.Helpers;

namespace XMLToPDF
{
    public class XMLProcessor : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task ProcessXML(string inputFile, string outputFile)
        {
            Console.WriteLine("TASK STARTED - " + Path.GetFileName(inputFile));
            //Reading XML
            Console.WriteLine("Reading XML file");
            var xml = File.ReadAllText(inputFile);

            //Cleaning XML
            Console.WriteLine("Cleaning XML file");
            xml = XMLHelpers.StripNonStandardNamespaces(xml);
            File.WriteAllText(inputFile, xml);

            //Deserializing XML
            Console.WriteLine("Deserializing XML file");
            XmlSerializer serializer = new XmlSerializer(typeof(OmdCds));
            using (Stream reader = new FileStream(inputFile, FileMode.Open))
            {
                var model = serializer.Deserialize(reader) as OmdCds;
                //Convert Resources
                Console.WriteLine("Converting TIF and PDF resources");
                foreach (var report in model.PatientRecord.ReportsReceived)
                {
                    if (report.FileExtensionAndVersion == ".TIF")
                    {
                        try
                        {
                            report.Content.Media = ResourceHelpers.ConvertTiffToJpeg(report.Content.Media);
                        }
                        catch (Exception ex)
                        {
                            report.Content.Media = null;
                        }                       
                    }
                    else if (report.FileExtensionAndVersion == ".pdf")
                    {
                        try
                        {
                            report.Content.PDFPages = ResourceHelpers.ConvertPDFToJpegs(report.Content.Media);
                        }
                        catch (Exception ex)
                        {
                            report.Content.Media = null;
                        }
                    }
                }
                //Generate SourceMaps
                Console.WriteLine("Generating Sourcemaps");
                var html = await RazorTemplateEngine.RenderAsync("/Theme.cshtml", model);
                var converter = new BasicConverter(new PdfTools());
                var options = new HtmlToPdfDocument
                {
                    GlobalSettings =
                     {
                        ColorMode = ColorMode.Color,
                        Orientation = Orientation.Portrait,
                        PaperSize = PaperKind.A4,
                        Out = outputFile
                    },
                    Objects =
                    {
                        new ObjectSettings {
                          PagesCount=true,
                          HtmlContent = html,
                          WebSettings = {DefaultEncoding="UTF-8"}
                        }
                    }
                };

                //Build PDF
                Console.WriteLine("Generating PDF");

                converter.Convert(options);
                //Build PDF
                Console.WriteLine("Cleaning Memory");
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Completed");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
