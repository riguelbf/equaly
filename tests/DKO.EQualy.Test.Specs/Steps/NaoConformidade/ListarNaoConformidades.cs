using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.NaoConformidade
{
    [Binding]
    public class ListarNaoConformidades
    {
        [Given(@"os filtros por (.*) e (.*) e ""(.*)"" e ""(.*)"" e (.*)")]
        public void DadoOsFiltrosPorEEEE(int p0, int p1, string p2, string p3, int p4)
        {
            Assert.IsTrue(true);
        }

        [When(@"executar a consulta")]
        public void QuandoExecutarAConsulta()
        {
            Assert.IsTrue(true);
        }

        [Then(@"o número total de registros encontrados deve igual a (.*)")]
        public void EntaoONumeroTotalDeRegistrosEncontradosDeveIgualA(string p0)
        {
            Assert.IsTrue(true);
        }

        [Then(@"o número total de registros encontrados deve ser  é (.*)")]
        public void EntaoONumeroTotalDeRegistrosEncontradosDeveSerE(int p0)
        {
            Assert.IsTrue(true);
        }

    }
}
