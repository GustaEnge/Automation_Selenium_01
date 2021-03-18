using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSearchEngine_report.Pages
{
    public class HomePage
    {
        String test_url = "https://www.google.com";

        private IWebDriver driver;
        private WebDriverWait wait;
        Int32 timeout = 10000;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //PageFactory.InitElements(driver, this);
        }

        //[FindsBy(How = How.Name, Using = "q")]
        //[CacheLookup]
        //private IWebElement elem_search_text;

        public void goToPage()
        {
            driver.Navigate().GoToUrl(test_url);

        }

        // Returns the Page Title
        public String getPageTitle()
        {
            return driver.Title;
        }

        public ResultPage test_search(string input_search)
        {
            IWebElement elem_search_text = driver.FindElement(By.Name("q"));

            elem_search_text.SendKeys(input_search);
            elem_search_text.Submit();
            return new ResultPage(driver);
        }

        public void load_complete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

    }
}