using System;
using System.Collections.Generic;

namespace PDF.Layout
{
    public class PageResources
    {
        public Dictionary<string, string> Images { get; set; }
        public List<string> Styles { get; set; } = new List<string>();
        public FinancialStatement FinancialStatement { get; set; }
    }

    public class FinancialStatement
    {
        public string ReceiptID { get; set; }
        public string FullName { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIPCode { get; set; }
        public string IMBarcode { get; set; }
        public string QRContent { get; set; }
        public string TraySort { get; set; }
        public int Pages { get; set; }
        public decimal Total { get; set; }
        public List<Payment> Payments { get; set; }
    }

    public class Payment
    {
        public string ReceiptID { get; set; }
        public DateTime Date { get; set; }
        public string Check { get; set; }
        public string CheckNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
