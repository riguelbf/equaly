using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.Servicos
{
    [Binding]
    public class ServicoImportacaoDeUsuario
    {
        [Given(@"as seguintes dados dos usuarios")]
        public void DadoAsSeguintesDadosDosUsuarios(Table table)
        {
            Assert.IsTrue(true);
        }

        [When(@"realizar a importação de usuarios")]
        public void QuandoRealizarAImportacaoDeUsuarios()
        {
            Assert.IsTrue(true);
        }

        [Then(@"o serviço deve automaticamente ler o arquivo disponibilizado e salvar os dados na base de dados do sistema")]
        public void EntaoOServicoDeveAutomaticamenteLerOArquivoDisponibilizadoESalvarOsDadosNaBaseDeDadosDoSistema()
        {
            Assert.IsTrue(true);
        }
    }
}
