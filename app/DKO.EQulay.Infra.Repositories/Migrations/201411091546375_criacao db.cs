namespace DKO.EQulay.Infra.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criacaodb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CausaRaiz",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DescricaoDefinicao = c.String(),
                        DataConclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NaoConformidade", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CincoPorQues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Resposta = c.String(maxLength: 400),
                        Pergunta = c.String(maxLength: 400),
                        CausaRaiz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CausaRaiz", t => t.CausaRaiz_Id)
                .Index(t => t.CausaRaiz_Id);
            
            CreateTable(
                "dbo.NaoConformidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValorNaoQualidade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataCriacao = c.DateTime(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 50),
                        UsuarioResponsavel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioResponsavel_Id)
                .Index(t => t.UsuarioResponsavel_Id);
            
            CreateTable(
                "dbo.Eficacia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataDeCriacao = c.DateTime(nullable: false),
                        Pontuacao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Observacao = c.String(),
                        NaoConformidade_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NaoConformidade", t => t.NaoConformidade_Id, cascadeDelete: true)
                .Index(t => t.NaoConformidade_Id);
            
            CreateTable(
                "dbo.Historico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataCriacao = c.DateTime(nullable: false),
                        Decricao = c.String(nullable: false, maxLength: 500),
                        Tipo = c.Int(),
                        UsuarioCriou_Id = c.Int(nullable: false),
                        HistoricoRncId = c.Int(),
                        HistoricoDocId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCriou_Id)
                .ForeignKey("dbo.NaoConformidade", t => t.HistoricoRncId, cascadeDelete: true)
                .ForeignKey("dbo.Documento", t => t.HistoricoDocId)
                .Index(t => t.UsuarioCriou_Id)
                .Index(t => t.HistoricoRncId)
                .Index(t => t.HistoricoDocId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        NomeUsuario = c.String(nullable: false, maxLength: 100),
                        Matricula = c.String(nullable: false, maxLength: 50),
                        Senha = c.String(nullable: false, maxLength: 100),
                        Email = c.String(),
                        UrlFotoPerfil = c.String(),
                        NivelAcesso_Id = c.Int(nullable: false),
                        Setor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NiveisAcesso", t => t.NivelAcesso_Id)
                .ForeignKey("dbo.Setor", t => t.Setor_Id)
                .Index(t => t.NivelAcesso_Id)
                .Index(t => t.Setor_Id);
            
            CreateTable(
                "dbo.NiveisAcesso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(maxLength: 50),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        ClassIcon = c.String(maxLength: 100),
                        Order = c.Int(nullable: false),
                        Action = c.String(maxLength: 200),
                        Controller = c.String(maxLength: 200),
                        Permissao_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Permissao", t => t.Permissao_Id)
                .Index(t => t.Permissao_Id);
            
            CreateTable(
                "dbo.MenuItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ActionName = c.String(nullable: false, maxLength: 150),
                        ControllerName = c.String(nullable: false, maxLength: 150),
                        Url = c.String(nullable: false, maxLength: 150),
                        ClassIcon = c.String(maxLength: 100),
                        Order = c.Int(nullable: false),
                        Menu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menu", t => t.Menu_Id)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.Permissao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Criar = c.Boolean(nullable: false),
                        Apagar = c.Boolean(nullable: false),
                        Editar = c.Boolean(nullable: false),
                        Listar = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Setor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50),
                        Codigo = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlanoDeAcao",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Observacao = c.String(maxLength: 400),
                        NomeDocumentoEvidencia = c.String(maxLength: 150),
                        DataConclusaoValidacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NaoConformidade", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Ferramenta5W2H",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OQue = c.String(maxLength: 500),
                        PorQue = c.String(maxLength: 500),
                        Quem = c.String(maxLength: 500),
                        Quando = c.String(maxLength: 500),
                        Onde = c.String(maxLength: 500),
                        Como = c.String(),
                        QuantoCusta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(nullable: false, maxLength: 1),
                        DataCriacao = c.DateTime(nullable: false),
                        DataConclusao = c.DateTime(nullable: false),
                        TipoDePlanoDeAcao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reclamativa",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Titulo = c.String(maxLength: 150),
                        NomeReclamante = c.String(maxLength: 150),
                        EmailReclamante = c.String(maxLength: 100),
                        TelefoneReclamante = c.String(maxLength: 20),
                        DataCriacao = c.DateTime(nullable: false),
                        DescricaoReclamacao = c.String(nullable: false, maxLength: 500),
                        NumeroPedidoNf = c.String(maxLength: 50),
                        UsuarioCriou_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCriou_Id)
                .ForeignKey("dbo.NaoConformidade", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.UsuarioCriou_Id);
            
            CreateTable(
                "dbo.Documento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoIdentificacao = c.String(),
                        Titulo = c.String(maxLength: 150),
                        NumeroRevisao = c.String(maxLength: 50),
                        DataEmissao = c.DateTime(nullable: false),
                        LocalFisico = c.String(maxLength: 150),
                        LocalDigital = c.String(maxLength: 150),
                        QtdNumeroCopia = c.Int(nullable: false),
                        Observacao = c.String(maxLength: 500),
                        SendoRevisado = c.Boolean(),
                        Ativo = c.Boolean(nullable: false),
                        TipoDocumento = c.Int(nullable: false),
                        FaseDocumento = c.Int(nullable: false),
                        TipoDeArmazenamento = c.Int(),
                        NomeArquivo = c.String(maxLength: 100),
                        DataPublicacao = c.DateTime(),
                        Validade = c.DateTime(),
                        CopiaControlada = c.Boolean(nullable: false),
                        SetorEnvolvido_Id = c.Int(nullable: false),
                        UsuariosAprovador_Id = c.Int(nullable: false),
                        UsuariosElaborador_Id = c.Int(nullable: false),
                        UsuariosSolicitante_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Setor", t => t.SetorEnvolvido_Id)
                .ForeignKey("dbo.Usuario", t => t.UsuariosAprovador_Id)
                .ForeignKey("dbo.Usuario", t => t.UsuariosElaborador_Id)
                .ForeignKey("dbo.Usuario", t => t.UsuariosSolicitante_Id)
                .Index(t => t.SetorEnvolvido_Id)
                .Index(t => t.UsuariosAprovador_Id)
                .Index(t => t.UsuariosElaborador_Id)
                .Index(t => t.UsuariosSolicitante_Id);
            
            CreateTable(
                "dbo.AprovacaoDocumento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aprovado = c.Boolean(),
                        TipoAprovacao = c.String(maxLength: 2),
                        Data = c.DateTime(),
                        JustificativaObservacao = c.String(maxLength: 500),
                        DocumentoParaAprovacao_Id = c.Int(nullable: false),
                        UsuarioAprovador_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documento", t => t.DocumentoParaAprovacao_Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioAprovador_Id)
                .Index(t => t.DocumentoParaAprovacao_Id)
                .Index(t => t.UsuarioAprovador_Id);
            
            CreateTable(
                "dbo.Atividade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataConclusao = c.DateTime(),
                        Descricao = c.String(nullable: false, maxLength: 500),
                        UsuarioDestinoId = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        StatusAtividade = c.Int(nullable: false),
                        UsuarioCriou_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCriou_Id)
                .Index(t => t.UsuarioCriou_Id);
            
            CreateTable(
                "dbo.AvaliacaoDocumento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataCriacao = c.DateTime(nullable: false),
                        Justificativa = c.String(maxLength: 500),
                        Aprovado = c.Boolean(),
                        Documento_Id = c.Int(nullable: false),
                        UsuarioAvaliador_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documento", t => t.Documento_Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioAvaliador_Id)
                .Index(t => t.Documento_Id)
                .Index(t => t.UsuarioAvaliador_Id);
            
            CreateTable(
                "dbo.Mensagem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 250),
                        Descricao = c.String(nullable: false, maxLength: 550),
                        DataCriacao = c.DateTime(nullable: false),
                        UsuarioDestinoId = c.Int(nullable: false),
                        UsuarioCriou_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioCriou_Id)
                .Index(t => t.UsuarioCriou_Id);
            
            CreateTable(
                "dbo.PermissaoMenuImtem",
                c => new
                    {
                        Permissao_Id = c.Int(nullable: false),
                        MenuItem_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Permissao_Id, t.MenuItem_Id })
                .ForeignKey("dbo.Permissao", t => t.Permissao_Id, cascadeDelete: true)
                .ForeignKey("dbo.MenuItem", t => t.MenuItem_Id, cascadeDelete: true)
                .Index(t => t.Permissao_Id)
                .Index(t => t.MenuItem_Id);
            
            CreateTable(
                "dbo.NiveisAcessoMenu",
                c => new
                    {
                        NivelAcesso_Id = c.Int(nullable: false),
                        Menu_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NivelAcesso_Id, t.Menu_Id })
                .ForeignKey("dbo.NiveisAcesso", t => t.NivelAcesso_Id, cascadeDelete: true)
                .ForeignKey("dbo.Menu", t => t.Menu_Id, cascadeDelete: true)
                .Index(t => t.NivelAcesso_Id)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.PlanoDeAcaoFerramenta5W2H",
                c => new
                    {
                        PlanoDeAcao_Id = c.Int(nullable: false),
                        Ferramenta5W2H_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlanoDeAcao_Id, t.Ferramenta5W2H_Id })
                .ForeignKey("dbo.PlanoDeAcao", t => t.PlanoDeAcao_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ferramenta5W2H", t => t.Ferramenta5W2H_Id, cascadeDelete: true)
                .Index(t => t.PlanoDeAcao_Id)
                .Index(t => t.Ferramenta5W2H_Id);
            
            CreateTable(
                "dbo.CausaRaizUsuario",
                c => new
                    {
                        CausaRaiz_Id = c.Int(nullable: false),
                        Usuario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CausaRaiz_Id, t.Usuario_Id })
                .ForeignKey("dbo.CausaRaiz", t => t.CausaRaiz_Id, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id, cascadeDelete: true)
                .Index(t => t.CausaRaiz_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.DocumentoAprovacaoDocumento",
                c => new
                    {
                        Documento_Id = c.Int(nullable: false),
                        AprovacaoDocumento_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Documento_Id, t.AprovacaoDocumento_Id })
                .ForeignKey("dbo.Documento", t => t.Documento_Id, cascadeDelete: true)
                .ForeignKey("dbo.AprovacaoDocumento", t => t.AprovacaoDocumento_Id, cascadeDelete: true)
                .Index(t => t.Documento_Id)
                .Index(t => t.AprovacaoDocumento_Id);
            
            CreateTable(
                "dbo.RevisoresDocumento",
                c => new
                    {
                        Documento_Id = c.Int(nullable: false),
                        Usuario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Documento_Id, t.Usuario_Id })
                .ForeignKey("dbo.Documento", t => t.Documento_Id, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id, cascadeDelete: true)
                .Index(t => t.Documento_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mensagem", "UsuarioCriou_Id", "dbo.Usuario");
            DropForeignKey("dbo.AvaliacaoDocumento", "UsuarioAvaliador_Id", "dbo.Usuario");
            DropForeignKey("dbo.AvaliacaoDocumento", "Documento_Id", "dbo.Documento");
            DropForeignKey("dbo.Atividade", "UsuarioCriou_Id", "dbo.Usuario");
            DropForeignKey("dbo.Documento", "UsuariosSolicitante_Id", "dbo.Usuario");
            DropForeignKey("dbo.RevisoresDocumento", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.RevisoresDocumento", "Documento_Id", "dbo.Documento");
            DropForeignKey("dbo.Documento", "UsuariosElaborador_Id", "dbo.Usuario");
            DropForeignKey("dbo.Documento", "UsuariosAprovador_Id", "dbo.Usuario");
            DropForeignKey("dbo.Documento", "SetorEnvolvido_Id", "dbo.Setor");
            DropForeignKey("dbo.Historico", "HistoricoDocId", "dbo.Documento");
            DropForeignKey("dbo.DocumentoAprovacaoDocumento", "AprovacaoDocumento_Id", "dbo.AprovacaoDocumento");
            DropForeignKey("dbo.DocumentoAprovacaoDocumento", "Documento_Id", "dbo.Documento");
            DropForeignKey("dbo.AprovacaoDocumento", "UsuarioAprovador_Id", "dbo.Usuario");
            DropForeignKey("dbo.AprovacaoDocumento", "DocumentoParaAprovacao_Id", "dbo.Documento");
            DropForeignKey("dbo.CausaRaizUsuario", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.CausaRaizUsuario", "CausaRaiz_Id", "dbo.CausaRaiz");
            DropForeignKey("dbo.NaoConformidade", "UsuarioResponsavel_Id", "dbo.Usuario");
            DropForeignKey("dbo.Reclamativa", "Id", "dbo.NaoConformidade");
            DropForeignKey("dbo.Reclamativa", "UsuarioCriou_Id", "dbo.Usuario");
            DropForeignKey("dbo.PlanoDeAcao", "Id", "dbo.NaoConformidade");
            DropForeignKey("dbo.PlanoDeAcaoFerramenta5W2H", "Ferramenta5W2H_Id", "dbo.Ferramenta5W2H");
            DropForeignKey("dbo.PlanoDeAcaoFerramenta5W2H", "PlanoDeAcao_Id", "dbo.PlanoDeAcao");
            DropForeignKey("dbo.Historico", "HistoricoRncId", "dbo.NaoConformidade");
            DropForeignKey("dbo.Historico", "UsuarioCriou_Id", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "Setor_Id", "dbo.Setor");
            DropForeignKey("dbo.Usuario", "NivelAcesso_Id", "dbo.NiveisAcesso");
            DropForeignKey("dbo.NiveisAcessoMenu", "Menu_Id", "dbo.Menu");
            DropForeignKey("dbo.NiveisAcessoMenu", "NivelAcesso_Id", "dbo.NiveisAcesso");
            DropForeignKey("dbo.MenuItem", "Menu_Id", "dbo.Menu");
            DropForeignKey("dbo.Menu", "Permissao_Id", "dbo.Permissao");
            DropForeignKey("dbo.PermissaoMenuImtem", "MenuItem_Id", "dbo.MenuItem");
            DropForeignKey("dbo.PermissaoMenuImtem", "Permissao_Id", "dbo.Permissao");
            DropForeignKey("dbo.Eficacia", "NaoConformidade_Id", "dbo.NaoConformidade");
            DropForeignKey("dbo.CausaRaiz", "Id", "dbo.NaoConformidade");
            DropForeignKey("dbo.CincoPorQues", "CausaRaiz_Id", "dbo.CausaRaiz");
            DropIndex("dbo.RevisoresDocumento", new[] { "Usuario_Id" });
            DropIndex("dbo.RevisoresDocumento", new[] { "Documento_Id" });
            DropIndex("dbo.DocumentoAprovacaoDocumento", new[] { "AprovacaoDocumento_Id" });
            DropIndex("dbo.DocumentoAprovacaoDocumento", new[] { "Documento_Id" });
            DropIndex("dbo.CausaRaizUsuario", new[] { "Usuario_Id" });
            DropIndex("dbo.CausaRaizUsuario", new[] { "CausaRaiz_Id" });
            DropIndex("dbo.PlanoDeAcaoFerramenta5W2H", new[] { "Ferramenta5W2H_Id" });
            DropIndex("dbo.PlanoDeAcaoFerramenta5W2H", new[] { "PlanoDeAcao_Id" });
            DropIndex("dbo.NiveisAcessoMenu", new[] { "Menu_Id" });
            DropIndex("dbo.NiveisAcessoMenu", new[] { "NivelAcesso_Id" });
            DropIndex("dbo.PermissaoMenuImtem", new[] { "MenuItem_Id" });
            DropIndex("dbo.PermissaoMenuImtem", new[] { "Permissao_Id" });
            DropIndex("dbo.Mensagem", new[] { "UsuarioCriou_Id" });
            DropIndex("dbo.AvaliacaoDocumento", new[] { "UsuarioAvaliador_Id" });
            DropIndex("dbo.AvaliacaoDocumento", new[] { "Documento_Id" });
            DropIndex("dbo.Atividade", new[] { "UsuarioCriou_Id" });
            DropIndex("dbo.AprovacaoDocumento", new[] { "UsuarioAprovador_Id" });
            DropIndex("dbo.AprovacaoDocumento", new[] { "DocumentoParaAprovacao_Id" });
            DropIndex("dbo.Documento", new[] { "UsuariosSolicitante_Id" });
            DropIndex("dbo.Documento", new[] { "UsuariosElaborador_Id" });
            DropIndex("dbo.Documento", new[] { "UsuariosAprovador_Id" });
            DropIndex("dbo.Documento", new[] { "SetorEnvolvido_Id" });
            DropIndex("dbo.Reclamativa", new[] { "UsuarioCriou_Id" });
            DropIndex("dbo.Reclamativa", new[] { "Id" });
            DropIndex("dbo.PlanoDeAcao", new[] { "Id" });
            DropIndex("dbo.MenuItem", new[] { "Menu_Id" });
            DropIndex("dbo.Menu", new[] { "Permissao_Id" });
            DropIndex("dbo.Usuario", new[] { "Setor_Id" });
            DropIndex("dbo.Usuario", new[] { "NivelAcesso_Id" });
            DropIndex("dbo.Historico", new[] { "HistoricoDocId" });
            DropIndex("dbo.Historico", new[] { "HistoricoRncId" });
            DropIndex("dbo.Historico", new[] { "UsuarioCriou_Id" });
            DropIndex("dbo.Eficacia", new[] { "NaoConformidade_Id" });
            DropIndex("dbo.NaoConformidade", new[] { "UsuarioResponsavel_Id" });
            DropIndex("dbo.CincoPorQues", new[] { "CausaRaiz_Id" });
            DropIndex("dbo.CausaRaiz", new[] { "Id" });
            DropTable("dbo.RevisoresDocumento");
            DropTable("dbo.DocumentoAprovacaoDocumento");
            DropTable("dbo.CausaRaizUsuario");
            DropTable("dbo.PlanoDeAcaoFerramenta5W2H");
            DropTable("dbo.NiveisAcessoMenu");
            DropTable("dbo.PermissaoMenuImtem");
            DropTable("dbo.Mensagem");
            DropTable("dbo.AvaliacaoDocumento");
            DropTable("dbo.Atividade");
            DropTable("dbo.AprovacaoDocumento");
            DropTable("dbo.Documento");
            DropTable("dbo.Reclamativa");
            DropTable("dbo.Ferramenta5W2H");
            DropTable("dbo.PlanoDeAcao");
            DropTable("dbo.Setor");
            DropTable("dbo.Permissao");
            DropTable("dbo.MenuItem");
            DropTable("dbo.Menu");
            DropTable("dbo.NiveisAcesso");
            DropTable("dbo.Usuario");
            DropTable("dbo.Historico");
            DropTable("dbo.Eficacia");
            DropTable("dbo.NaoConformidade");
            DropTable("dbo.CincoPorQues");
            DropTable("dbo.CausaRaiz");
        }
    }
}
