using Binit.Infraestructura.Website.Models.Dominio.General;
using Preguntas.Models.Dominio.ViewModels;
using Preguntas.Models.Dominio.ViewModels.Preguntas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio
{

    //Clase funciona como intermediario entre el usuario y el juego
    public class PreguntaPorRespuesta : Entidad
    {
        public PreguntaPorRespuesta () { }
        //public PreguntaPorRespuesta(PreguntaJuegoViewModel model, ApplicationDbContext db)
        //{
        //    Nombre = "";
        //    Juego = db.Juegos.Find(model.JuegoId);
        //    Pregunta = db.Preguntas.Find(model.PreguntaJuego.Id);
        //    Respuesta = db.Respuestas.Find(model.RespuestaSeleccionada);
        //}

        public PreguntaPorRespuesta(ContestarViewModel model, ApplicationDbContext db)
        {
            Nombre = "PregXResp";
            Juego = db.Juegos.Find(model.JuegoId);
            Pregunta = db.Preguntas.Find(model.PreguntaId);
            Respuesta = db.Respuestas.Find(model.RespuestaId);
        }

        public virtual Juego Juego { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Pregunta Pregunta { get; set; }
        public virtual Respuesta Respuesta { get; set; }
    }
}