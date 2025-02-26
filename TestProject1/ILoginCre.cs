using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal interface ILoginCre
    {
        void EnterUsername(IWebDriver driver,string username);
        void EnterPassword(IWebDriver driver,string password);
        void ClickLogin(IWebDriver driver);
        bool IsHomePageDisplayed(IWebDriver driver);
    }
}
