using BibliotecaUTN.Datos;
using BibliotecaUTN.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaUTN.Controllers
{
    public class LibroController : Controller
    {
        public BibliotecaDatos _DB = new BibliotecaDatos();

        //GET - LIST
        public IActionResult Index()
        {
            return View(_DB.ListLibro(0));
        }

        //GET - CREATE
        public IActionResult Create()
        {
            ViewBag.Editorial = _DB.ListEditorial(0);
            ViewBag.Autor = _DB.ListAutores(0);
            ViewBag.Genero = _DB.ListGenero(0);
            ViewBag.Ubicacion = _DB.ListUbicacion(0);
            return View();
        }

        //POST - CREATE
        [HttpPost]
        public IActionResult Create(Libro libro)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                ViewBag.Error = _DB.CreateLibro(libro);
                if (ViewBag.Error != "")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {

                return View();
            }
        }

        //GET - DETAILS
        public IActionResult Details(int id) 
        {
            return View(_DB.ListLibro(id).FirstOrDefault());
        }

        //GET - EDIT
        public IActionResult Edit(int id)
        {
            ViewBag.Editorial = _DB.ListEditorial(0);
            ViewBag.Autor = _DB.ListAutores(0);
            ViewBag.Genero = _DB.ListGenero(0);
            ViewBag.Ubicacion = _DB.ListUbicacion(0);
            return View(_DB.ListLibro(id).FirstOrDefault());
        }

        // POST - EDIT
        [HttpPost]
        public IActionResult Edit(Libro libro)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                ViewBag.Error = _DB.EditLibro(libro);
                if (ViewBag.Error != "")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

        }

        // GET - DELETE
        public IActionResult Delete(int id)
        {
            return View(_DB.ListLibro(id).FirstOrDefault());
        }

        // POST - DELETE
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (_DB.ListLibro(id).Any())
                {
                    ViewBag.Error = _DB.DeleteLibro(id);
                    if (ViewBag.Error != "")
                    {
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
