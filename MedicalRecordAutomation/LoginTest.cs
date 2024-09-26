using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomsonReuters.MedicalRecordAutomation.Base;
using ThomsonReuters.MedicalRecordAutomation.Utilities;

namespace ThomsonReuters.MedicalRecordAutomation
{
    public class LoginTest : AutomationWrapper
    {
        

        [Test]
        [TestCaseSource(typeof(DataSource),nameof(DataSource.ValidLoginData))]
        public void ValidLoginTest(string username, string password, string expectedValue) 
        {
            driver.FindElement(By.Id("authUser")).SendKeys(username);

            //enter password as pass
            driver.FindElement(By.Id("clearPass")).SendKeys(password);

            //click on login
            driver.FindElement(By.Id("login-button")).Click();

            //assert the title
            string actualTitle = driver.Title;
            Assert.That(actualTitle,Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase("saul", "saul1234", "Invalid username or password")]
        public void invalidLoginTest(string userName, string password, string expectedError)
        {
            driver.FindElement(By.Id("authUser")).SendKeys(userName);
            driver.FindElement(By.CssSelector("#clearPass")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();

            string Actualerror = driver.FindElement(By.XPath("//p[contains(text(),'Invalid user')]")).Text;
            //Assert.That(Actualerror, Is.EqualTo(expectedError));
            Assert.That(Actualerror.Contains(expectedError)); //output will be true or false


        }
    }
}
