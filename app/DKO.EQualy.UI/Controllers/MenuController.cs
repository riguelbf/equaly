using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.Equaly.DTO.Menu;
using DKO.Equaly.Service;
using DKO.Equaly.Service.Concrete;
using Microsoft.Owin.Security.Provider;

namespace DKO.EQualy.UI.Controllers
{
    public class MenuController : BaseController
    {
        private readonly MenuService _menuService;
        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository, MenuService menuService)
        {
            this._menuRepository = menuRepository;
            this._menuService = menuService;
        }
        public MenuController(MenuService menuService)
        {
            this._menuService = menuService;
        }
        public PartialViewResult ObterMenuLateral()
        {
            var model = _menuService.ObterMenuPorPermissao(CustomPrincipal.Roles).ToList();
            return PartialView("Partials/_SideBarPartial", model);
        }

        public PartialViewResult ObterMenuSuperior()
        {
            var model = _menuService.ObterMenuSuperior(CustomPrincipal.UsuarioId);
            return PartialView("Partials/_TopNavigationMenuPartial", model);
        }
    }
}
