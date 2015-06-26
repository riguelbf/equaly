using System.ComponentModel;
using System.Security.Principal;
using System.Web;
using DKO.EQualy.CustomHelpers;
using DKO.EQualy.Domain.Interfaces;
using DKO.EQualy.Domain.Interfaces.Helpers;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.Service;
using DKO.Equaly.Service.Concrete;
using DKO.Equaly.Service.Concrete.Documento;
using DKO.Equaly.Service.Concrete.Indicadores;
using DKO.Equaly.Service.Concrete.NaoConformidade;
using DKO.Equaly.Service.Security;
using DKO.EQulay.Infra.Repositories;
using DKO.EQulay.Infra.Repositories.EF;
using Ninject.Modules;
using Ninject.Syntax;

namespace DKO.EQualy.Infra.IOC
{
    public class IocModule : NinjectModule
    {
        public override void Load()
        {
            
            //repositorios
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind<IPlanoAcaoRepository>().To<PlanoAcaoRepository>();
            Bind<ICausaRaizRepository>().To<CausaRaizRepository>();
            Bind<ICincoPorQuesRepository>().To<CincoPorQuesRepository>();
            Bind<IDocumentoRepository>().To<DocumentoRepository>();
            Bind<IFerramenta5W2HRepository>().To<Ferramenta5W2HRepository>();
            Bind<INaoConformidadeRepository>().To<NaoConformidadeRepository>();
            Bind<INiveisAcessoRepository>().To<NiveisAcessoRepository>();
            Bind<ISetorRepository>().To<SetorRepository>();
            Bind<IUsuarioRepository>().To<UsuarioRepository>();
            Bind<IMenuRepository>().To<MenuRepository>();
            Bind<IMenuItemRepository>().To<MenuItemRepository>();
            Bind<IAtividadeRepository>().To<AtividadeRepository>();
            Bind<IMensagemRepository>().To<MensagemRepository>();
            Bind<IHistoricoRepository>().To<HistoricoRepository>();
            Bind<IAprovacaoDocumentoRepository>().To<AprovacaoDocumentoRepository>();
            Bind<IFerramenta5W2HRepository>().To<Ferramenta5W2HRepository>();
            Bind<IPlanoAcaoRepository>().To<PlanoAcaoRepository>();
            Bind<IReclamativaRepository>().To<ReclamativaRepository>();
            Bind<HttpContext>().ToSelf();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<ContextManager>().ToSelf();

            //serviços
            
            Bind<IArquivoService>().To<ArquivoService>();
            Bind<IAtividadeService>().To<AtividadeService>();
            Bind<IDocumentoService>().To<DocumentoService>();
            Bind<IEmailService>().To<EmailService>();
            Bind<IMensagemService>().To<MensagemService>();
            Bind<IMenuService>().To<MenuService>();
            Bind<INaoConformidadeService>().To<NaoConformidadeService>();
            Bind<ISetorService>().To<SetorService>();
            Bind<IUsuarioService>().To<UsuarioService>();
            Bind<IReclamativaService>().To<ReclamativaService>();
            Bind<ICausaRaizService>().To<CausaRaizService>();
            Bind<IPlanoDeAcaoService>().To<PlanoDeAcaoService>();
            Bind<IGerenciaDeIndicadoresService>().To<GerenciaDeIndicadoresService>();
            Bind<IEficaciaService>().To<EficaciaService>();

            //Helpers
            Bind<IEnumHelper>().To<EnumHelper>();
        }
    }
}
