namespace Preguntas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Token : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Juegoes", "FechaEdicion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Preguntas", "FechaEdicion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Respuestas", "FechaEdicion", c => c.DateTime(nullable: false));
            AddColumn("dbo.PreguntaPorRespuestas", "FechaEdicion", c => c.DateTime(nullable: false));
            AddColumn("dbo.Usuarios", "Token", c => c.String());
            AddColumn("dbo.Usuarios", "esMobile", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Juegoes", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Preguntas", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Respuestas", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.PreguntaPorRespuestas", "Nombre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PreguntaPorRespuestas", "Nombre", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Respuestas", "Nombre", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Preguntas", "Nombre", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Juegoes", "Nombre", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Usuarios", "esMobile");
            DropColumn("dbo.Usuarios", "Token");
            DropColumn("dbo.PreguntaPorRespuestas", "FechaEdicion");
            DropColumn("dbo.Respuestas", "FechaEdicion");
            DropColumn("dbo.Preguntas", "FechaEdicion");
            DropColumn("dbo.Juegoes", "FechaEdicion");
        }
    }
}
