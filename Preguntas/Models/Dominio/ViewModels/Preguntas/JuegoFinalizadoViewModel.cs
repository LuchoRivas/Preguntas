using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio.ViewModels.Preguntas
{
    public class JuegoFinalizadoViewModel
    {
        public string Usuario { get; set; }
        public string Juego { get; set; }
        public IEnumerable<PreguntaEstadisticaViewModel> PreguntaEstadistica { get; set; }
        public int PuntajeTotal { get; set; }
    }
    public class JuegoFinalizadoMobileViewModel
    {
        public Guid IdCategoria { get; set; }
        public string Usuario { get; set; }
        public string Juego { get; set; }
        public IEnumerable<PreguntaEstadisticaViewModel> PreguntaEstadistica { get; set; }
        public int PuntajeTotal { get; set; }
        public string Finalizado { get; set; }
    }
}