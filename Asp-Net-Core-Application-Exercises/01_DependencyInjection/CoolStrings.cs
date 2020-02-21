using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_DependencyInjection
{
    public class CoolStrings : IExampleInterface
    {
        public string GetExampleString()
        {
            return "I'm really cool character string";
        }
    }
}
