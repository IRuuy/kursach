using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;

namespace WeatherMonitoring.Assets.Utils
{
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
