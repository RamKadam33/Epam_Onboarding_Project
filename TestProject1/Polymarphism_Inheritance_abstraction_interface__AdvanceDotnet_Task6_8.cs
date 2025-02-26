using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestFixture]  

    public class Polymarphism_Inheritance_abstraction_interface__AdvanceDotnet_Task6_8
    {
        private IWebDriver driver;
        private OrangeHRMLoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            loginPage = new OrangeHRMLoginPage();
        }

        [Test]
        public void TestSuccessfulLogin()
        {
            loginPage.PerformLogin(driver,"Admin", "admin123");
            Assert.IsTrue(loginPage.IsHomePageDisplayed(driver), "Home page should be displayed after login");
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }

}

