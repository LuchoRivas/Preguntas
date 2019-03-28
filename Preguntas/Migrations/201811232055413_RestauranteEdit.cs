namespace Preguntas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestauranteEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Preguntas", "JuegoId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Preguntas", "JuegoId");
        }
    }
}
