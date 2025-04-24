using BibliotecaUTN.Datos;
using Microsoft.AspNetCore.Mvc;
using BibliotecaUTN.Models;

namespace BibliotecaUTN.Controllers
{
    public class AutorController : Controller
    {
        public BibliotecaDatos _DB = new BibliotecaDatos();

        //GET - LIST
        public IActionResult Index()
        {
            return View(_DB.ListAutores(0)); // 0 para no entrar al if
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        public IActionResult Create(Autor autor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                ViewBag.Error = _DB.CreateAutor(autor); //en el viewbag se muestra el mensaje de error del metodo
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
        public IActionResult Details(int id) //modificar en el idex.html de autor la parte final donde el details esta comentado
        {
            return View(_DB.ListAutores(id).FirstOrDefault()); //FirstOrDefault para que no devuelva una lista
        }

        //GET - EDIT
        public IActionResult Edit(int id)
        {
            return View(_DB.ListAutores(id).FirstOrDefault());
        }

        // POST - EDIT
        [HttpPost]
        public IActionResult Edit(Autor autor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                ViewBag.Error = _DB.EditAutor(autor);
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
            return View(_DB.ListAutores(id).FirstOrDefault());
        }

        // POST - DELETE
        [HttpPost, ActionName("Delete")] //Ya que tienen el mismo nombre y reciben el mismo tipo de dato hay que hacer esto
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (_DB.ListAutores(id).Any())
                {
                    ViewBag.Error = _DB.DeleteAutor(id);
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
