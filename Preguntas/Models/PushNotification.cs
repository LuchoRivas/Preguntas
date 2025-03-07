﻿using Binit.Infraestructura.Website.Models.Dominio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models
{
    public class PushNotification : Entidad
    {
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public string OneSignalId { get; set; }
        public string Deeplink { get; set; }
        public string ImagenPequeña { get; set; }
        public string ImagenPrincipal { get; set; }
    }
}