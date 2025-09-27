using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visit.Shared
{
    public static class ErrorException
    {
        public static void AddLog(this Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
