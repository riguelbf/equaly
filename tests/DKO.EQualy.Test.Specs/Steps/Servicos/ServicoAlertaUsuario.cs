using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.Servicos
{
    [Binding]
    public class ServicoAlertaUsuario
    {
        [Given(@"as seguintes informações iniciais para a o envio de alerta do tipo tarefa")]
        public void DadoAsSeguintesInformacoesIniciaisParaAOEnvioDeAlertaDoTipoTarefa(Table table)
        {
            Assert.IsTrue(true);
        }

        [When(@"enviar o alerta de nova tarefa")]
        public void QuandoEnviarOAlertaDeNovaTarefa()
        {
            Assert.IsTrue(true);
        }

        [Then(@"o serviço deve automaticamente registrar a nova tarefa")]
        public void EntaoOServicoDeveAutomaticamenteRegistrarANovaTarefa()
        {
            Assert.IsTrue(true);
        }

        [Given(@"o codigo do usuário")]
        public void DadoOCodigoDoUsuario()
        {
            Assert.IsTrue(true);
        }

        [When(@"executar a consulta das tarefas pertencentes ao usuário")]
        public void QuandoExecutarAConsultaDasTarefasPertencentesAoUsuario()
        {
            Assert.IsTrue(true);
        }
    }
}
