using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Binit.Infraestructura.Website.Models.Dominio.Archivo;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Preguntas.Models.Dominio;

namespace Preguntas.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Juego> Juegos { get; set; }
        public DbSet<PreguntaPorRespuesta> PreguntaPorRespuesta { get; set; }
        public DbSet<Geolocalizacion> Geolocalizacion { get; set; }
        public DbSet<Archivo> Archivos { get; set; }
    }
}