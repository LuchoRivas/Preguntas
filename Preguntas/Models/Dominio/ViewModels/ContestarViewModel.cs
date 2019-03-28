using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio.ViewModels
{
    public class ContestarViewModel
    {
        public Guid JuegoId { get; set; }
        public Guid PreguntaId { get; set; }
        public Guid RespuestaId { get; set; }
    }
}