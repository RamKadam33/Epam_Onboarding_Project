using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace TestProject1
{
    public abstract class LoginBase:ILoginCre
    {


        //private string PrivateAccessSpecifier= "PrivateAccessSpecifier";
        //protected string ProtectedAccessSpecifier= "ProtectedAccessSpecifier";
        //internal string InternalAccessSpecifier= "InternalAccessSpecifier";
        public abstract void EnterUsername(IWebDriver driver,string username);
        public abstract void EnterPassword(IWebDriver driver,string password);
        public abstract void ClickLogin(IWebDriver driver);

        public bool IsHomePageDisplayed(IWebDriver driver)
        {
            string xpath = "//li/descendant::img[@alt='profile picture']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            return driver.FindElement(By.XPath(xpath)).Displayed;
            
        }

        public void PerformLogin(IWebDriver driver,string username, string password)
        {
            EnterUsername(driver,username);
            EnterPassword(driver,password);
            ClickLogin(driver);
        }
    }
}
