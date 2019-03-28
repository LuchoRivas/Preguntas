using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio.ViewModels.Preguntas
{
    public class RespuestaEstadisticaViewModel
    {
        public string RespuestaTexto { get; set; }
        public bool EsCorrecta { get; set; }
        public bool RespuestaElegida { get; set; }
    }
}