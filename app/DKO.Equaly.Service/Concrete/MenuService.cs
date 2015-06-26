using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.DTO.Menu;

namespace DKO.Equaly.Service.Concrete
{
    public class MenuService : ServiceBase, IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IAtividadeRepository _atividadeRepository;
        private readonly IMensagemRepository _mensagemRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public MenuService(IMenuRepository menuRepository, IAtividadeRepository atividadeRepository, IMensagemRepository mensagemRepository, IUsuarioRepository usuarioRepository)
        {
            _menuRepository = menuRepository;
            _atividadeRepository = atividadeRepository;
            _mensagemRepository = mensagemRepository;
            _usuarioRepository = usuarioRepository;
        }

        public List<Menu> ObterMenuPorPermissao(string roles)
        {
            if (string.IsNullOrEmpty(roles)) throw new Exception();
            return _menuRepository.GetMany(m => m.NiveisAcesso.Any(n => n.Tipo == roles)).ToList();
        }

        public MenuSuperiorDto ObterMenuSuperior(int usuarioId)
        {
            return new MenuSuperiorDto()
            {
                Mensagens = _mensagemRepository.GetMany(m => m.UsuarioDestinoId == usuarioId).ToList(),
                Tarefas = _atividadeRepository.GetMany(a => a.UsuarioDestinoId == usuarioId).ToList(),
                Usuario = _usuarioRepository.Get(u => u.Id == usuarioId)
            };
        }
    }
}