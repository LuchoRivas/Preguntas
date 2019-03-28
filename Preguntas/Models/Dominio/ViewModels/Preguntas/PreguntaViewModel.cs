using Preguntas.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio.ViewModels.Preguntas
{
    public class PreguntaViewModel : EntidadViewModel
    {
        public PreguntaViewModel() { }
        public PreguntaViewModel(ApplicationDbContext db)
        {
            LlenarListas(db);
        }
        public void LlenarListas(ApplicationDbContext db)
        {
            JuegosDisponibles = db.Juegos.Select(j => new SelectBoxViewModel
            {
                Id = j.Id,
                Nombre = j.Nombre
            }).ToList();

            Respuestas = db.Respuestas.Select(r => new RespuestaViewModel
            {
                Id = r.Id,
                Nombre = r.Nombre
            }).ToList();
        }

        public int Puntaje { get; set; }
        public Guid Juego { get; set; }
        public virtual List<SelectBoxViewModel> JuegosDisponibles { get; set; }
        public List<RespuestaViewModel> Respuestas { get; set; }
        public List<Guid> RepuestasDeLaPregunta { get; set; }
    }
}