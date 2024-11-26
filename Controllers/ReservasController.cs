using HermanosK.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace HermanosK.Controllers
{
    public class ReservasController : Controller
    {
        // Lista simulada para manejar las reservas
        private static List<Reserva> Reservas = new List<Reserva>
        {
            new Reserva { Id = 1, Nombre = "Playa Blanca", Precio = 350000, Categoria = "Tour", Calificacion = 4.5, Imagen = "playa_blanca.jpg" },
            new Reserva { Id = 2, Nombre = "Hotel Paradise", Precio = 500000, Categoria = "Hotel", Calificacion = 4.8, Imagen = "hotel_paradise.jpg" },
            new Reserva { Id = 3, Nombre = "Restaurante Mar Azul", Precio = 200000, Categoria = "Restaurante", Calificacion = 4.2, Imagen = "restaurante_mar_azul.jpg" }
        };

        // Página principal que muestra la lista de reservas
        public ActionResult Index()
        {
            return View(Reservas);
        }

        // Acción para filtrar reservas según criterios
        public ActionResult Filtrar(string categoria, decimal? precioMin, decimal? precioMax)
        {
            var reservasFiltradas = Reservas.AsQueryable();

            if (!string.IsNullOrEmpty(categoria))
                reservasFiltradas = reservasFiltradas.Where(r => r.Categoria.ToLower().Contains(categoria.ToLower()));

            if (precioMin.HasValue)
                reservasFiltradas = reservasFiltradas.Where(r => r.Precio >= precioMin);

            if (precioMax.HasValue)
                reservasFiltradas = reservasFiltradas.Where(r => r.Precio <= precioMax);

            return View("Index", reservasFiltradas.ToList());
        }
    }
}