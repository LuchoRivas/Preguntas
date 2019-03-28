namespace Preguntas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Geo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Geolocalizacions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Latitud = c.String(),
                        Longitud = c.String(),
                        FechaHora = c.DateTime(nullable: false),
                        Nombre = c.String(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaEdicion = c.DateTime(nullable: false),
                        Eliminado = c.Boolean(nullable: false),
                        Usuario_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Geolocalizacions", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.Geolocalizacions", new[] { "Usuario_Id" });
            DropTable("dbo.Geolocalizacions");
        }
    }
}
