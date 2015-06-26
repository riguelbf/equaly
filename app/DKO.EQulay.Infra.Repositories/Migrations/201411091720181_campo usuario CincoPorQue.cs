namespace DKO.EQulay.Infra.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campousuarioCincoPorQue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CincoPorQues", "UsuarioDestino_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.CincoPorQues", "UsuarioDestino_Id");
            AddForeignKey("dbo.CincoPorQues", "UsuarioDestino_Id", "dbo.Usuario", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CincoPorQues", "UsuarioDestino_Id", "dbo.Usuario");
            DropIndex("dbo.CincoPorQues", new[] { "UsuarioDestino_Id" });
            DropColumn("dbo.CincoPorQues", "UsuarioDestino_Id");
        }
    }
}
