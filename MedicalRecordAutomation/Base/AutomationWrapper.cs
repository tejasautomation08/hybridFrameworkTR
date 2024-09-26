using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomsonReuters.MedicalRecordAutomation.Base
{
    public class AutomationWrapper
    {
        protected IWebDriver driver;

        [SetUp]
        public void BeforeTestMethod()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Navigate().GoToUrl("https://demo.openemr.io/b/openemr/interface/login/login.php?site=default");
           // driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [TearDown]
        public void AfterTestMethod()
        {
            driver.Dispose();
        }
    }
}
