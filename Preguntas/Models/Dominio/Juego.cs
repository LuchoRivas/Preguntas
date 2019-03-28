using Binit.Infraestructura.Website.Models.Dominio.General;
using Preguntas.Models.Dominio.ViewModels.Preguntas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio
{
    public class Juego : Entidad
    {
        public Juego() { }
        public Juego(JuegoABMViewModel viewmodel)
        {
            Id = viewmodel.Id;
            Nombre = viewmodel.TipoDeJuego;
        }
        public JuegoABMViewModel ConvertirAViewModel()
        {
            var viewmodel = new JuegoABMViewModel();
            viewmodel.Id = Id;
            viewmodel.TipoDeJuego = Nombre;

            return viewmodel;
        }
        public virtual ICollection<Pregunta> Preguntas { get; set; }
    }
}