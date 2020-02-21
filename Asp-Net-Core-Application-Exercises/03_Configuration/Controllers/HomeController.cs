using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace _03_Configuration.Controllers
{
    public class HomeController : Controller
    {
       public IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            CustomSettings settings = new CustomSettings();
            Configuration.GetSection("CustomConfig").Bind(settings);

            return Content($"CreatedDate: {settings.CreatedDate} \r\n" +
                $"GitHubUrl: {settings.GitHubUrl}");
        }
    }
}