using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using System.Web.Security;
using DKO.EQualy.Domain.Entities;
using DKO.EQualy.Domain.Interfaces;
using DKO.EQualy.Domain.Interfaces.Repository;
using DKO.Equaly.DTO.Usuario;
using DKO.EQualy.Infra.IOC;
using DKO.Equaly.Service.Security;
using DKO.EQualy.UI.Models;
using Newtonsoft.Json;

namespace DKO.EQualy.UI.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ActionResult Index()
        {
            return View("Login");
        }

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioLoginDto usuarioDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = _usuarioRepository.Get(u => u.NomeUsuario == usuarioDto.NomeUsuario && u.Senha == usuarioDto.Senha);
                    if (usuario != null)
                    {
                        var customPrincripal = new CustomPrincipalSerializeModel()
                        {
                            UsuarioId = usuario.Id,
                            Nome = usuario.Nome,
                            Sobrenome = usuario.NomeUsuario == usuario.NomeUsuario.Substring(usuario.NomeUsuario.IndexOf(usuario.NomeUsuario), usuario.NomeUsuario.Length).Trim() ? string.Empty : usuario.NomeUsuario.Substring(usuario.NomeUsuario.IndexOf(usuario.NomeUsuario), usuario.NomeUsuario.Length).Trim(),
                            Roles = usuario.NivelAcesso.Tipo
                        };

                        System.Web.HttpContext.Current.Session.Add("__USUARIO__", customPrincripal);
                        var userData = JsonConvert.SerializeObject(customPrincripal);
                        var authTicket = new FormsAuthenticationTicket(
                        1,
                        usuario.Email,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(60),
                        usuarioDto.LembrarMe,
                        userData);

                        var encTicket = FormsAuthentication.Encrypt(authTicket);
                        var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        Response.Cookies.Add(faCookie);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Usuário e/ou senha incorretos";
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Ocorreu um erro ao tentar realizar o login";
                }

            }
            catch (Exception ex)
            {

                throw new HttpException(ex.Message);
            }
            
            return View("Login");
        }

        public ActionResult RecoverPassword(Usuario usuario)
        {
            return null;
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Login");
        }

    }
}
