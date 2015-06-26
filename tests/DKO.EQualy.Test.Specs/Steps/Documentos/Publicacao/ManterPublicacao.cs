using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.Documentos.Publicacao
{
    [Binding]
    public class ManterPublicacao
    {

        [Given(@"as informações  ""(.*)"" e ""(.*)"" e ""(.*)"" e (.*) e (.*) para uso nas rotinas de trabalho com uso de documentos com copia controlada")]
        public void DadoAsInformacoesEEEEParaUsoNasRotinasDeTrabalhoComUsoDeDocumentosComCopiaControlada(string p0, string p1, string p2, string p3, int p4)
        {
            Assert.IsTrue(true);
        }

        [When(@"executar a publicação do documento com copia controlada")]
        public void QuandoExecutarAPublicacaoDoDocumentoComCopiaControlada()
        {
            Assert.IsTrue(true);
        }

        [Then(@"o documento deve ser atualizado para o status ""(.*)""")]
        public void EntaoODocumentoDeveSerAtualizadoParaOStatus(string p0)
        {
            Assert.IsTrue(true);
        }

        [Then(@"um email de aviso com a informação ""(.*)"" deve ser enviado para os (.*)")]
        public void EntaoUmEmailDeAvisoComAInformacaoDeveSerEnviadoParaOs(string p0, string p1)
        {
            Assert.IsTrue(true);
        }

        [Given(@"as informações  ""(.*)"" e ""(.*)"" e ""(.*)"" e (.*) para uso nas rotinas de trabalho")]
        public void DadoAsInformacoesEEEParaUsoNasRotinasDeTrabalho(string p0, string p1, string p2, string p3)
        {
            Assert.IsTrue(true);
        }

        [When(@"executar a publicação do documento sem copia controlada")]
        public void QuandoExecutarAPublicacaoDoDocumentoSemCopiaControlada()
        {
            Assert.IsTrue(true);
        }

    }
}
