using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMars.Framework.Helper
{
    public class DataDrivenReadException: Exception
    {
        public DataDrivenReadException(string errorMessage )
        {
            Console.WriteLine(errorMessage);
        }
    }
}
