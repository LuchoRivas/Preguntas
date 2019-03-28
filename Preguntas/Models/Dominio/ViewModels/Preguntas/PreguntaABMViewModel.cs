using Preguntas.Models.Dominio.ViewModels;
using Preguntas.Models.Dominio.ViewModels.Preguntas;
using Preguntas.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.ViewModels.Preguntas
{
    public class PreguntaABMViewModel : EntidadViewModel
    {
        public int Puntaje { get; set; }
        public Guid Juego { get; set; }
        public List<RespuestaABMViewModel> Respuestas { get; set; } //lista de resp
        public List<SelectBoxViewModel> JuegosDisponibles { get; set; }
    }
}