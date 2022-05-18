using System.Diagnostics;
using XMLToPDF.Runner;

var DIRECTORY = @"D:\XMLto PDF - Upwork E122\Job3\ResourceFiles";
var APP = @"D:\XMLto PDF - Upwork E122\Job2\XMLToPDF\XMLToPDF\bin\x64\Release\net6.0\XMLToPDF.exe";


var xmlFiles = BatchHelpers.GetXMlFiles(DIRECTORY);

foreach (var xml in xmlFiles)
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
}

Console.Read();