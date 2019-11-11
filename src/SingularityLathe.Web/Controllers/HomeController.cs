using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SingularityLathe.Forge.StellarForge.Services;
using SingularityLathe.Web.Models;

namespace SingularityLathe.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StarSystemBuilderService starSystemBuilderService = null;

        public HomeController(ILogger<HomeController> logger, StarSystemBuilderService starSystemBuilderService)
        {
            this.starSystemBuilderService = starSystemBuilderService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var system = starSystemBuilderService.GenerateStar().GenerateSystem().Build();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
