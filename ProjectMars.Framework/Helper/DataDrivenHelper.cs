using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NUnit.Framework;

namespace ProjectMars.Framework.Helper
{
    public class DataDrivenHelper
    {
        /// <summary>
        /// Reads the Excel data drive file and optionaly set test name.
        /// </summary>
        /// <param name="path">Full path to Excel DataDriveFile file</param>
        /// <param name="sheetName">Name of the sheet at xlsx file.</param>
        /// <param name="diffParam">Optional values of listed parameters will be used in test case name.</param>
        /// <param name="testName">Optional name of the test, use as prefix for test case name.</param>
        /// <returns>
        /// IEnumerable TestCaseData
        /// </returns>
        /// <exception cref="System.InvalidOperationException">Exception when wrong cell type in file</exception>
        /// <exception cref="DataDrivenReadException">Exception when parameter not found in row</exception>
        public static IEnumerable<TestCaseData> ReadXlsxDataDriveFile(string path, string sheetName, [Optional] string[] diffParam, [Optional] string testName)
        {
            XSSFWorkbook wb;

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                wb = new XSSFWorkbook(fs);
            }

            // get sheet
            var sh = (XSSFSheet)wb.GetSheet(sheetName);

            int startRow = 1;
            int startCol = 0;
            int totalRows = sh.LastRowNum;
            int totalCols = sh.GetRow(0).LastCellNum;

            var row = 1;
            for (int i = startRow; i <= totalRows; i++, row++)
            {
                var column = 0;
                var testParams = new Dictionary<string, string>();
                for (int j = startCol; j < totalCols; j++, column++)
                {
                    if (sh.GetRow(0).GetCell(column).CellType != CellType.String)
                    {
                        throw new InvalidOperationException(string.Format("Cell with name of parameter must be string only, file {0} at sheet {1} row {2} column {3}", path, sheetName, 0, column));
                    }

                    var cellType = sh.GetRow(row).GetCell(column).CellType;
                    switch (cellType)
                    {
                        case CellType.String:
                            testParams.Add(sh.GetRow(0).GetCell(column).StringCellValue, sh.GetRow(row).GetCell(column).StringCellValue);
                            break;
                        case CellType.Numeric:
                            testParams.Add(sh.GetRow(0).GetCell(column).StringCellValue, sh.GetRow(row).GetCell(column).NumericCellValue.ToString(CultureInfo.CurrentCulture));
                            break;
                        default:
                            throw new InvalidOperationException(string.Format("Not supported cell type {0} in file {1} at sheet {2} row {3} column {4}", cellType, path, sheetName, row, column));
                    }
                }

                // set test name
                var testCaseName = string.IsNullOrEmpty(testName) ? sheetName : testName;

                if (diffParam != null && diffParam.Any())
                {
                    try
                    {
                        testCaseName = TestCaseName(diffParam, testParams, testCaseName);
                    }
                    catch (DataDrivenReadException e)
                    {
                        throw new DataDrivenReadException(
                            string.Format(
                                " Exception while reading Excel Data Driven file\n searched key '{0}' not found at sheet '{1}' \n for test {2} in file '{3}' at row {4}",
                                e.Message,
                                sheetName,
                                testName,
                                path,
                                row));
                    }
                }
                else
                {
                    testCaseName = testCaseName + "_row(" + row + ")";
                }

                var data = new TestCaseData(testParams);
                data.SetName(testCaseName);
                yield return data;
            }
        }

        /// <summary>
        /// Get the name of test case from value of parameters.
        /// </summary>
        /// <param name="diffParam">The difference parameter.</param>
        /// <param name="testParams">The test parameters.</param>
        /// <param name="testCaseName">Name of the test case.</param>
        /// <returns>Test case name</returns>
        /// <exception cref="NullReferenceException">Exception when trying to set test case name</exception>
        private static string TestCaseName(string[] diffParam, Dictionary<string, string> testParams, string testCaseName)
        {
            if (diffParam != null && diffParam.Any())
            {
                foreach (var p in diffParam)
                {
                    string keyValue;
                    bool keyFlag = testParams.TryGetValue(p, out keyValue);

                    if (keyFlag)
                    {
                        if (!string.IsNullOrEmpty(keyValue))
                        {
                            testCaseName += "_" + Regex.Replace(keyValue, "[^0-9a-zA-Z]+", "_");
                        }
                    }
                    else
                    {
                        throw new DataDrivenReadException(p);
                    }
                }
            }

            return testCaseName;
        } 
    }

}

