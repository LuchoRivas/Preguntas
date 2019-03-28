using Binit.Infraestructura.Website.Models.Dominio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio
{
    public class LaderBoard : Entidad
    {
        public Usuario Usuario { get; set; }
        public int Puntaje { get; set; }
    }
}