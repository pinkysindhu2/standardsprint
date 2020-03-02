using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProjectMars.Framework.Helper
{
    public static class TestData
    {
        public static IEnumerable LoginData
        {
            get { return DataDrivenHelper.ReadXlsxDataDriveFile(PathHelper.GetCurrentPath("ExcelTestData/Seller_Test_Data.xlsx"), "Login"); }
        }
        public static IEnumerable SearchCategory
        {
            get { return DataDrivenHelper.ReadXlsxDataDriveFile(PathHelper.GetCurrentPath("SearchCategory.xlsx"), "Sheet1"); }
        }
    }
}
