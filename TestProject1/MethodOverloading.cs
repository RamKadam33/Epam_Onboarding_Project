using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework.Internal;
using log4net;
using log4net.Config;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;

namespace TestProject1
{
    public class MethodOverloading
    {
        private static IWebDriver driver;
        private WebDriverWait wait;

        private const string URL = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        private const string USERNAME = "Admin";
        private const string PASSWORD = "admin123";
     
        
        [SetUp]
        public void Setup()
        {
            
            
            driver = new ChromeDriver();
            
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(URL);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }


        public void Login(string username, string password)
        {
           
            IWebElement usernameField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='username']")));
            usernameField.SendKeys(username);
           
            IWebElement passwordField = driver.FindElement(By.XPath("//input[@name='password']"));
            passwordField.SendKeys(password);

            IWebElement loginButton = driver.FindElement(By.XPath("//button[@type='submit']"));
            loginButton.Click();
        }

        
        public void Login(string username, string password, bool printTitle)
        {
            if (printTitle) Console.WriteLine($"Page title is: {driver.Title}");
            Login(username, password);
            if (printTitle) Console.WriteLine($"Page title is: {driver.Title}");                     
        }

        [Test]
        public void TestLoginWithUsernameAndPassword()
        {
            Login(USERNAME, PASSWORD);
            Console.WriteLine($"url is: {driver.Url}");
            Assert.IsTrue(driver.Url.Contains("dashboard"));
        }

        [Test]
        public void TestLoginWithPrintTitle()
        {
            Login(USERNAME,PASSWORD, true);
            Console.WriteLine($"url is: {driver.Url}");
            Assert.IsTrue(driver.Url.Contains("dashboard"));
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }

}

