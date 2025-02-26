using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal class CustomException : Exception{
    public int ErrorCode { get; }

    public CustomException(string message, int errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }

    }

    
        internal class custom
        {
            private static IWebDriver driver;  // static
            private WebDriverWait wait;

            // final (const in C#)
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

            [Test]
            public void TestLoginAndNavigation()
            {
                try
                {

                    IWebElement usernameField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='username']")));
                    usernameField.SendKeys(USERNAME);

                    IWebElement passwordField = driver.FindElement(By.XPath("//input[@name='password']"));
                    passwordField.SendKeys(PASSWORD);

                    IWebElement loginButton = driver.FindElement(By.XPath("//button[@type='submit']"));
                    loginButton.Click();


                    IWebElement profilePicture = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//li/descendant::img[@alt='profile picture']")));
                    Assert.IsTrue(profilePicture.Displayed, "Profile picture not displayed, login failed.");

                    Console.WriteLine("Login successful!");


                    IList<IWebElement> menuItems = driver.FindElements(By.XPath("//ul[@class='oxd-main-menu']//li"));

                    
                    if (profilePicture is IWebElement)
                    {
                        throw new CustomException("Profile picture is not a valid web element.", 2045);                        
                    }
                    
                }
                catch (CustomException e)
                {
                    Console.WriteLine($"Failed: Error: {e}");

                }
                finally
                {
                    driver.Quit();
                }
            }
        
        }





}
