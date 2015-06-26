﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18408
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace DKO.EQualy.Test.Specs.Specs.NaoConformidade
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ListarNaoConformidadesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ListarNaoConformidade.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "ListarNaoConformidades", "\r\nQuero consultar todas as não conformidades registradas e disponiveis com determ" +
                    "inados critérios", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "ListarNaoConformidades")))
            {
                DKO.EQualy.Test.Specs.Specs.NaoConformidade.ListarNaoConformidadesFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 9
#line hidden
        }
        
        public virtual void ListarNaoConformidadesUtilizandoCombinacaoDeFiltrosSemRetornoDeDados(string usuarioResponsavelId, string setorId, string dataInicial, string dataFinal, string status, string quantidadeDeRegistrosRetornados, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Listar NaoConformidades utilizando combinação de filtros sem retorno de dados", exampleTags);
#line 11
this.ScenarioSetup(scenarioInfo);
#line 9
this.FeatureBackground();
#line 12
testRunner.Given(string.Format("os filtros por {0} e {1} e {2} e {3} e {4}", usuarioResponsavelId, setorId, dataInicial, dataFinal, status), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 13
testRunner.When("executar a consulta", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 15
testRunner.Then("o número total de registros encontrados deve igual a <QuantidadeTotalDeRegistros>" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Listar NaoConformidades utilizando combinação de filtros sem retorno de dados")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListarNaoConformidades")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UsuarioResponsavelId", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:SetorId", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DataInicial", "\"01/01/2000\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DataFinal", "\"31/12/2020\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Status", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:QuantidadeDeRegistrosRetornados", "0")]
        public virtual void ListarNaoConformidadesUtilizandoCombinacaoDeFiltrosSemRetornoDeDados_1()
        {
            this.ListarNaoConformidadesUtilizandoCombinacaoDeFiltrosSemRetornoDeDados("1", "1", "\"01/01/2000\"", "\"31/12/2020\"", "1", "0", ((string[])(null)));
        }
        
        public virtual void ListarNaoConformidadesUtilizandoCombinacaoDeFiltrosComRetornoDeDados(string usuarioResponsavelId, string setorId, string dataInicial, string dataFinal, string status, string quantidadeTotalDeRegistrosComDados, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Listar NaoConformidades utilizando combinação de filtros com retorno de dados", exampleTags);
#line 21
this.ScenarioSetup(scenarioInfo);
#line 9
this.FeatureBackground();
#line 22
testRunner.Given(string.Format("os filtros por {0} e {1} e {2} e {3} e {4}", usuarioResponsavelId, setorId, dataInicial, dataFinal, status), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 23
testRunner.When("executar a consulta", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 25
testRunner.Then(string.Format("o número total de registros encontrados deve ser  é {0}", quantidadeTotalDeRegistrosComDados), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entao ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Listar NaoConformidades utilizando combinação de filtros com retorno de dados")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ListarNaoConformidades")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:UsuarioResponsavelId", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:SetorId", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DataInicial", "\"01/01/2000\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:DataFinal", "\"31/12/2020\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Status", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:QuantidadeTotalDeRegistrosComDados", "1")]
        public virtual void ListarNaoConformidadesUtilizandoCombinacaoDeFiltrosComRetornoDeDados_1()
        {
            this.ListarNaoConformidadesUtilizandoCombinacaoDeFiltrosComRetornoDeDados("1", "1", "\"01/01/2000\"", "\"31/12/2020\"", "1", "1", ((string[])(null)));
        }
    }
}
#pragma warning restore
#endregion