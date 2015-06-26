using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.Documentos.Solicitacao
{
    [Binding]
    public class ManterSolicitacao
    {
        [Given(@"as seguintes informações iniciais")]
        public void DadoAsSeguintesInformacoesIniciais(Table table)
        {
            Assert.IsTrue(true);
        }

        [When(@"salvar o documento")]
        public void QuandoSalvarODocumento()
        {
            Assert.IsTrue(true);
        }

        [Then(@"eu espero receber a seguinte informação ""(.*)""")]
        public void EntaoEuEsperoReceberASeguinteInformacao(string p0)
        {
            Assert.IsTrue(true);
        }

        [Then(@"um email de notificação para o elaborador deve ser enviado com a seguinte mensagem ""(.*)""")]
        public void EntaoUmEmailDeNotificacaoParaOElaboradorDeveSerEnviadoComASeguinteMensagem(string p0)
        {
            Assert.IsTrue(true);
        }

    }
}
