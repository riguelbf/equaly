using System;
using System.Collections.Generic;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.DTO.Email;
using DKO.Equaly.DTO.NaoConformidade;
using DKO.Equaly.Service.Security;

namespace DKO.Equaly.Service.Concrete.NaoConformidade
{
    public class ReclamativaService : ServiceBase, IReclamativaService
    {
        private readonly IReclamativaRepository _reclamativaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly INaoConformidadeRepository _naoConformidadeRepository;

        public ReclamativaService(IReclamativaRepository reclamativaRepository
                                 ,IUsuarioRepository usuarioRepository
                                 ,INaoConformidadeRepository naoConformidadeRepository)
        {
            this._reclamativaRepository = reclamativaRepository;
            this._usuarioRepository = usuarioRepository;
            this._naoConformidadeRepository = naoConformidadeRepository;
        }
        public ReclamativaDto ObterReclamativaDto(int naoConformidadeId)
        {
            var reclamativa = _reclamativaRepository.Get(r => r.NaoConformidade.Id == naoConformidadeId) ?? new Reclamativa();

            return new ReclamativaDto
            {
                DataCriacao = reclamativa.DataCriacao,
                DescricaoReclamacao = reclamativa.DescricaoReclamacao,
                Titulo = reclamativa.Titulo,
                EmailReclamante = reclamativa.EmailReclamante,
                NomeReclamante = reclamativa.NomeReclamante,
                NumeroPedidoNf = reclamativa.NumeroPedidoNf,
                TelefoneReclamante = reclamativa.TelefoneReclamante,
                UsuarioCriouId = reclamativa.UsuarioCriou.Id,
                Id = reclamativa.Id
            };
        }

        public void RegistrarReclamativa(ReclamativaDto reclamativaDto)
        {
            var usuarioCriouId = this.GetUserLogged().UsuarioId;
            var usuarioCriou = _usuarioRepository.Get(usuarioCriouId);

            if (reclamativaDto.Id > 0) // edita reclamativa
            {
                Atualizar(reclamativaDto, usuarioCriou);
            }
            else // nova reclamativa
            {
                Cadastrar(reclamativaDto, usuarioCriou);
            }
        }

        private void Cadastrar(ReclamativaDto reclamativaDto, Usuario usuarioCriou)
        {
            var naoConformidade = new EQualy.Domain.Entities.NaoConformidade
            {
                DataCriacao = DateTime.Now,
                UsuarioResponsavel = usuarioCriou,
                ValorNaoQualidade = 0,
                Codigo = ""
                //PlanoDeAcao = new PlanoDeAcao(),
                //CausaRaiz = new CausaRaiz(),
                //Reclamativa = new Reclamativa()
            };

            
            var reclamativa = new Reclamativa
            {
                DataCriacao = reclamativaDto.DataCriacao,
                Titulo = reclamativaDto.Titulo,
                DescricaoReclamacao = reclamativaDto.DescricaoReclamacao,
                EmailReclamante = reclamativaDto.EmailReclamante,
                NomeReclamante = reclamativaDto.NomeReclamante,
                NumeroPedidoNf = reclamativaDto.NumeroPedidoNf,
                TelefoneReclamante = reclamativaDto.TelefoneReclamante.Replace("_",""),
                UsuarioCriou = usuarioCriou,
                NaoConformidade = naoConformidade
            };

            naoConformidade.Reclamativa = reclamativa;
            naoConformidade.HistoricoRncs = RegistrarHistorico(naoConformidade.HistoricoRncs, false, usuarioCriou);

            this.BeginTransaction();
            _naoConformidadeRepository.Add(naoConformidade);
            this.Commit();
        }

        private void Atualizar(ReclamativaDto reclamativaDto, Usuario usuarioCriou)
        {
            var reclamativa = _reclamativaRepository.Get(reclamativaDto.Id);
            reclamativa.NaoConformidade.HistoricoRncs = RegistrarHistorico(reclamativa.NaoConformidade.HistoricoRncs, true,
                usuarioCriou);

            reclamativa.DataCriacao = reclamativaDto.DataCriacao;
            reclamativa.Titulo = reclamativaDto.Titulo;
            reclamativa.DescricaoReclamacao = reclamativaDto.DescricaoReclamacao;
            reclamativa.EmailReclamante = reclamativaDto.EmailReclamante;
            reclamativa.NomeReclamante = reclamativaDto.NomeReclamante;
            reclamativa.NumeroPedidoNf = reclamativaDto.NumeroPedidoNf;
            reclamativa.TelefoneReclamante = reclamativaDto.TelefoneReclamante.Replace("_","");
            reclamativa.UsuarioCriou = usuarioCriou;
            reclamativa.NaoConformidade = reclamativa.NaoConformidade;

            this.BeginTransaction();
            _naoConformidadeRepository.Update(reclamativa.NaoConformidade);
            _reclamativaRepository.Update(reclamativa);
            this.Commit();
        }

        private List<Historico> RegistrarHistorico(List<Historico> historicoRncs,bool atualizacao,DKO.EQualy.Domain.Entities.Usuario usuarioCriou)
        {
            
            if (atualizacao)
            {
                historicoRncs.Add(new Historico
                {
                    DataCriacao = DateTime.Now,
                    UsuarioCriou = usuarioCriou,
                    Decricao = "Registro de reclamativa atualizado.",
                    Tipo = EQualy.Domain.Enum.Historico.TipoHistorico.FluxoRnc
                });
            }
            else
            {
                historicoRncs.Add(new Historico
                {
                    DataCriacao = DateTime.Now,
                    UsuarioCriou = usuarioCriou,
                    Decricao = "Registro de reclamativa cadastrado.",
                    Tipo = EQualy.Domain.Enum.Historico.TipoHistorico.FluxoRnc
                });
            }

            return historicoRncs;
        }

    }
}