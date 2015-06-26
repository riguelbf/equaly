using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.NaoConformidade.PlanoDeAcao
{
    [Binding]
    public class ManterReclamativa
    {
        [Given(@"as seguintes informações iniciais para a o cadastro de uma reclamativa")]
        public void DadoAsSeguintesInformacoesIniciaisParaAOCadastroDeUmaReclamativa(Table table)
        {
            Assert.IsTrue(true);
        }

        [When(@"registrar uma reclamativa")]
        public void QuandoRegistrarUmaReclamativa()
        {
            Assert.IsTrue(true);
        }

        [Then(@"automaticamente deve ser aberta uma não conformidade")]
        public void EntaoAutomaticamenteDeveSerAbertaUmaNaoConformidade()
        {
            Assert.IsTrue(true);
        }
    }
}
