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
    public class RespuestaController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Respuesta
        public ActionResult Index()
        {
            var respuestas = db.Respuestas.Select(Respuestas => new RespuestaABMViewModel
            {
                Nombre = Respuestas.Nombre,
            }).ToList();
            return View(respuestas);
        }
        public ActionResult Create()
        {
            var model = new RespuestaABMViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(RespuestaABMViewModel model)
        {
            if (ModelState.IsValid)
            {
                var respuestas = new Respuesta(model);
                db.Respuestas.Add(respuestas);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }
        //public ActionResult Edit(Guid id)
        //{
        //    var respuestas = db.Respuestas.Find(id);
        //    var model = respuestas.ConvertirAViewModel();

        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Edit(RespuestaABMViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var respuestas = db.Respuestas.Find(model.Id);
        //        respuestas.Nombre = model.Respuesta;

        //        db.SaveChanges();

        //        return RedirectToAction("Index");
        //    }

        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Delete(Guid id)
        //{
        //    var respuestas = db.Respuestas.Find(id);
        //    db.Respuestas.Remove(respuestas);
        //    db.SaveChanges();

        //    return Json(new { Result = "OK", Error = "" }, JsonRequestBehavior.AllowGet);
        //}
    }
}