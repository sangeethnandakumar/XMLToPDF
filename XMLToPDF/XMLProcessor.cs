using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using PDF.Layout;
using QRCoder;
using Razor.Templating.Core;
using System.Data;
using System.Drawing;

namespace XMLToPDF
{


    public class XMLProcessor
    {
        public async Task ProcessXML(string xmlPath, string pdfPath)
        {

            var statements = new List<FinancialStatement>();

            var detailsTable = ReadExcelSheetAsDataGrid("detail.xlsx", 0);
            var groupTable = ReadExcelSheetAsDataGrid("group.xlsx", 0);

            //Take each detail
            foreach (DataRow group in groupTable.Rows)
            {
                //Take first item from groupTable
                var primaryKey = group.ItemArray[0];
                //Check if there is a match in detailsTable
                var matchingRows = detailsTable.Rows.Cast<DataRow>()
                                    .Where(row => row.ItemArray[0].ToString() == primaryKey.ToString())
                                    .ToList();

                statements.Add(new FinancialStatement
                {
                    ReceiptID = group.ItemArray[0].ToString(),
                    FullName = group.ItemArray[1].ToString(),
                    AddressLine1 = group.ItemArray[2].ToString(),
                    City = group.ItemArray[3].ToString(),
                    State = group.ItemArray[4].ToString(),
                    ZIPCode = group.ItemArray[5].ToString(),
                    IMBarcode = group.ItemArray[6].ToString(),
                    QRContent = group.ItemArray[7].ToString(),
                    TraySort = group.ItemArray[8].ToString(),
                    Pages = int.Parse(group.ItemArray[9].ToString()),
                    Total = decimal.Parse(group.ItemArray[10].ToString()),

                    Payments = matchingRows.Select(row => new Payment
                    {
                        ReceiptID = row.ItemArray[0].ToString(),
                        Date = DateTime.Parse(row.ItemArray[1].ToString()),
                        Check = row.ItemArray[2].ToString(),
                        CheckNumber = row.ItemArray[3].ToString(),
                        Amount = decimal.Parse(row.ItemArray[4].ToString())
                    }).ToList()
                });
            }


            // Filter statements with more than 5 payments
            statements = statements.Where(s => s.Payments.Count <= 5).ToList();

            // Sort statements by TraySort order
            statements.Sort((a, b) => string.Compare(a.TraySort, b.TraySort));

            // Print out the sorted and filtered statements
            foreach (var statement in statements)
            {
                //Console.WriteLine($"ReceiptID: {statement.ReceiptID}, TraySort: {statement.TraySort}");
            }

            var considered = statements.Where(x => x.Payments.Count > 3).Take(8);
            int i = 1;
            Parallel.ForEach(considered.ToList(),
                new ParallelOptions
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount,
                },
                async s =>
                {
                    Console.WriteLine($"Converting - {s.FullName}");
                    var model = new PageResources
                    {
                        FinancialStatement = s,
                        Images = new Dictionary<string, string>()
                    };
                    
                    model.Images.Add("logo", Convert.ToBase64String(File.ReadAllBytes("logo.jpg")));
                    model.Images.Add("qrCode", GenerateQRCode(model.FinancialStatement.QRContent));

                    var html = await RazorTemplateEngine.RenderAsync("/Theme.cshtml", model);

                    PDFEngine.Generate(html, $"outputs/{i++}.pdf");
                    Console.WriteLine($"Completed - {s.FullName}");
                });          
        }

        public static string GenerateQRCode(string text, int blockSize = 5)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            var bytes = qrCode.GetGraphic(blockSize);
            return Convert.ToBase64String(bytes);
        }

        public static DataTable ReadExcelSheetAsDataGrid(string excelName, int sheetIndex)
        {
            var dtTable = new DataTable();
            using (var rstream = new FileStream(excelName, FileMode.Open, FileAccess.Read))
            {
                rstream.Position = 0;
                var xssWorkbook = new XSSFWorkbook(rstream);
                ISheet sheet = xssWorkbook.GetSheetAt(sheetIndex);

                // Create DataTable and add columns
                IRow headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;
                for (int j = 0; j < cellCount; j++)
                {
                    ICell cell = headerRow.GetCell(j);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                    dtTable.Columns.Add(cell.ToString());
                }

                // Add data rows to DataTable
                for (var i = 1; i < sheet.PhysicalNumberOfRows; i++)
                {
                    var dataRow = dtTable.NewRow();
                    for (int j = 0; j < cellCount; j++)
                    {
                        ICell cell = sheet.GetRow(i).GetCell(j);
                        if (cell == null) continue;
                        dataRow[j] = cell.ToString();
                    }
                    dtTable.Rows.Add(dataRow);
                }
                rstream.Close();
            }
            return dtTable;
        }
    }
}
