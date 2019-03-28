using Preguntas.Models;
using Preguntas.Models.Dominio;
using Preguntas.Models.Dominio.ViewModels.Preguntas;
using Preguntas.Models.ViewModels.Preguntas;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace Preguntas.Controllers
{
    public class PreguntaController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Respuesta
        public ActionResult Index()
        {
            var preguntas = db.Preguntas.Select(Pregunta => new PreguntasGrillaViewModel
            {
                Id = Pregunta.Id,
                Nombre = Pregunta.Nombre,
                Puntaje = Pregunta.Puntaje

            }).ToList();
            return View(preguntas);
        }
        public ActionResult Create()
        {
            return View();
        }

        // Lista de juegos
        public ActionResult ListaJuegos()
        {
            var selectjuegos = db.Juegos.Select(p => new {
                Id = p.Id,
                Nombre = p.Nombre
            }).ToList();
            return Json(new { Result = selectjuegos, Error = "" }, JsonRequestBehavior.AllowGet);
        }

        // Crear Pregunta
        [HttpPost]
        public ActionResult Create(PreguntaABMViewModel preg)
        {
                var pregunta = new Pregunta(preg, db);

                db.Preguntas.Add(pregunta);
                db.SaveChanges();

            return Json(new { Result = "OK", Error = "" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete (Guid Id)
        {
            var preg = db.Preguntas.Find(Id);
            db.Preguntas.Remove(preg);
            db.SaveChanges();

            return Json(new { Result = "OK", Error = "" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(Guid Id)
        {
            var pregunta = db.Preguntas.Find(Id);
            var model = pregunta.CovertirAViewModel();

            return View(model);
        }
    }
}