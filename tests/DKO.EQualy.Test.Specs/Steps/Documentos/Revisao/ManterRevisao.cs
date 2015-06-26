using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.Documentos.Revisao
{
    [Binding]
    public class ManterRevisao
    {
        [When(@"realizar o download para revisar")]
        public void QuandoRealizarODownloadParaRevisar()
        {
            Assert.IsTrue(true);
        }

        [Given(@"que ja tenha sido feita a analise do documento na fase de revisão")]
        public void DadoQueJaTenhaSidoFeitaAAnaliseDoDocumentoNaFaseDeRevisao()
        {
            Assert.IsTrue(true);
        }

        [When(@"realizar a aprovação em fase de revisão")]
        public void QuandoRealizarAAprovacaoEmFaseDeRevisao()
        {
            Assert.IsTrue(true);
        }

        [Then(@"o documento é disponibilizado para publicação apos a revisao")]
        public void EntaoODocumentoEDisponibilizadoParaPublicacaoAposARevisao()
        {
            Assert.IsTrue(true);
        }

        [Given(@"o mesmo não esteja em conformidade com a solicitação apos a revisão")]
        public void DadoOMesmoNaoEstejaEmConformidadeComASolicitacaoAposARevisao()
        {
            Assert.IsTrue(true);
        }

    }
}
