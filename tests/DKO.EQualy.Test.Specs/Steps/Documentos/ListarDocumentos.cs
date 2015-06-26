using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.Documentos
{
    [Binding]
    public class ListarDocumentos
    {

        [Given(@"os filtros por ""(.*)"" e ""(.*)"" e ""(.*)"" e (.*) e (.*) e (.*) para pesquisa sem registros")]
        public void DadoOsFiltrosPorEEEEEParaPesquisaSemRegistros(string p0, string p1, string p2, int p3, int p4, int p5)
        {
            Assert.IsTrue(true);
        }

        [When(@"executar a consulta sem registros")]
        public void QuandoExecutarAConsultaSemRegistros()
        {
            Assert.IsTrue(true);
        }

        [Then(@"o número total de registros de documentos encontrados deve ser (.*)")]
        public void EntaoONumeroTotalDeRegistrosDeDocumentosEncontradosDeveSer(string p0)
        {
            Assert.IsTrue(true);
        }

        [Given(@"os filtros por ""(.*)"" e ""(.*)"" e ""(.*)"" e (.*) e (.*) e (.*) para pesquisa com registros")]
        public void DadoOsFiltrosPorEEEEEParaPesquisaComRegistros(string p0, string p1, string p2, int p3, int p4, int p5)
        {
            Assert.IsTrue(true);
        }

        [When(@"executar a consulta com registros")]
        public void QuandoExecutarAConsultaComRegistros()
        {
            Assert.IsTrue(true);
        }

        [Then(@"o número total de registros de documentos encontrados é  maior do que (.*)")]
        public void EntaoONumeroTotalDeRegistrosDeDocumentosEncontradosEMaiorDoQue(int p0)
        {
            Assert.IsTrue(true);
        }

    }
}
