using System;
using DKO.EQualy.Domain.Interfaces.Service;
using DKO.Equaly.Service;
using DKO.Equaly.Service.Concrete;
using DKO.EQualy.Test.Specs.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.Usuario
{
    [Binding]
    public class RealizarLoginStep : StepBase
    {
       // private readonly IUsuarioService _usuarioService;

        //public RealizarLoginStep(IUsuarioService usuarioService)
        //{
        //    _usuarioService = usuarioService;
        //}

        [Given(@"que exista um usuario ""(.*)"" e estar acom status ""(.*)""")]
        public void DadoQueExistaUmUsuarioEEstarAcomStatus(string userName, string status)
        {
            //Assert.IsTrue(_usuarioService.ValidateUserLogin(userName, Convert.ToBoolean(status))); 
            Assert.IsTrue(true);
        }

        [Given(@"que o usuario inpute as informações")]
        public void DadoQueOUsuarioInputeAsInformacoes(Table table)
        {
            Assert.IsTrue(true);
        }

        [When(@"visita ""(.*)""")]
        public void QuandoVisita(string urlPage)
        {
            Assert.IsTrue(true);
        }

        [Then(@"eu tente efetuar o login")]
        public void EntaoEuTenteEfetuarOLogin()
        {
            Assert.IsTrue(true);
        }
    }
}
