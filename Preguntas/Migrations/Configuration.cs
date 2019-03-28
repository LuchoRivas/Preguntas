namespace Preguntas.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Preguntas.Models;
    using Preguntas.Models.Dominio.Enum;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Preguntas.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Preguntas.Models.ApplicationDbContext context)
        {
            //Roles
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            foreach (RoleEnum role in Enum.GetValues(typeof(RoleEnum)))
            {
                if (!rm.RoleExists(role.ToString()))
                {
                    var roleResult = rm.Create(new IdentityRole(role.ToString()));
                    if (!roleResult.Succeeded)
                        throw new ApplicationException("Creating role " + role.ToString() + "failed with error(s): " + roleResult.Errors);
                }

            }
        }
    }
}
