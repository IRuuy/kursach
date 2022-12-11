using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using Aspose.Cells;
//using DocumentFormat.OpenXml.Bibliography;
//using DocumentFormat.OpenXml.Spreadsheet;
using ClosedXML.Excel;

namespace WeatherMonitoring.Assets
{
/*    public class XlsReader
    {
        public Dictionary<string, string> GetData(FileInfo file, DateTime date)
        {

            Worksheet worksheet = new Workbook(file.FullName).Worksheets[0];
            const int base_row = 0;

            var keys = new List<string>();
            var data = new Dictionary<string, string>();

            int MaxRows = worksheet.Cells.MaxDataRow;
            int MaxCols = worksheet.Cells.MaxDataColumn;

            for (int col = 0; col <= MaxCols; col++)
                keys.Add(worksheet.Cells[base_row, col].Value.ToString());

            for (int row = 1; row <= MaxRows; row++)
                for (int col = 0; col <= MaxCols; col++)
                    if(DateTime.Compare(DateTime.Parse(worksheet.Cells[row, 0].Value.ToString()), date) == 0)
                        data.Add(keys[col], worksheet.Cells[row, col].Value.ToString());
            return data;
        }
    }
*/
    public static class XlsReader
    {
        public static Dictionary<string, string> GetData(FileInfo file, DateTime date)
        {

            var worksheet = new XLWorkbook(file.FullName).Worksheet(1);

            const int base_row = 1;

            var keys = new List<string>();
            var data = new Dictionary<string, string>();
            int MaxRows = worksheet.Rows().Count();
            int MaxCols = worksheet.Columns().Count();
            for (int col = 1; col < MaxCols; col++)
                keys.Add(worksheet.Cell(base_row, col).Value.ToString());

            for (int row = base_row+1; row < MaxRows; row++)
                for (int col = 0; col < MaxCols-1; col++)
                    if (DateTime.Compare(DateTime.Parse(worksheet.Cell(row, 1).Value.ToString()), date) == 0)
                        data.Add(keys[col], worksheet.Cell(row, col+1).Value.ToString());
            return data;
        }
    }
}
