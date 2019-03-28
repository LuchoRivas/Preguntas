using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio.Enum
{
    [Flags]
    public enum RoleEnum
    {
        Administrador,
        Suscriptor
    }

    public static class RoleConst
    {
        public const string Administrador = "Administrador";
        public const string Suscriptor = "Suscriptor";
    }
}