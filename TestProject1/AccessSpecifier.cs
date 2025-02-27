using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class AccessSpecifier:OrangeHRMLoginPage
    {
        private IWebDriver driver;
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            //loginPage = new OrangeHRMLoginPage();
        }

        [Test]
        public void AccessSpecifier_Inheritance_AdvanceDotnet_Task9()
        {
            PerformLogin(driver, "Admin", "admin123");
            Assert.IsTrue(IsHomePageDisplayed(driver), "Home page should be displayed after login");
            Console.WriteLine(protectedMessage);
                Console.WriteLine(internalMessage);
        }
        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        }
}
