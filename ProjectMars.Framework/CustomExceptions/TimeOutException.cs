using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMars.Framework.CustomExceptions
{
    public class TimeOutException: Exception
    {
        public TimeOutException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
