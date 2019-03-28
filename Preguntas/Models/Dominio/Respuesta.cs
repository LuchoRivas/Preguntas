using Binit.Infraestructura.Website.Models.Dominio.General;
using Preguntas.Models.Dominio.ViewModels.Preguntas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio
{
    public class Respuesta : Entidad
    {
        public Respuesta() {}
        public Respuesta(RespuestaABMViewModel model)
        {
            Nombre = model.Nombre;
            EsCorrecta = model.RespuestaCorrecta;
        }
        public Respuesta(RespuestaABMViewModel viewmodel, ApplicationDbContext db, Pregunta pregunta)
        {
            Nombre = viewmodel.Nombre;
            if (Preguntas == null)
            {
                Preguntas = new List<Pregunta>();
            }

            Preguntas.Add(pregunta);
        }
        public virtual ICollection<Pregunta> Preguntas { get; set; }
        public bool EsCorrecta { get; set; }
    }
}