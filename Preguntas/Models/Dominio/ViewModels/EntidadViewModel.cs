using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio.ViewModels
{
    public class EntidadViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Debe completar el nombre")]
        public string Nombre { get; set; }
    }
}