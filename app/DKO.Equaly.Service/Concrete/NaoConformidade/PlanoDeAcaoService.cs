using System;
using System.Collections.Generic;
using System.Linq;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.DTO.NaoConformidade.PlanoDeAcao;
using DKO.Equaly.Projection.NaoConformidade.PlanoDeAcao;

namespace DKO.Equaly.Service.Concrete.NaoConformidade
{
    public class PlanoDeAcaoService : ServiceBase, IPlanoDeAcaoService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly INaoConformidadeRepository _naoConformidadeRepository;

        public PlanoDeAcaoService(IUsuarioRepository usuarioRepository,INaoConformidadeRepository naoConformidadeRepository)
        {
            this._usuarioRepository = usuarioRepository;
            this._naoConformidadeRepository = naoConformidadeRepository;
        }
        public void RegistrarPlanoDeAcao(PlanoDeAcaoDto planoDeAcaoDto)
        {
            var naoConformidade = _naoConformidadeRepository.Get(planoDeAcaoDto.NaoConformidadeId);

            if (naoConformidade.PlanoDeAcao == null)
                naoConformidade.PlanoDeAcao = new PlanoDeAcao
                {
                    DataConclusaoValidacao = DateTime.Now.AddDays(5)
                    
                };

            naoConformidade.PlanoDeAcao.Ferramenta5W2H.Clear();

            naoConformidade.PlanoDeAcao.Ferramenta5W2H =
                planoDeAcaoDto.PlanoDeAcaoProjections.Select(dto => new Ferramenta5W2H
                {
                    Como = dto.Como,
                    Id = dto.PlanoDeAcaoId,
                    DataConclusao = dto.DataConclusao.AddDays(7),
                    DataCriacao = DateTime.Now,
                    Status = dto.Status,
                    OQue = dto.OQue,
                    PorQue = dto.PorQue,
                    Onde = dto.Onde,
                    Quando = dto.Quando,
                    QuantoCusta = dto.QuantoCusta,
                    Quem = dto.NomeQuem,
                    TipoDePlanoDeAcao = (EQualy.Domain.Enum.NaoConformidade.TipoDePlanoDeAcao)dto.TipoDePlanoDeAcaoId

                }).ToList();

            var usuarioCriouId = this.GetUserLogged().UsuarioId;
            var usuarioCriou = _usuarioRepository.Get(usuarioCriouId);

            this.RegistrarHistorico(naoConformidade.HistoricoRncs, true, usuarioCriou);

            this.BeginTransaction();
                _naoConformidadeRepository.Update(naoConformidade);
            this.Commit();
        }

        private List<Historico> RegistrarHistorico(List<Historico> historicoRncs, bool atualizacao, DKO.EQualy.Domain.Entities.Usuario usuarioCriou)
        {
            if (atualizacao)
            {
                historicoRncs.Add(new Historico
                {
                    DataCriacao = DateTime.Now,
                    UsuarioCriou = usuarioCriou,
                    Decricao = "Registro de plano de ação atualizado.",
                    Tipo = EQualy.Domain.Enum.Historico.TipoHistorico.FluxoRnc
                });
            }
            else
            {
                historicoRncs.Add(new Historico
                {
                    DataCriacao = DateTime.Now,
                    UsuarioCriou = usuarioCriou,
                    Decricao = "Registro de plano de ação cadastrado.",
                    Tipo = EQualy.Domain.Enum.Historico.TipoHistorico.FluxoRnc
                });
            }

            return historicoRncs;
        }

        public PlanoDeAcaoDto ObterPlanoDeAcaoDto(int naoConformidadeId)
        {
           var naoConformidade =  _naoConformidadeRepository.Get(naoConformidadeId);

           if (naoConformidade == null || naoConformidade.PlanoDeAcao == null) return null;

            return new PlanoDeAcaoDto
            {
                NaoConformidadeId = naoConformidadeId,
                PlanoDeAcaoProjections = naoConformidade.PlanoDeAcao.Ferramenta5W2H.Select(f => new PlanoDeAcaoProjection
                {
                    Como = f.Como,
                    DataCadastro = f.DataCriacao,
                    DataConclusao = f.DataConclusao,
                    OQue = f.OQue,
                    NomeQuem = f.Quem,
                    Onde = f.Onde,
                    PorQue = f.PorQue,
                    Quando = f.Quando,
                    Status = f.Status,
                    QuantoCusta = f.QuantoCusta,
                    TipoDePlanoDeAcaoId = (int)f.TipoDePlanoDeAcao,
                    NaoConformidadeId = naoConformidadeId,
                    PlanoDeAcaoId = f.Id,
                    //UsuarioQuemId = _usuarioRepository.Get(u => u.Nome == f.Quem).Id ?? 0
                })
            };
        }
    }
}