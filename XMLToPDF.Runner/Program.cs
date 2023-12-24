using System.Diagnostics;
using XMLToPDF.Runner;

var XML_PATH = @"D:\Kalin\New\Milestone 3\XML";
var PDF_PATH = @"D:\Kalin\New\Milestone 3\PDF";
var FAILED_PATH = @"D:\Kalin\New\Milestone 3\FAILED";

var APP = @"C:\Users\Sangeeth Nandakumar\source\repos\PDFTools\XMLToPDF\XMLToPDF\bin\Debug\net6.0\XMLToPDF.exe";

GetUnmatchedXmlFiles(XML_PATH, PDF_PATH, FAILED_PATH);

var xmlFiles = BatchHelpers.GetXMlFiles(XML_PATH);

Parallel.ForEach(xmlFiles, new ParallelOptions { MaxDegreeOfParallelism=100 }, xml =>
{
    Console.WriteLine("Starting - " + xml);
    var processStartInfo = new ProcessStartInfo
    {
        FileName = APP,
        Arguments = $"--xml-path=\"{xml}\" --pdf-path=\"{PDF_PATH}\\{Path.GetFileNameWithoutExtension(xml)}.pdf\"",
        RedirectStandardOutput = true,
        UseShellExecute = false
    };
    var process = new Process();
    process.OutputDataReceived += (sender, a) => Console.WriteLine(a.Data);
    process.StartInfo = processStartInfo;
    process.Start();

    while (!process.StandardOutput.EndOfStream)
    {
        var nextLine = process.StandardOutput.ReadLine();
        Console.WriteLine(nextLine);
    }

    process.WaitForExit();
});

Console.Read();

static List<string> GetUnmatchedXmlFiles(string xmlPath, string pdfPath, string newFolderPath)
{
    // Get all XML and PDF filenames without extensions
    var xmlFiles = Directory.GetFiles(xmlPath, "*.xml").Select(Path.GetFileNameWithoutExtension);
    var pdfFiles = Directory.GetFiles(pdfPath, "*.pdf").Select(Path.GetFileNameWithoutExtension);

    // Find XML files that don't have a matching PDF file
    var unmatchedXmlFiles = xmlFiles.Except(pdfFiles).ToList();

    // Create the new folder if it doesn't exist
    if (!Directory.Exists(newFolderPath))
    {
        Directory.CreateDirectory(newFolderPath);
    }

    // Move the unmatched XML files to the new folder
    foreach (var file in unmatchedXmlFiles)
    {
        var sourcePath = Path.Combine(xmlPath, file + ".xml");
        var destinationPath = Path.Combine(newFolderPath, file + ".xml");
        File.Move(sourcePath, destinationPath);
    }

    return unmatchedXmlFiles;
}
