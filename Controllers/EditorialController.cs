using BibliotecaUTN.Datos;
using Microsoft.AspNetCore.Mvc;
using BibliotecaUTN.Models;

namespace BibliotecaUTN.Controllers
{
    public class EditorialController : Controller
    {
        public BibliotecaDatos _DB = new BibliotecaDatos();

        //GET - LIST
        public IActionResult Index()
        {
            return View(_DB.ListEditorial(0));
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        public IActionResult Create(Editorial editorial)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                ViewBag.Error = _DB.CreateEditorial(editorial);
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
            return View(_DB.ListEditorial(id).FirstOrDefault());
        }

        //GET - EDIT
        public IActionResult Edit(int id)
        {
            return View(_DB.ListEditorial(id).FirstOrDefault());
        }

        // POST - EDIT
        [HttpPost]
        public IActionResult Edit(Editorial editorial)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                ViewBag.Error = _DB.EditEditorial(editorial);
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
            return View(_DB.ListEditorial(id).FirstOrDefault());
        }

        // POST - DELETE
        [HttpPost, ActionName("Delete")] 
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (_DB.ListEditorial(id).Any())
                {
                    ViewBag.Error = _DB.DeleteEditorial(id);
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
