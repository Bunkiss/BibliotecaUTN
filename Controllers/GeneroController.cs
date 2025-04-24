using BibliotecaUTN.Datos;
using BibliotecaUTN.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaUTN.Controllers
{
    public class GeneroController : Controller
    {
        public BibliotecaDatos _DB = new BibliotecaDatos();

        //GET - LIST
        public IActionResult Index()
        {
            return View(_DB.ListGenero(0));
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        public IActionResult Create(Genero genero)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                ViewBag.Error = _DB.CreateGenero(genero);
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
            return View(_DB.ListGenero(id).FirstOrDefault()); 
        }

        //GET - EDIT
        public IActionResult Edit(int id)
        {
            return View(_DB.ListGenero(id).FirstOrDefault());
        }

        // POST - EDIT
        [HttpPost]
        public IActionResult Edit(Genero genero)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                ViewBag.Error = _DB.EditGenero(genero);
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
            return View(_DB.ListGenero(id).FirstOrDefault());
        }

        // POST - DELETE
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (_DB.ListGenero(id).Any())
                {
                    ViewBag.Error = _DB.DeleteGenero(id);
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
