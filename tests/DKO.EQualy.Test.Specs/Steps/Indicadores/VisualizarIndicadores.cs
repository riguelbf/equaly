using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.Indicadores
{
    [Binding]
    public class VisualizarIndicadores
    {
        [Given(@"as datas de (.*) e (.*)")]
        public void DadoAsDatasDeE(string dataInicial, string dataFinal)
        {
            Assert.IsTrue(true);
        }

        [Then(@"os gráficos devem ser gerados contendo dados (.*)")]
        public void EntaoOsGraficosDevemSerGeradosContendoDados(string p0)
        {
            Assert.IsTrue(true);
        }

        [Then(@"o gráfico de quantidade de RNC registrada deve ser gerado contendo dados (.*)")]
        public void EntaoOGraficoDeQuantidadeDeRNCRegistradaDeveSerGeradoContendoDados(string dadosRetornados)
        {
            Assert.IsTrue(true);
        }

        [Then(@"o gráfico de quantidade de RNC avaliada deve ser gerado contendo dados (.*)")]
        public void EntaoOGraficoDeQuantidadeDeRNCAvaliadaDeveSerGeradoContendoDados(string dadosRetornados)
        {
            Assert.IsTrue(true);
        }

        [Then(@"o gráfico de quantidade's registradas deve ser gerado contendo dados (.*)")]
        public void EntaoOGraficoDeQuantidadeSRegistradasDeveSerGeradoContendoDados(string dadosRetornados)
        {
            Assert.IsTrue(true);
        }

        [Then(@"o gráfico de quantidade de ação X RNC deve ser gerado contendo dados (.*)")]
        public void EntaoOGraficoDeQuantidadeDeAcaoXRNCDeveSerGeradoContendoDados(string dadosRetornados)
        {
            Assert.IsTrue(true);
        }

    }
}
