using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;

namespace DojoInterfaceApplication.Tests
{
    public class TesteBase
    {
        public IWebDriver driver;
        public string baseURL;
        public StringBuilder verificationErrors;

        [TestInitialize]
        public void SetupTest()
        {
            driver = new InternetExplorerDriver();
            baseURL = "http://localhost:58034";
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
    }
}
