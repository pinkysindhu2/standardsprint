using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace ProjectMars.Framework.Helper
{
    public class CategoryTable
    {
        public string CategoryName { get;  set; }
        public string CategoryIndex { get; set; }
    }
    // This is used for the vertical table data eg: |username| pinky|
/*    public class TableExtension
    {
        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }
    }*/
}
