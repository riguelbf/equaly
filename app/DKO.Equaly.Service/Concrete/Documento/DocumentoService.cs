using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Enum;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.DTO.Documentos;
using DKO.Equaly.DTO.Email;
using DKO.Equaly.Projection.Documentos;
using Atividade = DKO.EQualy.Domain.Entities.Atividade;
using Historico = DKO.EQualy.Domain.Entities.Historico;

namespace DKO.Equaly.Service.Concrete.Documento
{
    public class DocumentoService : ServiceBase, IDocumentoService
    {
        #region [ Geral ]

        private readonly IDocumentoRepository _documentoRepository;
        private readonly ISetorRepository _setorRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IHistoricoRepository _historicoRepository;
        private readonly IEmailService _emailService;
        private readonly IArquivoService _arquivoService;

        public DocumentoService(IDocumentoRepository documentoRepository, ISetorRepository setorRepository, IUsuarioRepository usuarioRepository, IEmailService emailService, IAtividadeRepository atividadeRepository, IHistoricoRepository historicoRepository, IArquivoService arquivoService)
        {
            this._documentoRepository = documentoRepository;
            this._setorRepository = setorRepository;
            this._usuarioRepository = usuarioRepository;
            this._emailService = emailService;
            this._atividadeRepository = atividadeRepository;
            this._historicoRepository = historicoRepository;
            this._arquivoService = arquivoService;
        }
        public DocumentosProjection ObterDocumentos(FiltroDocumentosDto filtroDocumentosDto)
        {
            var documentos = _documentoRepository.GetMany(d =>

                d.Titulo == filtroDocumentosDto.Titulo || filtroDocumentosDto.Titulo == string.Empty &&
                d.Ativo == filtroDocumentosDto.Ativo || (filtroDocumentosDto.Ativo || !filtroDocumentosDto.Ativo) &&
                d.DataEmissao >= filtroDocumentosDto.DataInicial.Date &&
                d.DataEmissao <= filtroDocumentosDto.DataFinal.Date &&
                d.DataEmissao >= filtroDocumentosDto.DataInicial &&
                d.DataEmissao <= filtroDocumentosDto.DataFinal &&
                d.FaseDocumento == (EQualy.Domain.Enum.Documento.FaseDocumento)filtroDocumentosDto.FaseDocumento || filtroDocumentosDto.FaseDocumento == 0 &&
                d.SetorEnvolvido.Id == filtroDocumentosDto.SetorId || filtroDocumentosDto.SetorId == 0
            );

            var documentosDisponibilizados = documentos.Where(d => d.FaseDocumento == EQualy.Domain.Enum.Documento.FaseDocumento.Disponibilizado);
            var documentosSolicitados = documentos.Where(d => d.FaseDocumento != EQualy.Domain.Enum.Documento.FaseDocumento.Disponibilizado);

             return new DocumentosProjection
             {
                 DocumentosDisponibilizados = documentosDisponibilizados == null? new List<DocumentoDisponibilizadoProjection>() : 
                 documentosDisponibilizados.Select(d => new DocumentoDisponibilizadoProjection
                 {
                     Armazenamento = d.TipoDeArmazenamento.ToString(),
                     Codigo = d.Id,
                     Tipo = d.TipoDocumento.ToString(),
                     SetorResponsavel = d.SetorEnvolvido.Nome,
                     Validade = (DateTime) d.Validade,
                     NomeIcone = ObterNomeIcone(d.NomeArquivo),
                     Titulo = d.Titulo
                     
                 }).ToList(),

                 DocumentosSolicitados = documentosSolicitados == null? new List<DocumentoSolicitadoProjection>() : 
                 documentosSolicitados.Select(d => new DocumentoSolicitadoProjection
                 {
                     Codigo = d.Id,
                     DataCriacao = d.DataEmissao.ToShortDateString(),
                     Fase = d.FaseDocumento.ToString(),
                     Setor = d.SetorEnvolvido.Nome,
                     Solicitante = d.UsuariosSolicitante.Nome,
                     Tipo = d.TipoDocumento.ToString(),
                     Titulo = d.Titulo

                 }).ToList(),
             };
        }

        private string ObterNomeIcone(string nomeArquivo)
        {
            return "icon_" + Path.GetExtension(nomeArquivo).Replace(".","") +".png";
        }

        public void ExcluirDocumento(int documentoId)
        {
            var documento = _documentoRepository.Get(d => d.Id == documentoId);
            this.BeginTransaction();
            _documentoRepository.Delete(documento);
            this.Commit();
        }

        public EQualy.Domain.Enum.Documento.FaseDocumento ObterProximaFase(EQualy.Domain.Enum.Documento.FaseDocumento faseDocumento)
        {
            switch (faseDocumento)
            {
                case EQualy.Domain.Enum.Documento.FaseDocumento.Elaboracao:
                    return EQualy.Domain.Enum.Documento.FaseDocumento.Revisao;
                case EQualy.Domain.Enum.Documento.FaseDocumento.Revisao:
                    return EQualy.Domain.Enum.Documento.FaseDocumento.Aprovacao;
                case EQualy.Domain.Enum.Documento.FaseDocumento.Aprovacao:
                    return EQualy.Domain.Enum.Documento.FaseDocumento.Publicacao;
                default:
                    return EQualy.Domain.Enum.Documento.FaseDocumento.Disponibilizado;
            }
        }

        #endregion

        #region [ Fase 1 ]

        private void EnviarEmailSolicitacao(EQualy.Domain.Entities.Documento documento)
        {
            var emailPara = System.Configuration.ConfigurationSettings.AppSettings["EmailQualidade"];

            _emailService.Enviar(new EmailDto
            {
                Assunto = "Solicitação de criação de documento",
                Descricao = "",
                Titulo = "Solicitação",
                EmailDestinatario = emailPara,
                Data = DateTime.Now,
                DescricaoAtividade = string.Format("O usuário {0} solicita a criação do documento {1} do tipo {2} para amazenamento {3}",
                documento.UsuariosSolicitante.Nome, documento.Titulo, documento.TipoDocumento, documento.TipoDeArmazenamento)

            });
        }
        private void EnviarEmailConfirmacaoSolicitacao(EQualy.Domain.Entities.Documento documento)
        {
            _emailService.Enviar(new EmailDto
            {
                Assunto = "Solicitação de criação de documento",
                Descricao = string.Format("Sua solicitação de documento foi realizada com sucesso. \n Código do documento para acompanhamento é {0}",
                documento.Id),
                Titulo = "Solicitação",
                EmailDestinatario = documento.UsuariosSolicitante.Email,
                Data = DateTime.Now,
                DescricaoAtividade = string.Empty

            });
        }
        public void RegistrarSolicitacaoDocumento(SolicitacaoDocumentoDto solicitacaoDocumentoDto)
        {
            var documento = solicitacaoDocumentoDto.Id > 0
                ? _documentoRepository.Get(d => d.Id == solicitacaoDocumentoDto.Id)
                : new EQualy.Domain.Entities.Documento();
                
            documento.Ativo = true;
            documento.CodigoIdentificacao = "DOC";
            documento. NumeroRevisao = "1";
            documento.Observacao = solicitacaoDocumentoDto.Observacao;
            documento.LocalDigital = solicitacaoDocumentoDto.LocalDigital;
            documento.LocalFisico = solicitacaoDocumentoDto.LocalFisico;
            documento.SetorEnvolvido = _setorRepository.Get(s => s.Id == solicitacaoDocumentoDto.SetorID);
            documento.SendoRevisado = false;
            documento.TipoDeArmazenamento = (EQualy.Domain.Enum.Documento.TipoDeArmazenamento)System.Enum.Parse(typeof (Registro.TipoDeArmazenamento),solicitacaoDocumentoDto.TipoDeArmazenamento.ToString());
            documento.TipoDocumento = (EQualy.Domain.Enum.Documento.TipoDocumento)System.Enum.Parse(typeof (EQualy.Domain.Enum.Documento.TipoDocumento),solicitacaoDocumentoDto.TipoDocumento.ToString());
            documento.UsuariosAprovador =_usuarioRepository.Get(u => u.Id == solicitacaoDocumentoDto.UsuariosAprovadorId);
            documento.UsuariosElaborador =_usuarioRepository.Get(u => u.Id == solicitacaoDocumentoDto.UsuariosAprovadorId);
            
            if (documento.UsuariosRevisores != null) documento.UsuariosRevisores.Clear();
            documento.UsuariosRevisores =  _usuarioRepository.GetMany(u =>  solicitacaoDocumentoDto.UsuariosRevisores.Contains(u.Id)).ToList();
            documento.FaseDocumento = EQualy.Domain.Enum.Documento.FaseDocumento.Elaboracao;
            documento.UsuariosSolicitante = _usuarioRepository.Get(u => u.Id == solicitacaoDocumentoDto.UsuariosSolicitanteId);
            documento.DataEmissao = DateTime.Now;
            documento.Titulo = solicitacaoDocumentoDto.Titulo;

            documento.Historico = this.GeraHistoricoDocumento(documento);

            this.BeginTransaction();
                if (documento.Id > 0)
                {
                    _documentoRepository.Update(documento);
                }
                else
                {
                  _documentoRepository.Add(documento);
                  this.RegistrarTarefaElaboracao(documento);
                }
            this.Commit();

            this.EnviarEmailConfirmacaoSolicitacao(documento);
            this.EnviarEmailSolicitacao(documento);
        }
        private List<Historico> GeraHistoricoDocumento(EQualy.Domain.Entities.Documento documento)
        {
            var idUsuarioLogado = GetUserLogged().UsuarioId;
            var historico = new Historico
            {
                DataCriacao = DateTime.Now,
                Tipo = EQualy.Domain.Enum.Historico.TipoHistorico.FluxoDocumento,
                UsuarioCriou = _usuarioRepository.Get(u => u.Id == idUsuarioLogado)
            };

            switch (documento.FaseDocumento)
            {
                case EQualy.Domain.Enum.Documento.FaseDocumento.Aprovacao:
                    historico.Decricao = "Documento aprovado.";
                    break;
                case EQualy.Domain.Enum.Documento.FaseDocumento.Disponibilizado:
                    historico.Decricao = "Documento publicado e disponibilizado para utilização.";
                    break;
                case EQualy.Domain.Enum.Documento.FaseDocumento.Solicitacao:
                    historico.Decricao = "Realizado a solicitação de criação do documento.";
                    break;
                case EQualy.Domain.Enum.Documento.FaseDocumento.Reprovacao:
                    historico.Decricao = "Reprovação de documento na fase " + documento.FaseDocumento.ToString();
                    break;
                case EQualy.Domain.Enum.Documento.FaseDocumento.Revisao:
                    historico.Decricao = "Solicitação de revisão de documento.";
                    break;
                case EQualy.Domain.Enum.Documento.FaseDocumento.Publicacao:
                    historico.Decricao = "Documento aprovado para disponibilização.";
                    break;
                case EQualy.Domain.Enum.Documento.FaseDocumento.Elaboracao:
                    historico.Decricao = "Documento disponibilizado para revisão.";
                    break;
                default:
                    historico.Decricao = "Histórico não disponível.";
                    break;
            }

            documento.Historico.Add(historico);
            return documento.Historico;
        }
        public SolicitacaoDocumentoDto ObterSolicitacaoDocumentoPorId(int solicitacaoDocumentoId)
        {
            var documento = _documentoRepository.Get(d => d.Id == solicitacaoDocumentoId);
            return new SolicitacaoDocumentoDto
            {
                Id = documento.Id,
                DataEmissao = documento.DataEmissao,
                NumeroRevisao = documento.NumeroRevisao,
                Titulo = documento.Titulo,
                Observacao = documento.Observacao,
                FaseDocumento = (int)documento.FaseDocumento,
                LocalDigital = documento.LocalDigital,
                LocalFisico = documento.LocalFisico,
                SendoRevisado = documento.SendoRevisado,
                QtdNumeroCopia = documento.QtdNumeroCopia,
                TipoDeArmazenamento = (int)documento.TipoDeArmazenamento,
                SetorID = documento.SetorEnvolvido.Id,
                TipoDocumento = (int)documento.TipoDocumento,
                UsuariosAprovadorId = documento.UsuariosAprovador.Id,
                CodigoIdentificacao = documento.CodigoIdentificacao,
                UsuariosElaboradorId = documento.UsuariosElaborador.Id,
                UsuariosRevisores = documento.UsuariosRevisores.Select(ur => ur.Id).ToList(),
                UsuariosSolicitanteId = documento.UsuariosSolicitante.Id,
                Ativo = documento.Ativo,
                Historico = documento.Historico
            };
        }
        public void RegistrarTarefaElaboracao(EQualy.Domain.Entities.Documento documento)
        {
            var atividade = new Atividade
            {
                Tipo = EQualy.Domain.Enum.Atividade.TipoAtividade.ElaboracaoDocumento,
                Descricao = string.IsNullOrEmpty(documento.Observacao) ? string.Empty : documento.Observacao,
                StatusAtividade = EQualy.Domain.Enum.Atividade.StatusAtividade.Criada,
                DataConclusao = documento.DataEmissao.AddDays(4),
                DataCriacao = DateTime.Now,
                UsuarioCriou = documento.UsuariosSolicitante,
                UsuarioDestinoId = documento.UsuariosElaborador.Id,
                Titulo = "Elaborar documento",
            };

            _atividadeRepository.Add(atividade);
        }

        #endregion

        #region [ Fase 2 ]

        public void RegistraSolicitacaoDeRevisão(int documentoId, HttpPostedFileBase arquivo)
        {
            var documento = _documentoRepository.Get(documentoId);
            _arquivoService.SalvarArquivoDocumento(arquivo, documento.FaseDocumento, documentoId);

            documento.NomeArquivo = arquivo.FileName;
            documento.FaseDocumento = EQualy.Domain.Enum.Documento.FaseDocumento.Revisao;
            documento.Historico = this.GeraHistoricoDocumento(documento);
            this.BeginTransaction();
            _documentoRepository.Update(documento);
            RegistrarTarefaDeSolicitacaoDeRevisao(documento);
            this.Commit();
        }
        private void RegistrarTarefaDeSolicitacaoDeRevisao(EQualy.Domain.Entities.Documento documento)
        {
            foreach (var revisor in documento.UsuariosRevisores)
            {
                var atividade = new Atividade
                {
                    Tipo = EQualy.Domain.Enum.Atividade.TipoAtividade.RevisaoDocumento,
                    Descricao = string.IsNullOrEmpty(documento.Observacao) ? string.Empty : documento.Observacao,
                    StatusAtividade = EQualy.Domain.Enum.Atividade.StatusAtividade.Criada,
                    DataConclusao = documento.DataEmissao.AddDays(4),
                    DataCriacao = DateTime.Now,
                    UsuarioCriou = documento.UsuariosElaborador,
                    UsuarioDestinoId = revisor.Id,
                    Titulo = "Revisar documento código " + documento.CodigoIdentificacao + "_" + documento.Id,
                };

                _atividadeRepository.Add(atividade);
            }
        }

        #endregion

        #region [ Fase 3 ]

        public void RegistrarAprovacaoDeRevisao(SolicitacaoDocumentoDto solicitacaoDocumentoDto)
        {
            var documento = _documentoRepository.Get(d => d.Id == solicitacaoDocumentoDto.Id);
            var aprovacoes = documento.Aprovacoes;
            var idUsuarioAprovadorRevisao = GetUserLogged().UsuarioId;

            aprovacoes.Add(new AprovacaoDocumento
            {
                Aprovado = true,
                Data = DateTime.Now,
                UsuarioAprovador = documento.UsuariosRevisores.First(u => u.Id == idUsuarioAprovadorRevisao),
                DocumentoParaAprovacao = documento
            });

            if (documento.UsuariosRevisores.Count == aprovacoes.Count)
            {
                this.RegistrarTarefaDeAprovacaoFinalDeDocumento(documento);
                _arquivoService.AtualizaNomeDoArquivoFisico(documento);
            }

            documento.Aprovacoes = aprovacoes;
            documento.Historico = this.GeraHistoricoDocumento(documento);

            this.BeginTransaction();
            _documentoRepository.Update(documento);
            this.Commit();
        }
        public int ObterTotalDeAprocacoesDeRevisao(int documentoId)
        {
            var documento = _documentoRepository.Get(d => d.Id == documentoId);
            return documento.UsuariosRevisores.Count - documento.Aprovacoes.Count;
        }
        private void RegistrarTarefaDeAprovacaoFinalDeDocumento(EQualy.Domain.Entities.Documento documento)
        {
            var usuarioLogadoId = this.GetUserLogged().UsuarioId;

            var atividade = new Atividade
            {
                Tipo = EQualy.Domain.Enum.Atividade.TipoAtividade.AprovacaoDocumento,
                Descricao = string.IsNullOrEmpty(documento.Observacao) ? string.Empty : documento.Observacao,
                StatusAtividade = EQualy.Domain.Enum.Atividade.StatusAtividade.Criada,
                DataConclusao = documento.DataEmissao.AddDays(4),
                DataCriacao = DateTime.Now,
                UsuarioCriou = documento.UsuariosRevisores.First(u => u.Id == usuarioLogadoId),
                UsuarioDestinoId = documento.UsuariosAprovador.Id,
                Titulo = "Aprovação do documento " + _arquivoService.MontaNomeDocumentoPorFase(documento)
            };

            _atividadeRepository.Add(atividade);
        }
        public void RegistrarReprovacaoDeRevisao(SolicitacaoDocumentoDto solicitacaoDocumentoDto)
        {
            var documento = _documentoRepository.Get(d => d.Id == solicitacaoDocumentoDto.Id);

            documento.FaseDocumento = EQualy.Domain.Enum.Documento.FaseDocumento.Reprovacao;
            documento.Historico = this.GeraHistoricoDocumento(documento);
            documento.Aprovacoes = null;

            documento.FaseDocumento = EQualy.Domain.Enum.Documento.FaseDocumento.Elaboracao;
            this.BeginTransaction();
            _documentoRepository.Update(documento);
            this.RegistrarTarefaAjuste(documento, solicitacaoDocumentoDto.JustificativaReprovacao);
            this.Commit();
        }
        public void RegistrarTarefaAjuste(EQualy.Domain.Entities.Documento documento, string observacaoReprovacao)
        {
            var idUsuarioAprovadorRevisao = GetUserLogged().UsuarioId;
            var atividade = new Atividade
            {
                Tipo = EQualy.Domain.Enum.Atividade.TipoAtividade.AjustarDocumento,
                Descricao = string.IsNullOrEmpty(documento.Observacao) ? string.Empty : documento.Observacao,
                StatusAtividade = EQualy.Domain.Enum.Atividade.StatusAtividade.Criada,
                DataConclusao = documento.DataEmissao.AddDays(4),
                DataCriacao = DateTime.Now,
                UsuarioCriou = documento.UsuariosRevisores.First(u => u.Id == idUsuarioAprovadorRevisao),
                UsuarioDestinoId = documento.UsuariosElaborador.Id,
                Titulo = "Ajustar documento código " + documento.CodigoIdentificacao + "_" + documento.Id,
            };

            _atividadeRepository.Add(atividade);
        }

        #endregion

        #region [ Fase 4 ]

        public void RegistrarAprovacaoDeDocumento(SolicitacaoDocumentoDto solicitacaoDocumentoDto)
        {
            var documento = _documentoRepository.Get(d => d.Id == solicitacaoDocumentoDto.Id);
            var aprovacoes = documento.Aprovacoes.Where(a => a.Aprovado).ToList();
            var idUsuarioAprovador = GetUserLogged().UsuarioId;

            aprovacoes.Add(new AprovacaoDocumento
            {
                Aprovado = true,
                Data = DateTime.Now,
                UsuarioAprovador = documento.UsuariosRevisores.First(u => u.Id == idUsuarioAprovador),
                DocumentoParaAprovacao = documento,
            });

            this.RegistrarTarefaDePublicacaoDeDocumento(documento);
            _arquivoService.AtualizaNomeDoArquivoFisico(documento);

            documento.Aprovacoes = aprovacoes;
            documento.Historico = this.GeraHistoricoDocumento(documento);
            this.BeginTransaction();
            _documentoRepository.Update(documento);
            this.Commit();
        }

        private void RegistrarTarefaDePublicacaoDeDocumento(EQualy.Domain.Entities.Documento documento)
        {
            var idUsuarioAprovador = GetUserLogged().UsuarioId;
            var atividade = new Atividade
            {
                Tipo = EQualy.Domain.Enum.Atividade.TipoAtividade.AjustarDocumento,
                Descricao = "Documento " + _arquivoService.MontaNomeDocumentoPorFase(documento) + " " +
                            " foi aprovado. O usuário " + documento.UsuariosAprovador.Nome + " solicita sua publicação.",

                StatusAtividade = EQualy.Domain.Enum.Atividade.StatusAtividade.Criada,
                DataConclusao = documento.DataEmissao.AddDays(4),
                DataCriacao = DateTime.Now,
                UsuarioCriou = documento.UsuariosRevisores.First(u => u.Id == idUsuarioAprovador),
                UsuarioDestinoId = documento.UsuariosElaborador.Id,
                Titulo = "Publicação do documento código " + documento.CodigoIdentificacao + "_" + documento.Id,
            };

            _atividadeRepository.Add(atividade);
        }

        public void RegistrarReprovacaoDeDocumento(SolicitacaoDocumentoDto solicitacaoDocumentoDto)
        {
            var documento = _documentoRepository.Get(d => d.Id == solicitacaoDocumentoDto.Id);

            documento.FaseDocumento = EQualy.Domain.Enum.Documento.FaseDocumento.Reprovacao;
            documento.Historico = this.GeraHistoricoDocumento(documento);
            documento.Aprovacoes = null;

            documento.FaseDocumento = EQualy.Domain.Enum.Documento.FaseDocumento.Elaboracao;
            this.BeginTransaction();
            _documentoRepository.Update(documento);
            this.RegistrarTarefaAjuste(documento, solicitacaoDocumentoDto.JustificativaReprovacao);
            this.Commit();
        }

        #endregion

        #region [ Fase 5 ]

        public void RegistrarPublicacaoDeDocumento(SolicitacaoDocumentoDto solicitacaoDocumentoDto)
        {
            var documento = _documentoRepository.Get(d => d.Id == solicitacaoDocumentoDto.Id);

            documento.DataPublicacao = solicitacaoDocumentoDto.DataDePublicacao;
            documento.LocalFisico = solicitacaoDocumentoDto.LocalFisico;
            documento.CopiaControlada = solicitacaoDocumentoDto.CopiaControlada;
            documento.QtdNumeroCopia = solicitacaoDocumentoDto.QtdNumeroCopia;
            documento.Validade = solicitacaoDocumentoDto.Validade;

            documento.FaseDocumento = EQualy.Domain.Enum.Documento.FaseDocumento.Disponibilizado;
            documento.Historico = GeraHistoricoDocumento(documento);

            this.BeginTransaction();
                _documentoRepository.Update(documento);
            this.Commit();

            this.EnviarEmailDeAvisoDePublicacao(documento);
        }

        private void EnviarEmailDeAvisoDePublicacao(EQualy.Domain.Entities.Documento documento)
        {
            _emailService.Enviar(new EmailDto
            {
                Assunto = "Publicação de documento",
                Descricao = string.Format("O documento solicitado foi publicado para uso apartir da data de {0} \n Código : {1}"
                , DateTime.Now.Date, documento.Id),
                Titulo = "Publicação",
                EmailDestinatario = documento.UsuariosSolicitante.Email,
                Data = DateTime.Now,
                DescricaoAtividade = string.Empty

            });
        }

        #endregion
    }
}