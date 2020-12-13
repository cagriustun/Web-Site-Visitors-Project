using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebSiteVisitorsProject4.Models;
using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace WebSiteVisitorsProject4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"https://raw.githubusercontent.com/cagriustun/WebSiteData/main/data.json");
            var sites = JsonConvert.DeserializeObject<Sites>(json);
            return View(sites);
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
