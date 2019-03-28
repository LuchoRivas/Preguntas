using Binit.Infraestructura.Website.Models.Dominio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio
{
    public class Geolocalizacion : Entidad
    {
        public Geolocalizacion()
        {
            Id = new Guid();
            Nombre = "LocalizacionUsuario";
        }

        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public DateTime FechaHora { get; set; }
        public Usuario Usuario { get; set; }
    }
}