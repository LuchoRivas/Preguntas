using Microsoft.AspNet.Identity;
using Preguntas.Models.Dominio;
using Preguntas.Models.Dominio.ViewModels;
using Preguntas.Models.Dominio.ViewModels.Preguntas;
using Preguntas.Models.General;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Preguntas.Controllers
{
    public class JugarController : BaseController
    {
        // GET: Jugar
        // Muestra las categorias para comenzar
        public ActionResult Index()
        {
            var seleccionarjuegos = db.Juegos.Select(Juego => new SelectBoxViewModel
            {
                Id = Juego.Id,
                Nombre = Juego.Nombre
            }).ToList();
            return View(seleccionarjuegos);
        }

        public ActionResult IndexMobile()
        {
            var seleccionarjuegos = db.Juegos.Select(Juego => new SelectBoxViewModel
            {
                Id = Juego.Id,
                Nombre = Juego.Nombre,
            }).ToList();

            return Json(new { Result = seleccionarjuegos, Error = "" }, JsonRequestBehavior.AllowGet);
        }

        //Una vez seleccionada la categoria recibe el ID de la categoria y muestra las preguntas
        public ActionResult ComenzarAJugar(Guid Id)
        {
            var juego = db.Juegos.Find(Id);
            var userid = User.Identity.GetUserId();

            var preguntasContestadas = db.PreguntaPorRespuesta.Where(pr =>
                        pr.Juego.Id == Id &&
                        pr.Usuario.UsuarioApp.Id == userid
                ).ToList();

            var preguntaAContestar = new Pregunta();

            foreach (var pregunta in juego.Preguntas)
            {
                var existe = preguntasContestadas.FirstOrDefault(p => p.Pregunta.Id == pregunta.Id);

                if (existe == null)
                {
                    preguntaAContestar = pregunta;
                    break;
                }
            }

            if (preguntaAContestar.Nombre == null)
            {
                return RedirectToAction("JuegoFinalizado", new { Id = Id });  //CONTESTO TODAS LAS PREGUNTAS TODAS LAS PREGUNTAS
            }

            var model = new PreguntaJuegoViewModel();
            model.JuegoId = Id;
            model.PreguntaJuego = preguntaAContestar.CovertirAViewModel();
            model.RespuestaCorrecta = preguntaAContestar.Respuestas.FirstOrDefault(r => r.EsCorrecta).Id;
            model.RespuestaJuego = preguntaAContestar.Respuestas.Select(r => new RespuestaViewModel
            {
                Id = r.Id,
                Nombre = r.Nombre
            }).ToList();

            return View(model);
        }

        public ActionResult ComenzarAJugarMobile()
        {
            Guid id = Newtonsoft.Json.JsonConvert.DeserializeObject<Guid>(this.Contenido);
            var juego = db.Juegos.Find(id);

            var preguntasContestadas = db.PreguntaPorRespuesta.Where(pr =>
                        pr.Juego.Id == id &&
                        pr.Usuario.UsuarioApp.Id == usuarioId
                ).ToList();

            var preguntaAContestar = new Pregunta();

            foreach (var pregunta in juego.Preguntas)
            {
                var existe = preguntasContestadas.FirstOrDefault(p => p.Pregunta.Id == pregunta.Id);

                if (existe == null)
                {
                    preguntaAContestar = pregunta;
                    break;
                }
            }

            if (preguntaAContestar.Nombre == null)
            {
                return Json(new { Result = "Termino", Error = "" }, JsonRequestBehavior.AllowGet);  //CONTESTO TODAS LAS PREGUNTAS
                //return RedirectToAction("JuegoFinalizadoMobile", new { Id = Id });  //CONTESTO TODAS LAS PREGUNTAS
            }

            var model = new PreguntaJuegoViewModel();
            model.JuegoId = id;
            model.PreguntaJuego = preguntaAContestar.CovertirAViewModel();
            model.RespuestaCorrecta = preguntaAContestar.Respuestas.FirstOrDefault(r => r.EsCorrecta).Id;
            model.RespuestaJuego = preguntaAContestar.Respuestas.Select(r => new RespuestaViewModel
            {
                Id = r.Id,
                Nombre = r.Nombre
            }).ToList();

            return Json(new { Result = model, Error = "" }, JsonRequestBehavior.AllowGet);
        }

        //Cuando el usario contesta 
        [HttpPost]
        public ActionResult RespuestaPregunta()
        {
            var model = Newtonsoft.Json.JsonConvert.DeserializeObject<ContestarViewModel>(this.Contenido);
            var usuario = db.Usuarios.Where(u => u.UsuarioApp.Id == usuarioId).First();

            var respuestaPregunta = new PreguntaPorRespuesta(model, db);
            respuestaPregunta.Usuario = usuario;

            db.PreguntaPorRespuesta.Add(respuestaPregunta);
            db.SaveChanges();

            return Json(new { Result = "OK", model = model, Error = "" }, JsonRequestBehavior.AllowGet);
        }

        //Muestra los puntajes
        public ActionResult JuegoFinalizado(Guid Id)
        {
            var usuarioId = User.Identity.GetUserId();
            var usuarioNickname = db.Usuarios.FirstOrDefault(u => u.UsuarioApp.Id == usuarioId);
            var nombreJuego = db.Juegos.FirstOrDefault(j => j.Id == Id);

            var contestoAlgunaBien = db.PreguntaPorRespuesta.Any(u => u.Usuario.UsuarioApp.Id == usuarioId
            && u.Juego.Id == Id
            && u.Respuesta.EsCorrecta == true);
 
            var puntajeTotal = 0;
            if (contestoAlgunaBien)
            {
                puntajeTotal = db.PreguntaPorRespuesta.Where(u => u.Usuario.UsuarioApp.Id == usuarioId)
                    .Where(j => j.Juego.Id == Id).Where(r => r.Respuesta.EsCorrecta == true).Sum(s => s.Pregunta.Puntaje);
            }

            //respuestas usuario
            var respuestasElegidas = db.PreguntaPorRespuesta.Where(u => u.Usuario.UsuarioApp.Id == usuarioId
            && u.Juego.Id == Id);

            //preguntas usuario
            var preguntasUsuario = nombreJuego.Preguntas.Select(pu => new PreguntaEstadisticaViewModel {
                PreguntaEstadisticaTexto = pu.Nombre,
                PuntajePreguntaEstadistica = pu.Puntaje,
                RespuestaEstadistica = pu.Respuestas.Select(r => new RespuestaEstadisticaViewModel
                {
                    RespuestaTexto = r.Nombre,
                    EsCorrecta = r.EsCorrecta,
                    RespuestaElegida = respuestasElegidas.Any(re => re.Respuesta.Id == r.Id)
                })
            }).ToList();

            //preguntas
            var preguntas = new JuegoFinalizadoViewModel();
            preguntas.Juego = nombreJuego.Nombre;
            preguntas.Usuario = usuarioNickname.NickName;
            preguntas.PuntajeTotal = puntajeTotal;
            preguntas.PreguntaEstadistica = preguntasUsuario;

            return View(preguntas);
        }

        public ActionResult JuegoFinalizadoMobile()
        {
            Guid id = Newtonsoft.Json.JsonConvert.DeserializeObject<Guid>(this.Contenido);
            var usuarioNickname = db.Usuarios.FirstOrDefault(u => u.UsuarioApp.Id == usuarioId);
            var nombreJuego = db.Juegos.FirstOrDefault(j => j.Id == id);

            var contestoAlgunaBien = db.PreguntaPorRespuesta.Any(u => u.Usuario.UsuarioApp.Id == usuarioId
            && u.Juego.Id == id
            && u.Respuesta.EsCorrecta == true);

            var puntajeTotal = 0;
            if (contestoAlgunaBien)
            {
                puntajeTotal = db.PreguntaPorRespuesta.Where(u => u.Usuario.UsuarioApp.Id == usuarioId)
                    .Where(j => j.Juego.Id == id).Where(r => r.Respuesta.EsCorrecta == true).Sum(s => s.Pregunta.Puntaje);
            }

            //respuestas usuario
            var respuestasElegidas = db.PreguntaPorRespuesta.Where(u => u.Usuario.UsuarioApp.Id == usuarioId
            && u.Juego.Id == id);

            //preguntas usuario
            var preguntasUsuario = nombreJuego.Preguntas.Select(pu => new PreguntaEstadisticaViewModel
            {
                PreguntaEstadisticaTexto = pu.Nombre,
                PuntajePreguntaEstadistica = pu.Puntaje,
                RespuestaEstadistica = pu.Respuestas.Select(r => new RespuestaEstadisticaViewModel
                {
                    RespuestaTexto = r.Nombre,
                    EsCorrecta = r.EsCorrecta,
                    RespuestaElegida = respuestasElegidas.Any(re => re.Respuesta.Id == r.Id)
                })
            }).ToList();

            //preguntas
            var preguntas = new JuegoFinalizadoMobileViewModel();
            preguntas.Finalizado = "OK";
            preguntas.IdCategoria = id;
            preguntas.Juego = nombreJuego.Nombre;
            preguntas.Usuario = usuarioNickname.NickName;
            preguntas.PuntajeTotal = puntajeTotal;
            preguntas.PreguntaEstadistica = preguntasUsuario;

            //return View(preguntas);
            return Json(new { Result = preguntas, Error = "" }, JsonRequestBehavior.AllowGet);
        }
    }
}