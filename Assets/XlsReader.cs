using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Cells;
using DocumentFormat.OpenXml.Bibliography;
//using DocumentFormat.OpenXml.Spreadsheet;

namespace WeatherMonitoring.Assets
{
    public static class XlsReader
    {
        public static Dictionary<string, string> GetData(FileInfo file, DateTime date)
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
}
