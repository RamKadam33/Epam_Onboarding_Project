using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject1
{

    public class OrangeHRMLoginPage : LoginBase
    {
        protected string protectedMessage = "ProtectedMessage";
        internal string internalMessage = "Internal message";
          public override void EnterUsername(IWebDriver driver, string username)
        {
            string xpath = "//input[@name='username']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            driver.FindElement(By.XPath(xpath)).SendKeys(username);
        }

        public override void EnterPassword(IWebDriver driver,string password)
        {
            string xpath = "//input[@name='password']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            driver.FindElement(By.XPath(xpath)).SendKeys(password);
        }

        public override void ClickLogin(IWebDriver driver)
        {
            string xpath = "//button[@type='submit']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            driver.FindElement(By.XPath(xpath)).Click();
        }
    }

}
