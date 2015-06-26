using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.NaoConformidade.AvaliacaoDaEficacia
{
    [Binding]
    public class ManterAvaliacaoDaEficacia
    {
        [Given(@"as seguintes informações iniciais para a avaliação da eficacia")]
        public void DadoAsSeguintesInformacoesIniciaisParaAAvaliacaoDaEficacia(Table table)
        {
            Assert.IsTrue(true);
        }

        [When(@"salvar a nao conformidade com os dados de avaliação de eficacia")]
        public void QuandoSalvarANaoConformidadeComOsDadosDeAvaliacaoDeEficacia()
        {
            Assert.IsTrue(true);
        }
    }
}
