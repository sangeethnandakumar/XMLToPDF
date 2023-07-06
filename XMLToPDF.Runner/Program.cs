using System.Diagnostics;
using XMLToPDF.Runner;

var DIRECTORY = @"D:\Kalin\Zip1";
var APP = @"C:\Users\Sangeeth Nandakumar\source\repos\PDFTools\XMLToPDF\XMLToPDF\bin\Debug\net6.0\XMLToPDF.exe";


var xmlFiles = BatchHelpers.GetXMlFiles(DIRECTORY);

Parallel.ForEach(xmlFiles, xml =>
{
    Console.WriteLine("Starting - " + xml);
    var processStartInfo = new ProcessStartInfo
    {
        FileName = APP,
        Arguments = $"--xml-path=\"{xml}\" --pdf-path=\"{xml}.pdf\"",
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