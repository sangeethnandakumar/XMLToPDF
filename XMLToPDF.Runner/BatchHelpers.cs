namespace XMLToPDF.Runner
{
    public static class BatchHelpers
    {
        public static IEnumerable<string> GetXMlFiles(string directory)
        {
            var files = Directory.GetFiles(directory, "*.xml", SearchOption.TopDirectoryOnly);
            return files;
        } 
    }
}
