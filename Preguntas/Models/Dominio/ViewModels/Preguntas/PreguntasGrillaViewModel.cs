using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio.ViewModels.Preguntas
{
    public class PreguntasGrillaViewModel : EntidadViewModel
    {
        public string Juego { get; set; }
        public int Puntaje { get; set; }
    }
}