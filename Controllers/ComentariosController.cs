using HermanosK.Models;
using Microsoft.AspNetCore.Mvc;

namespace HermanosK.Controllers
{
    public class ComentariosController : Controller
    {
        private static List<Comentario> comentarios = new List<Comentario>();

        public IActionResult Index()
        {
            return View(comentarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                comentario.Id = comentarios.Count > 0 ? comentarios.Max(c => c.Id) + 1 : 1;
                comentarios.Add(comentario);
                return RedirectToAction("Index");
            }
            return View(comentario);
        }

        public IActionResult Details(int id)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == id);
            if (comentario == null)
            {
                return NotFound();
            }
            return View(comentario);
        }

        public IActionResult Edit(int id)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == id);
            if (comentario == null)
            {
                return NotFound();
            }
            return View(comentario);
        }

        [HttpPost]
        public IActionResult Edit(Comentario comentario)
        {
            var original = comentarios.FirstOrDefault(c => c.Id == comentario.Id);
            if (original == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                original.Autor = comentario.Autor;
                original.Texto = comentario.Texto;
                original.Estrellas = comentario.Estrellas;
                return RedirectToAction("Index");
            }
            return View(comentario);
        }

        public IActionResult Delete(int id)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == id);
            if (comentario == null)
            {
                return NotFound();
            }
            return View(comentario);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var comentario = comentarios.FirstOrDefault(c => c.Id == id);
            if (comentario != null)
            {
                comentarios.Remove(comentario);
            }
            return RedirectToAction("Index");
        }
    }
}
