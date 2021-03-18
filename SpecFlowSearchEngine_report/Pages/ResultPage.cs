using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
//using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.PageObjects;

namespace SpecFlowSearchEngine_report.Pages
{
    public class ResultPage
    {
        private IWebDriver driver;
        Int32 timeout = 10000;

        public ResultPage (IWebDriver driver)
        {
            this.driver = driver;
            //PageFactory.InitElements(driver, this);
        }

        public String getPageTitle()
        {
            return driver.Title;
        }

        public void load_complete()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            // Wait for the page to load
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        //[FindsBy(How = How.XPath, Using = "//*[@id='rso']/div/div/div/div/a")]
        //[CacheLookup]
        //private IWebElement elem_first_result;

        public TargetPage click_search_results()
        {
            IWebElement elem_first_result = driver.FindElement(By.XPath("//*[@id='rso']/div/div/div/div/a"));

            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            var url = elem_first_result.GetAttribute("href");

            elem_first_result.Click();

            async_delay();

            return new TargetPage(driver,url);
        }

        async void async_delay()
        {
            await Task.Delay(50);
        }

    }
}
