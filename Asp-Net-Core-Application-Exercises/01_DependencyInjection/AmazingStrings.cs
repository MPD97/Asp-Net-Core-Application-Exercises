using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_DependencyInjection
{
    public class AmazingStrings : IExampleInterface
    {
        public string GetExampleString()
        {
            return "I'm   ~A M A Z I N G~   character string!";
        }
    }
}
