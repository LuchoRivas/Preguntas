using Binit.Infraestructura.Website.Models.Dominio.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Binit.Infraestructura.Website.Models.Dominio.Archivo
{
    [Table("Archivo")]
    public class Archivo : Entidad
    {

        public string Extension { get; set; }
        public string IdFileManager { get; set; }
    }
}