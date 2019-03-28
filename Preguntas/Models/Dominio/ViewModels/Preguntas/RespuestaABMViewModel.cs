using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio.ViewModels.Preguntas
{
    public class RespuestaABMViewModel : EntidadViewModel
    {
        public bool RespuestaCorrecta { get; set; }
        public Guid PregId { get; set; }
    }
}