using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToPDF.Helpers
{
    public static class XMLHelpers
    {
        public static string StripNonStandardNamespaces(string xml)
        {
            xml = xml.Replace("cds:", "");
            xml = xml.Replace("cdsd:", "");
            xml = xml.Replace(@" xmlns:cds=""cds"" xmlns:cdsd=""cds_dt""", "");
            xml = xml.Replace(@" xmlns=""cds"" xmlns:cdsd=""cds_dt""", "");
            xml = xml.Replace(@"xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""cds EMR_Data_Migration_Schema.xsd""", "");
            xml = xml.Replace(@"<OmdCds\n>", "<OmdCds>");
            return xml;
        }
    }
}
