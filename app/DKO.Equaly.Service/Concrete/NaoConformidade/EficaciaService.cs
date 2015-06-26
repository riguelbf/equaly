using System;
using System.Collections.Generic;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.DTO.Email;
using DKO.Equaly.DTO.NaoConformidade.Eficacia;

namespace DKO.Equaly.Service.Concrete.NaoConformidade
{
    public class EficaciaService : ServiceBase, IEficaciaService
    {
        private readonly INaoConformidadeRepository _naoConformidadeRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmailService _emailService;

        public EficaciaService(INaoConformidadeRepository naoConformidadeRepository, IUsuarioRepository usuarioRepository, IEmailService emailService)
        {
            this._naoConformidadeRepository = naoConformidadeRepository;
            this._usuarioRepository = usuarioRepository;
            this._emailService = emailService;
        }

        public EficaciaDto ObterEficaciaDto(int naoConformidadeId)
        {
            var naoConformidade = _naoConformidadeRepository.Get(naoConformidadeId);
            return naoConformidade == null ||naoConformidade.Eficacia == null
                ? new EficaciaDto()
                : new EficaciaDto
                {
                    DataDeCriacao = naoConformidade.Eficacia.DataDeCriacao,
                    Observacao = naoConformidade.Eficacia.Observacao,
                    Pontuacao = naoConformidade.Eficacia.Pontuacao,
                    NaoConformidadeId = naoConformidadeId
                };
        }

        public void RegistrarEficacia(EficaciaDto eficaciaDto, int usuarioQueRegistrouId)
        {
            var usuarioQueRegistrou = _usuarioRepository.Get(usuarioQueRegistrouId);
            var naoConformidade = _naoConformidadeRepository.Get(eficaciaDto.NaoConformidadeId);

            if (naoConformidade.Eficacia == null)
            {
                CadatrarEficacia(eficaciaDto, naoConformidade);
                naoConformidade.HistoricoRncs = RegistrarHistorico(naoConformidade.HistoricoRncs, false, usuarioQueRegistrou, eficaciaDto.Pontuacao);
            }
            else
            {
                AtualizarEficacia(eficaciaDto, naoConformidade);
                naoConformidade.HistoricoRncs = RegistrarHistorico(naoConformidade.HistoricoRncs, true, usuarioQueRegistrou, eficaciaDto.Pontuacao);
            }

            this.BeginTransaction();
                _naoConformidadeRepository.Update(naoConformidade);
            this.Commit();

            EnviarEmailDeAvisoDePublicacao(naoConformidade);
        }

        private static void AtualizarEficacia(EficaciaDto eficaciaDto, EQualy.Domain.Entities.NaoConformidade naoConformidade)
        {
            naoConformidade.Eficacia.DataDeCriacao = eficaciaDto.DataDeCriacao;
            naoConformidade.Eficacia.NomeArquivo = eficaciaDto.NomeArquivo;
            naoConformidade.Eficacia.Observacao = eficaciaDto.Observacao;
            naoConformidade.Eficacia.Pontuacao = eficaciaDto.Pontuacao;
        }

        private static void CadatrarEficacia(EficaciaDto eficaciaDto, EQualy.Domain.Entities.NaoConformidade naoConformidade)
        {
            naoConformidade.Eficacia = new Eficacia
            {
                DataDeCriacao = eficaciaDto.DataDeCriacao,
                NomeArquivo = eficaciaDto.NomeArquivo,
                Observacao = eficaciaDto.Observacao,
                Pontuacao = eficaciaDto.Pontuacao
            };
        }

        private List<Historico> RegistrarHistorico(List<Historico> historicoRncs, bool atualizacao, DKO.EQualy.Domain.Entities.Usuario usuarioCriou, decimal pontuacao)
        {

            if (atualizacao)
            {
                historicoRncs.Add(new Historico
                {
                    DataCriacao = DateTime.Now,
                    UsuarioCriou = usuarioCriou,
                    Decricao = "Registro de avaliação de eficácia atualizado para " + pontuacao + " pontos.",
                    Tipo = EQualy.Domain.Enum.Historico.TipoHistorico.FluxoRnc
                });
            }
            else
            {
                historicoRncs.Add(new Historico
                {
                    DataCriacao = DateTime.Now,
                    UsuarioCriou = usuarioCriou,
                    Decricao = "Registro de avaliação de eficácia realizado em " + pontuacao + " pontos.",
                    Tipo = EQualy.Domain.Enum.Historico.TipoHistorico.FluxoRnc
                });
            }

            return historicoRncs;
        }

        public void EnviarEmailDeAvisoDePublicacao(EQualy.Domain.Entities.NaoConformidade naoConformidade)
        {
            foreach (var usuario in naoConformidade.CausaRaiz.UsuariosEnvolvidos)
            {
                _emailService.Enviar(new EmailDto
                {
                    Assunto = "Avaliação da eficácia",
                    Descricao = string.Format("A não conformidade de código {0}, foi avaliada em com uma nota de {1}", naoConformidade.Id, naoConformidade.Eficacia.Pontuacao),
                    Titulo = "Publicação",
                    EmailDestinatario = usuario.Email,
                    Data = DateTime.Now,
                    DescricaoAtividade = "Avalição da Eficácia"

                });
            }
        }
    }
}