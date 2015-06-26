using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.DTO.Email;
using DKO.Equaly.DTO.NaoConformidade;
using DKO.Equaly.Projection.NaoConformidade.AnaliseDaCausa;

namespace DKO.Equaly.Service.Concrete.NaoConformidade
{
    public class CausaRaizService : ServiceBase, ICausaRaizService
    {
        private readonly ICausaRaizRepository _causaRaizRepository;
        private readonly INaoConformidadeRepository _naoConformidadeRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmailService _emailService;

        public CausaRaizService(ICausaRaizRepository causaRaizRepository
                               , INaoConformidadeRepository naoConformidadeRepository
                               , IUsuarioRepository usuarioRepository
                               , IEmailService emailService)
        {
            this._causaRaizRepository = causaRaizRepository;
            this._naoConformidadeRepository = naoConformidadeRepository;
            this._usuarioRepository = usuarioRepository;
            this._emailService = emailService;
        }
        public AnaliseDaCausaDto ObterAnaliseDaCausaDto(int naoConformidadeId)
        {
            var causaRaiz = _naoConformidadeRepository.Get(naoConformidadeId).CausaRaiz;

            if (causaRaiz == null) return new AnaliseDaCausaDto
             {
                 EquipeEnvolvidaDisponivel = _usuarioRepository.GetAll()
                                             .ToList().ConvertAll(r => new EquipeEnvolvidaProjection
                                             {
                                                 Id = r.Id,
                                                 Nome = r.Nome,
                                                 NomeSetor = r.Setor.Nome
                                             })
             };

            var idsUsuarios = causaRaiz.UsuariosEnvolvidos.Select(e => e.Id).ToList();
            var equipeDisponivel = _usuarioRepository.GetAll().Where(r => !idsUsuarios.Contains(r.Id))
                                                                                      .ToList();
            return new AnaliseDaCausaDto
            {
                CausaRaizId = causaRaiz.Id,
                NaoConformidadeId = causaRaiz.NaoConformidade.Id,
                DataConclusao = causaRaiz.DataConclusao,
                DefinicaoDaCausaRaiz = causaRaiz.DescricaoDefinicao,
                CincoPorQue = causaRaiz.CincoPorQues.ConvertAll(cp => new CincoPorQueProjection
                {
                    Id = cp.Id,
                    NomeUsuarioDestino = cp.UsuarioDestino.Nome,
                    Pergunta = cp.Pergunta,
                    Resposta = cp.Resposta,
                    UsuarioDestinoId = cp.UsuarioDestino.Id
                }),
                EquipeEnvolvidaSelecionada = causaRaiz.UsuariosEnvolvidos.ConvertAll(u => new EquipeEnvolvidaProjection
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    NomeSetor = u.Setor.Nome
                }),
                EquipeEnvolvidaDisponivel = equipeDisponivel.ConvertAll(r => new EquipeEnvolvidaProjection
                                            {
                                                Id = r.Id,
                                                Nome = r.Nome,
                                                NomeSetor = r.Setor.Nome
                                            })

            };
        }

        public void Registrar(AnaliseDaCausaDto analiseDaCausaDto)
        {
            var enviaEmail = false;
            var usuarioCriouId = this.GetUserLogged().UsuarioId;
            var idsUsuarios = analiseDaCausaDto.EquipeEnvolvidaSelecionada.Select(e => e.Id).ToList();
            var equipeSelecionada = _usuarioRepository.GetAll().Where(r => idsUsuarios.Contains(r.Id))
                                                                                      .ToList();

            var naoConformidade = _naoConformidadeRepository.Get(analiseDaCausaDto.NaoConformidadeId);

            if (naoConformidade.CausaRaiz == null || naoConformidade.CausaRaiz.Id == 0)
            {
                Salvar(analiseDaCausaDto, naoConformidade, equipeSelecionada, usuarioCriouId);
            }
            else
            {
                Atualizar(analiseDaCausaDto, naoConformidade, equipeSelecionada, usuarioCriouId);
            }
        }

        private void Salvar(AnaliseDaCausaDto analiseDaCausaDto, EQualy.Domain.Entities.NaoConformidade naoConformidade, List<Usuario> equipeSelecionada,
            int usuarioCriouId)
        {
            bool enviaEmail;
            naoConformidade.CausaRaiz = ObterNovaCausaRaiz(analiseDaCausaDto, equipeSelecionada);
            enviaEmail = naoConformidade.CausaRaiz == null || naoConformidade.CausaRaiz.Id == 0 ? true : false;

            var historicos = naoConformidade.HistoricoRncs;
            historicos.Add(new Historico
            {
                DataCriacao = DateTime.Now,
                Decricao = "Registrada a causa raiz",
                Tipo = EQualy.Domain.Enum.Historico.TipoHistorico.FluxoRnc,
                UsuarioCriou = _usuarioRepository.Get(usuarioCriouId)
            });

            naoConformidade.HistoricoRncs = historicos;

            this.BeginTransaction();
            _naoConformidadeRepository.Update(naoConformidade);
            this.Commit();

                this.EnvioDeEmailDeNotificacaoParaEquipe(equipeSelecionada.ToList(), naoConformidade.Id);
        }

        private void Atualizar(AnaliseDaCausaDto analiseDaCausaDto, EQualy.Domain.Entities.NaoConformidade naoConformidade, List<Usuario> equipeSelecionada,
            int usuarioCriouId)
        {
            var historicos = naoConformidade.HistoricoRncs;
            historicos.Add(new Historico
            {
                DataCriacao = DateTime.Now,
                Decricao = "Atualizada a causa raiz",
                Tipo = EQualy.Domain.Enum.Historico.TipoHistorico.FluxoRnc,
                UsuarioCriou = _usuarioRepository.Get(usuarioCriouId)
            });

            var equipeAntigaId = naoConformidade.CausaRaiz.UsuariosEnvolvidos.Select(e => e.Id).ToList();
            var novaEquipe = equipeSelecionada.Where(es => !equipeAntigaId.Contains(es.Id));

            naoConformidade.HistoricoRncs = historicos;
            naoConformidade.CausaRaiz.CincoPorQues.Clear();
            naoConformidade.CausaRaiz.CincoPorQues = analiseDaCausaDto.CincoPorQue.ToList().ConvertAll(cp => new CincoPorQues
            {
                Id = cp.Id,
                Pergunta = cp.Pergunta,
                Resposta = cp.Resposta,
                UsuarioDestino = equipeSelecionada.First(e => e.Id == cp.UsuarioDestinoId)

            }).ToList();

            naoConformidade.CausaRaiz.DataConclusao = analiseDaCausaDto.DataConclusao;
            naoConformidade.CausaRaiz.DescricaoDefinicao = analiseDaCausaDto.DefinicaoDaCausaRaiz;
            naoConformidade.CausaRaiz.Id = analiseDaCausaDto.CausaRaizId;
            naoConformidade.CausaRaiz.UsuariosEnvolvidos.Clear(); 
            naoConformidade.CausaRaiz.UsuariosEnvolvidos = equipeSelecionada.ToList();

            this.BeginTransaction();
            _naoConformidadeRepository.Update(naoConformidade);
            this.Commit();

            this.EnvioDeEmailDeNotificacaoParaEquipe(novaEquipe.ToList(), naoConformidade.Id);
        }

        private CausaRaiz ObterNovaCausaRaiz(AnaliseDaCausaDto analiseDaCausaDto, IEnumerable<Usuario> equipeSelecionada)
        {
            var causaRaiz = analiseDaCausaDto.CausaRaizId == 0 ? new CausaRaiz() : _causaRaizRepository.Get(analiseDaCausaDto.CausaRaizId);

            causaRaiz.CincoPorQues = analiseDaCausaDto.CincoPorQue.ToList().ConvertAll(cp => new CincoPorQues
            {
                Id = cp.Id,
                Pergunta = cp.Pergunta,
                Resposta = cp.Resposta,
                UsuarioDestino = equipeSelecionada.First(e => e.Id == cp.UsuarioDestinoId)

            }).ToList();

            causaRaiz.DataConclusao = analiseDaCausaDto.DataConclusao;
            causaRaiz.DescricaoDefinicao = analiseDaCausaDto.DefinicaoDaCausaRaiz;
            causaRaiz.Id = analiseDaCausaDto.CausaRaizId;
            causaRaiz.UsuariosEnvolvidos = equipeSelecionada.ToList();

            return causaRaiz;
        }

        private void EnvioDeEmailDeNotificacaoParaEquipe(IEnumerable<Usuario> usuariosEnvolvidos,int naoConformidadeId)
        {
            foreach (var usuarioEnvolvido in usuariosEnvolvidos)
            {
                _emailService.Enviar(new EmailDto
                {
                    DescricaoAtividade = "Ocorrência EQualy",
                    Assunto = "Ocorrência EQualy",
                    Data = DateTime.Now,
                    EmailDestinatario = usuarioEnvolvido.Email,
                    Descricao = "Você foi indicado para participar da equipe de execução dos planos de ações referente a ocorrência nº " + naoConformidadeId +".",
                    Titulo = "Equipe para plano de ação",
                    
                });
            }
        }
    }
}