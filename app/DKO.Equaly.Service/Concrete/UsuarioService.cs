using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.DTO.Usuario;

namespace DKO.Equaly.Service.Concrete
{
    public class UsuarioService : ServiceBase, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IMensagemRepository _mensagemRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, IAtividadeRepository atividadeRepository, IMensagemRepository mensagemRepository)
        {
            _usuarioRepository = usuarioRepository;
            _atividadeRepository = atividadeRepository;
            _mensagemRepository = mensagemRepository;
        }

        public bool ValidateUserLogin(string userName, bool status)
        {
            return _usuarioRepository.GetMany(u => u.NomeUsuario == userName && u.NivelAcesso.Ativo == status).Any();
        }

        public IList<Usuario> ObterUsuarios()
        {
            return _usuarioRepository.GetAll().ToList();
        }

        public Usuario ObterPorID(int usuarioId)
        {
            return _usuarioRepository.Get(u => u.Id == usuarioId);
        }

        #region [ Perfil ]

        public PerfilDto ObterDadosPerfilUsuario(int usuarioId)
        {
            var p =  new PerfilDto()
                         {
                             Usuario = _usuarioRepository.Get(u => u.Id == usuarioId),
                             Atividades = _atividadeRepository.GetMany(a => a.UsuarioDestinoId == usuarioId).ToList(),
                             Mensagens = _mensagemRepository.GetMany(m => m.UsuarioDestinoId == usuarioId).ToList(),
                         };

            return p;
        }

        public void Salvar(PerfilDto perfilDto)
        {
            var usuario = _usuarioRepository.Get(u => u.Id == perfilDto.Usuario.Id);
            
            usuario.Nome = perfilDto.Usuario.Nome;
            usuario.NomeUsuario = perfilDto.Usuario.NomeUsuario;
            usuario.Matricula = perfilDto.Usuario.Matricula;
            
            this.BeginTransaction();
            _usuarioRepository.Update(usuario);
            this.Commit();
        }

        public void AtualizarSenha(PerfilDto perfilDto)
        {
            var usuario = _usuarioRepository.Get(u => u.Id == perfilDto.Usuario.Id);
            if(perfilDto.Senha != usuario.Senha)
                throw new Exception("Senha atual não confere");
            else if (perfilDto.Senha != perfilDto.ConfirmaSenha)
            {
                throw new Exception("Nova senha e confirme senha estão divergentes!");
            }
            else
            {
                usuario.Senha = perfilDto.NovaSenha;
                this.BeginTransaction();
                _usuarioRepository.Update(usuario);
                this.Commit();
            }
        }

        public void SalvarNovaFotoPerfil(HttpPostedFileBase fileUploader)
        {
            if (fileUploader == null || fileUploader.ContentLength <= 0) throw new Exception("Nehum arquivo selecionado");
            var fileName = Path.GetFileName(fileUploader.FileName);
            if (fileName == null) throw new Exception("Não foi possivel salvar o arquvo"); ;
            var path = Path.Combine("~/App_Data/uploads", fileName);
            fileUploader.SaveAs(path);
        }

        #endregion
    }
}