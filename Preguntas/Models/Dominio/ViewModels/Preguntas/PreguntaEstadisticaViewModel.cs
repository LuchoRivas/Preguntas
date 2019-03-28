using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio.ViewModels.Preguntas
{
    public class PreguntaEstadisticaViewModel
    {
        public string PreguntaEstadisticaTexto { get; set; }
        public int PuntajePreguntaEstadistica { get; set; }
        public IEnumerable<RespuestaEstadisticaViewModel> RespuestaEstadistica { get; set; }
    }
}