using PDF.Layout;
using Razor.Templating.Core;
using System.Xml.Serialization;
using XMLToPDF.Helpers;

namespace XMLToPDF
{
    public class XMLProcessor
    {
        public async Task ProcessXML(string xmlPath, string pdfPath)
        {
            Console.WriteLine("TASK STARTED - " + Path.GetFileName(xmlPath));

            //Reading XML
            Console.WriteLine("Reading XML file");
            var xml = File.ReadAllText(xmlPath);

            //Cleaning XML
            Console.WriteLine("Cleaning XML file");
            xml = XMLHelpers.StripNonStandardNamespaces(xml);
            File.WriteAllText(xmlPath, xml);

            //Deserializing XML
            Console.WriteLine("Deserializing XML file");
            XmlSerializer serializer = new XmlSerializer(typeof(OmdCds));
            try
            {
                using (Stream reader = new FileStream(xmlPath, FileMode.Open))
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
                                Console.WriteLine(ex);
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
                                Console.WriteLine(ex);
                                report.Content.Media = null;
                            }
                        }
                    }

                    //Generate SourceMaps
                    Console.WriteLine("Generating Sourcemaps");
                    var html = await RazorTemplateEngine.RenderAsync("/Theme.cshtml", model);

                    PDFEngine.Generate(html, pdfPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
            }
        }
    }
}
