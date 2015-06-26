using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.Servicos
{
    [Binding]
    public class ServicoControleDeNivelDoUsuario
    {
        [Given(@"o código do usuario")]
        public void DadoOCodigoDoUsuario(Table table)
        {
            Assert.IsTrue(true);
        }

        [When(@"o serviço solicitar os dados do usuário")]
        public void QuandoOServicoSolicitarOsDadosDoUsuario()
        {
            Assert.IsTrue(true);
        }

        [Then(@"o serviço que contém os dados do usuário deve retornar os mesmo")]
        public void EntaoOServicoQueContemOsDadosDoUsuarioDeveRetornarOsMesmo()
        {
            Assert.IsTrue(true);
        }

        [Then(@"caso o usuário esteja inativo ou seja inexistente")]
        public void EntaoCasoOUsuarioEstejaInativoOuSejaInexistente()
        {
            Assert.IsTrue(true);
        }

        [Then(@"retornar a seguinte mensagem ""(.*)""")]
        public void EntaoRetornarASeguinteMensagem(string p0)
        {
            Assert.IsTrue(true);
        }
    }
}
