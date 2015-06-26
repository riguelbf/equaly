namespace DKO.EQulay.Infra.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustefkusuariocincoporque : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CincoPorQues", new[] { "UsuarioDestino_Id" });
            AlterColumn("dbo.CincoPorQues", "UsuarioDestino_Id", c => c.Int());
            CreateIndex("dbo.CincoPorQues", "UsuarioDestino_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CincoPorQues", new[] { "UsuarioDestino_Id" });
            AlterColumn("dbo.CincoPorQues", "UsuarioDestino_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.CincoPorQues", "UsuarioDestino_Id");
        }
    }
}
