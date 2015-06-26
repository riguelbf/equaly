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
namespace DKO.EQualy.Test.Specs.Specs.NaoConformidade.Reclamativa
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ManterReclamativaFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ManterReclamativa.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "ManterReclamativa", "\r\nQuero registrar uma não reclamativa e que automaticamente uma nova não conformi" +
                    "dade seja aberta", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "ManterReclamativa")))
            {
                DKO.EQualy.Test.Specs.Specs.NaoConformidade.Reclamativa.ManterReclamativaFeature.FeatureSetup(null);
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
#line 8
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("registrar uma reclamativa")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ManterReclamativa")]
        public virtual void RegistrarUmaReclamativa()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("registrar uma reclamativa", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "TituloDaOcorrencia",
                        "DataDeAbertura",
                        "NumeroDePedido",
                        "NomeDoReclamante",
                        "TelefoneContato",
                        "EmailDoReclamante",
                        "ReponsavelPelaAbertura",
                        "Descricao"});
            table1.AddRow(new string[] {
                        "\"Produto vencido\"",
                        "\"20/09/2014\"",
                        "\"00100\"",
                        "\"Riguel Figueiro\"",
                        "\"(51)84059454\"",
                        "\"riguel@equaly.com.br\"",
                        "\"Ana Paukner\"",
                        "\"O cliente esta reclamando que recebeu um produto vencido\""});
#line 14
testRunner.Given("as seguintes informações iniciais para a o cadastro de uma reclamativa", ((string)(null)), table1, "Dado ");
#line 18
testRunner.When("registrar uma reclamativa", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 19
testRunner.Then("automaticamente deve ser aberta uma não conformidade", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line 20
testRunner.And("um email de notificação para a o usuario <UsuarioId> deve ser enviado com a segui" +
                    "nte mensagem \"Uma nova reclamaiva foi registrada para você.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion