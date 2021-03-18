using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using SpecFlowSearchEngine_report.Pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using SpecFlowSearchEngine_report.Hooks;
using AventStack.ExtentReports.Reporter;
using System.IO;

namespace SpecFlowSearchEngine_report.Steps
{
    [Binding]
    public sealed class SearchAppStepDefinitions
    {
        
        IWebDriver driver;
        HomePage home_page;
        ResultPage result_page;
        TargetPage target_page;
        
        public static ExtentReports extent;
        public ExtentTest _test;
        public String TC_Name;

    
        [Given(@"Estou na página principal do Google")]
        public void GivenEstouNaPaginaPrincipalDoGoogle()
        {
            String expected_title = "Google";
            driver = MainHook_Generic.getDriver();
            driver.Manage().Window.Maximize();
            home_page = new HomePage(driver);
            
            home_page.goToPage();
            home_page.load_complete();

            String result_PageTitle = home_page.getPageTitle();

            Assert.That((expected_title.Contains(result_PageTitle)));

        }

        [Given(@"Digito o termo de pesquisa: (.*)")]
        public void GivenDigitoOTermoDePesquisa(string word)
        {
            
            home_page.test_search(word);
            result_page = new ResultPage(driver);

        }

        [Given(@"Resultados da busca para (.*) deve aparecer e acessar o primeiro resultado")]
        public void GivenResultadosDaBuscaParaDeveAparecerEAcessarOPrimeiroResultado(string name)
        {
           
            String expected_title = $"{name} - Pesquisa Google";
            String result_PageTitle = result_page.getPageTitle();

            result_page.load_complete();

            Assert.That((expected_title.Contains(result_PageTitle)));

            target_page = result_page.click_search_results();
            target_page.load_complete();
           
        }

        [Then(@"Compare o (.*) e feche")]
        public void ThenCompareOEFeche(string title)
        {
            
            Assert.That((target_page.getPageTitle().Contains(title)));
            
        }
      

    }
    }

