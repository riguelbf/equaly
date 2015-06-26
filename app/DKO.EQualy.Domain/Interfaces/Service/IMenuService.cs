using System.Collections.Generic;
using DKO.EQualy.Domain.Entities;
using DKO.Equaly.DTO.Menu;

namespace DKO.EQualy.Domain.Interfaces.Service
{
    public interface IMenuService
    {
        List<Menu> ObterMenuPorPermissao(string roles);

        MenuSuperiorDto ObterMenuSuperior(int usuarioId);
    }
}