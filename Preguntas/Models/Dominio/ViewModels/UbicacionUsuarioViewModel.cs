using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio.ViewModels
{
    public class UbicacionUsuarioViewModel
    {
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string FechaHora { get; set; }
        public Usuario Usuario { get; set; }
    }
}