using XMLToPDF;

var filesToProcess = BatchHelpers.GetXMlFiles();

foreach (var file in filesToProcess)
{
    var filename = Path.GetFileName(file);
    try
    {
        using (var xmlProcessor = new XMLProcessor())
        {
            await xmlProcessor.ProcessXML(file, $"{BatchHelpers.GetResourceDir()}\\Output\\{filename}.pdf");
        }           
    }
    catch(Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error for - " + filename);
        Console.ForegroundColor = ConsoleColor.White;
    }
    break;
}
