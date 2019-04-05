namespace Preguntas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Archivo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Archivo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Extension = c.String(),
                        IdFileManager = c.String(),
                        Nombre = c.String(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaEdicion = c.DateTime(nullable: false),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Archivo");
        }
    }
}
