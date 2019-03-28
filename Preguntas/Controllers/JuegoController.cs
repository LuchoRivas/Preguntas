using Preguntas.Models;
using Preguntas.Models.Dominio;
using Preguntas.Models.Dominio.ViewModels.Preguntas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Preguntas.Controllers
{
    public class JuegoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Juego
        public ActionResult Index()
        {
            return Content("Juego creado! <a href='/Juego/Create'>volver</a>");
        }
        public ActionResult Create()
        {
            var model = new JuegoABMViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(JuegoABMViewModel model)
        {
            if (ModelState.IsValid)
            {
                var juegos = new Juego(model);
                db.Juegos.Add(juegos);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}