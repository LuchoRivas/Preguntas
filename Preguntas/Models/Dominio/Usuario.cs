using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Preguntas.Models.Dominio
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public virtual ApplicationUser UsuarioApp { get; set; }
        public bool DebeCambiarPass { get; set; }
        public string NickName { get; set; }
        public string Token { get; set; }
        public bool esMobile { get; set; }
    }
}