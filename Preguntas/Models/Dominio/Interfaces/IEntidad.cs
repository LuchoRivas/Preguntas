﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio.Interfaces
{
    public interface IEntidad
    {
        Guid Id { get; set; }
        string Nombre { get; set; }
        DateTime FechaCreacion { get; set; }
        DateTime FechaEdicion { get; set; }
        bool Eliminado { get; set; }
    }
}