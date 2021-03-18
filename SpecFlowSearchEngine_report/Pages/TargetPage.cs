using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;


namespace SpecFlowSearchEngine_report.Pages
{
    public class TargetPage
    {
        private IWebDriver driver;
        Int32 timeout = 10000;
        private string url;

        public TargetPage(IWebDriver driver, string url)
        {
            this.driver = driver;
            this.url = url;
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

    }
}

