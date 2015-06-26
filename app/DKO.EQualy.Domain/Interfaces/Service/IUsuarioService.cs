using System.Collections.Generic;
using System.Web;
using DKO.EQualy.Domain.Entities;
using DKO.Equaly.DTO.Usuario;

namespace DKO.EQualy.Domain.Interfaces.Service
{
    public interface IUsuarioService
    {
        bool ValidateUserLogin(string userName, bool status);

        IList<Usuario> ObterUsuarios();

        Usuario ObterPorID(int usuarioId);

        #region [ Perfil ]

        PerfilDto ObterDadosPerfilUsuario(int usuarioId);

        void Salvar(PerfilDto perfilDto);

        void AtualizarSenha(PerfilDto perfilDto);

        void SalvarNovaFotoPerfil(HttpPostedFileBase fileUploader);

        #endregion
    }
}