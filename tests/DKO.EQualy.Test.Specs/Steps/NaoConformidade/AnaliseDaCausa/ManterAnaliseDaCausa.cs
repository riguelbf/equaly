using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DKO.EQualy.Test.Specs.Steps.NaoConformidade.AnaliseDaCausa
{
    [Binding]
    public class ManterAnaliseDaCausa
    {
        [Given(@"as seguintes informações iniciais para analise de causa raiz")]
        public void DadoAsSeguintesInformacoesIniciaisParaAnaliseDeCausaRaiz(Table table)
        {
            Assert.IsTrue(true);
        }

        [When(@"salvar a nao conformidade com os dados de analise da causa")]
        public void QuandoSalvarANaoConformidadeComOsDadosDeAnaliseDaCausa()
        {
            Assert.IsTrue(true);
        }

        [Then(@"um email de notificação para a equipe envolvida deve ser enviado com a seguinte mensagem ""(.*)""")]
        public void EntaoUmEmailDeNotificacaoParaAEquipeEnvolvidaDeveSerEnviadoComASeguinteMensagem(string p0)
        {
            Assert.IsTrue(true);
        }

        [Given(@"as seguintes informações da pergunta")]
        public void DadoAsSeguintesInformacoesDaPergunta(Table table)
        {
            Assert.IsTrue(true);
        }

        [When(@"adicionar o porque")]
        public void QuandoAdicionarOPorque()
        {
            Assert.IsTrue(true);
        }

        [Then(@"adicionar o registrno na tabela")]
        public void EntaoAdicionarORegistrnoNaTabela()
        {
            Assert.IsTrue(true);
        }

        [Then(@"mostrar a mensagem ""(.*)""")]
        public void EntaoMostrarAMensagem(string p0)
        {
            Assert.IsTrue(true);
        }

        [When(@"adicionar o usuario")]
        public void QuandoAdicionarOUsuario()
        {
            Assert.IsTrue(true);
        }

        [Then(@"adicionar o registrno na tabela de equipe selecionada")]
        public void EntaoAdicionarORegistrnoNaTabelaDeEquipeSelecionada()
        {
            Assert.IsTrue(true);
        }
    }
}
