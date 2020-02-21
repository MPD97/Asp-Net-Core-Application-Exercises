using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _02_Logging.Controllers
{
    public class HomeController : Controller
    {
        ILogger<HomeController> Logger { get; }

        public HomeController(ILogger<HomeController> logger)
        {
            Logger = logger;
        }
        public IActionResult Information()
        {
            string text = "Information";

            Logger.LogInformation(text);

            return StatusCode(200, text);
        }
        public IActionResult Warrning()
        {
            string text = "Warrning";

            Logger.LogWarning(text);

            return StatusCode(400, text);
        }
        public IActionResult Error()
        {
            string text = "Error";

            Logger.LogError(text);

            return StatusCode(500, text);
        }

    }
}