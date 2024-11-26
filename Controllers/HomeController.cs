using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HermanosK.Models;
using HermanosK.Models.ViewModels;
using HermanosK.Services;
using System.Threading.Tasks;

namespace HermanosK.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeatureService _featureService;
        private readonly IServiceService _serviceService;

        public HomeController(
            ILogger<HomeController> logger,
            IFeatureService featureService,
            IServiceService serviceService)
        {
            _logger = logger;
            _featureService = featureService;
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel
            {
                Features = await _featureService.GetFeaturesAsync(),
                Services = await _serviceService.GetServicesAsync()
            };

            return View(viewModel);
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
