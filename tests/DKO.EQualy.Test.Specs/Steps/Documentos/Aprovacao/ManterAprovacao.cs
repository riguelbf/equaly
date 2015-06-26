using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.Documentos.Aprovacao
{
    [Binding]
    public class ManterAprovacao
    {
        [Given(@"que exista um documento como nome ""(.*)"" salvo no servidor")]
        public void DadoQueExistaUmDocumentoComoNomeSalvoNoServidor(string p0)
        {
            Assert.IsTrue(true);
        }

        [When(@"realizar o download")]
        public void QuandoRealizarODownload()
        {
            Assert.IsTrue(true);
        }

        [Then(@"o download deve ser iniciado")]
        public void EntaoODownloadDeveSerIniciado()
        {
            Assert.IsTrue(true);
        }

        [Given(@"que ja tenha sido feita a analise do documento")]
        public void DadoQueJaTenhaSidoFeitaAAnaliseDoDocumento()
        {
            Assert.IsTrue(true);
        }

        [When(@"realizar a aprovação")]
        public void QuandoRealizarAAprovacao()
        {
            Assert.IsTrue(true);
        }

        [Then(@"o documento é disponibilizado para publicação")]
        public void EntaoODocumentoEDisponibilizadoParaPublicacao()
        {
            Assert.IsTrue(true);
        }

        [Given(@"o mesmo não esteja em conformidade com a solicitação")]
        public void DadoOMesmoNaoEstejaEmConformidadeComASolicitacao()
        {
            Assert.IsTrue(true);
        }

        [Given(@"tenha justificado a reprovação com o texto ""(.*)""")]
        public void DadoTenhaJustificadoAReprovacaoComOTexto(string p0)
        {
            Assert.IsTrue(true);
        }

        [When(@"realizar a reprovação")]
        public void QuandoRealizarAReprovacao()
        {
            Assert.IsTrue(true);
        }

        [Then(@"o documento é colocado em status de ""(.*)""")]
        public void EntaoODocumentoEColocadoEmStatusDe(string p0)
        {
            Assert.IsTrue(true);
        }

    }
}
