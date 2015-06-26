using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.Documentos.Elaboracao
{
    [Binding]
    public class ManterElaboracao
    {
        [Given(@"que exista um documento com o nome ""(.*)"" salvo no servidor")]
        public void DadoQueExistaUmDocumentoComONomeSalvoNoServidor(string p0)
        {
            Assert.IsTrue(true);
        }

        [When(@"realizar o upload")]
        public void QuandoRealizarOUpload()
        {
            Assert.IsTrue(true);
        }

        [Then(@"arquivo com o nome ""(.*)"" deve ser salvo no servidor")]
        public void EntaoArquivoComONomeDeveSerSalvoNoServidor(string p0)
        {
            Assert.IsTrue(true);
        }

        [Then(@"um email de aviso aos revisores deve ser enviado")]
        public void EntaoUmEmailDeAvisoAosRevisoresDeveSerEnviado()
        {
            Assert.IsTrue(true);
        }

        [Then(@"alterar o status do documento para ""(.*)""")]
        public void EntaoAlterarOStatusDoDocumentoPara(string p0)
        {
            Assert.IsTrue(true);
        }
    }
}
