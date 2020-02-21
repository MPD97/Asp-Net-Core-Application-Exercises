using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _01_DependencyInjection.Controllers
{
    public class StringController : Controller
    {
        public IExampleInterface InjectedClass { get; }

        public StringController(IExampleInterface stringClass)
        {
            InjectedClass = stringClass;
        }

        public IActionResult Default()
        {
            return Content(InjectedClass.GetExampleString());
        }
    }
}