using Preguntas.Models.Dominio;
using Preguntas.Models.Dominio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Preguntas.Controllers
{
    public class GeolocalizacionController : BaseController
    {
        [HttpPost]
        public ActionResult AlmacenarUbicaciones()
        {
            var model = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UbicacionUsuarioViewModel>>(this.Contenido);
            Guid userid = new Guid(usuarioId);
            var usuario = db.Usuarios.Where(u => u.UsuarioApp.Id == usuarioId).First();

            foreach (var item in model)
            {
                var ubicacion = new Geolocalizacion
                {
                    Latitud = item.Latitud,
                    Longitud = item.Longitud,
                    Usuario = usuario,
                    FechaHora = Convert.ToDateTime(item.FechaHora)
                };
                db.Geolocalizacion.Add(ubicacion);
                db.SaveChanges();
            }

            return Json(new { Result = "OK", Error = "" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtenerHistorial()
        {
            var coordenadas = db.Geolocalizacion.Where(c => c.Usuario.UsuarioApp.Id == usuarioId).ToList();
            var model = new List<UbicacionUsuarioViewModel>();

            foreach (var item in coordenadas)
            {
                var locacion = new UbicacionUsuarioViewModel()
                {
                    Latitud = item.Latitud,
                    Longitud = item.Longitud,
                    FechaHora = item.FechaHora.ToString(),
                    Usuario = item.Usuario
                };
                model.Add(locacion);
            }

            return Json(new { Result = model, Error = "" }, JsonRequestBehavior.AllowGet);
        }
    }
}