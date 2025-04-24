using BibliotecaUTN.Datos;
using BibliotecaUTN.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaUTN.Controllers
{
    public class UbicacionController : Controller
    {
        public BibliotecaDatos _DB = new BibliotecaDatos();

        //GET - LIST
        public IActionResult Index()
        {
            return View(_DB.ListUbicacion(0));
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        public IActionResult Create(Ubicacion ubicacion)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                ViewBag.Error = _DB.CreateUbicacion(ubicacion);
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
            return View(_DB.ListUbicacion(id).FirstOrDefault());
        }

        //GET - EDIT
        public IActionResult Edit(int id)
        {
            return View(_DB.ListUbicacion(id).FirstOrDefault());
        }

        // POST - EDIT
        [HttpPost]
        public IActionResult Edit(Ubicacion ubicacion)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                ViewBag.Error = _DB.EditUbicacion(ubicacion);
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
            return View(_DB.ListUbicacion(id).FirstOrDefault());
        }

        // POST - DELETE
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (_DB.ListUbicacion(id).Any())
                {
                    ViewBag.Error = _DB.DeleteUbicacion(id);
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
