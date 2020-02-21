using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _01_DependencyInjection.Controllers
{
    public class StringController : Controller
    {
        public IExampleInterface StringContext { get; }

        public StringController(IExampleInterface stringClass)
        {
            StringContext = stringClass;
        }

        public IActionResult Default()
        {
            ViewData["Result"] = StringContext.GetExampleString();
            return View();
        }
    }
}