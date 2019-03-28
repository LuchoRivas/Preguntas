using Binit.Infraestructura.Website.Models.Dominio.General;
using Preguntas.Models.Dominio.ViewModels.Preguntas;
using Preguntas.Models.ViewModels.Preguntas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio
{
    public class Pregunta : Entidad
    {
        public Pregunta()
        {
            Respuestas = new List<Respuesta>();
        }
        public Pregunta(PreguntaABMViewModel viewmodel, ApplicationDbContext db)
        {
            Nombre = viewmodel.Nombre;
            Puntaje = viewmodel.Puntaje;
            Juegos = new List<Juego>();
            Juegos.Add(db.Juegos.Find(viewmodel.Juego));  //busca el juego enviado en la vista

            if (Respuestas == null)
                Respuestas = new List<Respuesta>();
            foreach (var respuestavm in viewmodel.Respuestas)
            {
                var respuesta = new Respuesta(respuestavm);
                Respuestas.Add(respuesta);
            }
        }
        public PreguntaViewModel CovertirAViewModel()
        {
            var viewmodel = new PreguntaViewModel();
            viewmodel.Id = Id;
            viewmodel.Nombre = Nombre;
            viewmodel.Puntaje = Puntaje;
            viewmodel.Juego = JuegoId;
            viewmodel.RepuestasDeLaPregunta = Respuestas.Select(r => r.Id).ToList();

            return viewmodel;
        }

        public virtual ICollection<Juego> Juegos { get; set; }
        public virtual ICollection<Respuesta> Respuestas { get; set; }
        public int Puntaje { get; set; }
        public virtual Guid JuegoId { get; set; }
    }
}