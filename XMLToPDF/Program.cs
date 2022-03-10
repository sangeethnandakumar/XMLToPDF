using Cocona;
using XMLToPDF;

public class Program
{
    public static async Task Main(string[] args)
    {
        CoconaApp.Run(async (string xmlPath, string pdfPath) => await new XMLProcessor().ProcessXML(xmlPath, pdfPath));
    }
}