namespace XMLToPDF
{
    public static class BatchHelpers
    {
        public static IEnumerable<string> GetXMlFiles()
        {
            var files = Directory.GetFiles(GetResourceDir(), "*.xml", SearchOption.TopDirectoryOnly);
            return files;
        } 

        public static string GetResourceDir()
        {
            return @"D:\XMLto PDF - Upwork E122\Job2\ResourceFiles";
        }
    }
}
