using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DKO.EQualy.Domain.Entities;
using DKO.EQulay.Infra.Repositories.Maps;

namespace DKO.EQulay.Infra.Repositories.EF
{
    public class EQualyContext : DbContext
    {
        public EQualyContext()
            : base("ConnectString")
        {
            Database.SetInitializer<EQualyContext>(null);
            //Database.SetInitializer<EQualyContext>(new AppDataContextInitializer());
            //Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<PlanoDeAcao> PlanoAcao { get; set; }
        public DbSet<CausaRaiz> CausaRaize{ get; set; }
        public DbSet<CincoPorQues> CincoPorQuese { get; set; }
        public DbSet<Documento> Documento{ get; set; }
        public DbSet<Ferramenta5W2H> Ferramenta5W2H { get; set; }
        public DbSet<NaoConformidade> NaoConformidade { get; set; }
        public DbSet<NivelAcesso> NiveisAcesso { get; set; }
        public DbSet<Reclamativa> Reclamativa { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Menu> Menu{ get; set; }
        public DbSet<MenuItem> MenuItem{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AprovacaoDocumentoMap());
            modelBuilder.Configurations.Add(new AtividadeMap());
            modelBuilder.Configurations.Add(new AvaliacaoDocumentoMap());
            modelBuilder.Configurations.Add(new CausaRaizMap());
            modelBuilder.Configurations.Add(new CincoPorQuesMap());
            modelBuilder.Configurations.Add(new DocumentoMap());
            modelBuilder.Configurations.Add(new Ferramenta5W2HMap());
            modelBuilder.Configurations.Add(new HistoricoMap());
            modelBuilder.Configurations.Add(new MensagemMap());
            modelBuilder.Configurations.Add(new MenuItemMap());
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new NaoConformidadeMap());
            modelBuilder.Configurations.Add(new NiveisAcessoMap());
            modelBuilder.Configurations.Add(new PermissaoMap());
            modelBuilder.Configurations.Add(new PlanoDeAcaoMap());
            modelBuilder.Configurations.Add(new ReclamativaMap());
            modelBuilder.Configurations.Add(new SetorMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();  
            base.OnModelCreating(modelBuilder);
        }

        public class AppDataContextInitializer : DropCreateDatabaseAlways<EQualyContext>
        {

        }
    }
}
