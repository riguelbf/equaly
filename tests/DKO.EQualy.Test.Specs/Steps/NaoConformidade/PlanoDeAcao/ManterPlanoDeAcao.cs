using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.NaoConformidade.PlanoDeAcao
{
    [Binding]
    public class ManterPlanoDeAcao
    {
        [Given(@"as seguintes informações iniciais para a o cadastro de acao corretiva")]
        public void DadoAsSeguintesInformacoesIniciaisParaAOCadastroDeAcaoCorretiva(Table table)
        {
            Assert.IsTrue(true);
        }

        [When(@"registrar um plano de ação do tipo acao corretiva")]
        public void QuandoRegistrarUmPlanoDeAcaoDoTipoAcaoCorretiva()
        {
            Assert.IsTrue(true);
        }

        [Then(@"um email de notificação para a o usuario (.*) deve ser enviado com a seguinte mensagem ""(.*)""")]
        public void EntaoUmEmailDeNotificacaoParaAOUsuarioDeveSerEnviadoComASeguinteMensagem(string p0, string p1)
        {
            Assert.IsTrue(true);
        }

        [Given(@"as seguintes informações iniciais para a o cadastro de acao preventiva")]
        public void DadoAsSeguintesInformacoesIniciaisParaAOCadastroDeAcaoPreventiva(Table table)
        {
            Assert.IsTrue(true);
        }

        [When(@"registrar um plano de ação do tipo acao preventiva")]
        public void QuandoRegistrarUmPlanoDeAcaoDoTipoAcaoPreventiva()
        {
            Assert.IsTrue(true);
        }
    }
}
