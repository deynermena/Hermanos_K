using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HermanosK.Models;

namespace HermanosK.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

public IActionResult Index()
    {
        // Datos de ejemplo
        var features = new List<Feature>
        {
            new Feature 
            { 
                Title = "Miembros de excelencia", 
                Description = "Nuestro equipo está comprometido con brindar el mejor servicio",
                IconClass = "fa-star"
            },
            new Feature 
            { 
                Title = "Buena relación con los clientes", 
                Description = "Construimos relaciones duraderas con nuestros clientes",
                IconClass = "fa-users"
            },
            new Feature 
            { 
                Title = "Excelentes servicios y equipos", 
                Description = "Contamos con los mejores equipos y servicios",
                IconClass = "fa-check-circle"
            }
        };

        var services = new List<Service>
        {
            new Service 
            { 
                Name = "Playa Blanca", 
                Description = "Descubre las hermosas playas",
                ImageUrl = "/images/playa blanca.jpg"
            },
            new Service 
            { 
                Name = "Guachalito", 
                Description = "Explora la historia",
                ImageUrl = "/images/guachalito.jpg"
            },
            new Service 
            { 
                Name = "Morromico", 
                Description = "Aventura natural",
                ImageUrl = "/images/morromico.jpg"
            }
        };

        var viewModel = new HomeViewModel
        {
            Features = features,
            Services = services
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
