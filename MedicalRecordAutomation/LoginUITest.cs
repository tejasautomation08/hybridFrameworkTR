﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomsonReuters.MedicalRecordAutomation.Base;

namespace ThomsonReuters.MedicalRecordAutomation
{
    /// <summary>
    /// Login UI Test Cases
    /// </summary>
    public class LoginUITest : AutomationWrapper
    {
        [Test]
        public void TitleTest()
        {
            string actualTitle = driver.Title;
            Assert.That(actualTitle, Is.EqualTo("OpenEMR Login"));
        }

        [Test]
        public void ApplicationDescriptionTest()
        {
            //Assert the text --> "The most popular open-source Electronic Health Record and Medical Practice Management solution."
            string actualDescription = driver.FindElement(By.XPath("//p[contains(text(),'most')]")).Text;
            Assert.That(actualDescription, Is.EqualTo("The most popular open-source Electronic Health Record and Medical Practice Management solution."));
        }
    }
}
