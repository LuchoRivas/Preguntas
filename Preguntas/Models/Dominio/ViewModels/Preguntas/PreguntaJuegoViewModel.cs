using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio.ViewModels.Preguntas
{
    public class PreguntaJuegoViewModel
    {
        public PreguntaJuegoViewModel() { }
        public Guid JuegoId { get; set; }
        public Guid RespuestaCorrecta { get; set; }
        public PreguntaViewModel PreguntaJuego { get; set; }
        public virtual IEnumerable<RespuestaViewModel> RespuestaJuego { get; set; }
        public Guid RespuestaSeleccionada { get; set; }
    }
}