using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_DependencyInjection
{
    public class NormalStrings : IExampleInterface
    {
        public string GetExampleString()
        {
            return "I'm just a casual string";
        }
    }
}
