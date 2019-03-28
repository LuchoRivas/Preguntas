namespace Preguntas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PreguntaPorRespuestas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        FechaCreacion = c.DateTime(nullable: false),
                        Eliminado = c.Boolean(nullable: false),
                        Juego_Id = c.Guid(),
                        Pregunta_Id = c.Guid(),
                        Respuesta_Id = c.Guid(),
                        Usuario_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Juegoes", t => t.Juego_Id)
                .ForeignKey("dbo.Preguntas", t => t.Pregunta_Id)
                .ForeignKey("dbo.Respuestas", t => t.Respuesta_Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Juego_Id)
                .Index(t => t.Pregunta_Id)
                .Index(t => t.Respuesta_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PreguntaPorRespuestas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.PreguntaPorRespuestas", "Respuesta_Id", "dbo.Respuestas");
            DropForeignKey("dbo.PreguntaPorRespuestas", "Pregunta_Id", "dbo.Preguntas");
            DropForeignKey("dbo.PreguntaPorRespuestas", "Juego_Id", "dbo.Juegoes");
            DropIndex("dbo.PreguntaPorRespuestas", new[] { "Usuario_Id" });
            DropIndex("dbo.PreguntaPorRespuestas", new[] { "Respuesta_Id" });
            DropIndex("dbo.PreguntaPorRespuestas", new[] { "Pregunta_Id" });
            DropIndex("dbo.PreguntaPorRespuestas", new[] { "Juego_Id" });
            DropTable("dbo.PreguntaPorRespuestas");
        }
    }
}
