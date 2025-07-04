using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit;
using NUnit.Compatibility;
using NUnit.Framework;
using Reqnroll;
using Selenium_PlaywrightTest.Hooks;
using UIConfig;
using System.IO.IsolatedStorage;
using OpenQA.Selenium.Support.UI;
using Microsoft.Playwright;
using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using System.Xml;



namespace Selenium_PlaywrightTest.CommonMethods
{
    public class UIMethods
    {
        private IWebDriver driver = Hooks.Hooks.driver;

        public void Login()
        {

            driver.Navigate().GoToUrl(UIConfig.Configs.URL);
            Assert.That(UIConfig.Configs.URL, Is.EqualTo(driver.Url), "URL not redirected to Given URL");
            driver.FindElement(By.XPath(UIConfig.Configs.PreSignInBtn)).Click();
            driver.FindElement(By.XPath(UIConfig.Configs.usernameXpath)).SendKeys("gajala@dongahook.com");
            driver.FindElement(By.XPath(UIConfig.Configs.passwordXpath)).SendKeys("Secret_Gajala");
            try
            {
                driver.FindElement(By.XPath(UIConfig.Configs.LgnBtnXpath)).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                wait.Until(d => d.Url == UIConfig.Configs.PostLoginURL);
                Assert.That(driver.Url, Is.EqualTo(UIConfig.Configs.PostLoginURL), "User is redirected correctly !");

            }
            catch
            {
                throw new Exception("Please check the entered Credentials");

            }
         
        }
        public void ScrollDown()
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 1300);");

        }
        public void HoverAndAddTocart()
        {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(UIConfig.Configs.SizeXpath))).Click();
            
                WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(UIConfig.Configs.ColorXpath))).Click();
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Actions actions = new Actions(driver);
                IWebElement FirstProduct = driver.FindElement(By.XPath(UIConfig.Configs.HoverFirstProdXpath));
                actions.MoveToElement(FirstProduct).Perform();
                driver.FindElement(By.XPath(UIConfig.Configs.AddcartBtnXpath)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);


        }
        public void RemoveItemFromCart()
        {
           
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(UIConfig.Configs.CartXpath))).Click();
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait2.Until(ExpectedConditions.ElementIsVisible(By.XPath(UIConfig.Configs.DeleteXpath))).Click();
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait3.Until(ExpectedConditions.ElementIsVisible(By.XPath(UIConfig.Configs.DeleteConfirmOkXpath))).Click();
            
            

            try
            {
                driver.FindElement(By.XPath(UIConfig.Configs.CartXpath)).Click();
                WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait4.Until(d => d.FindElement(By.XPath(UIConfig.Configs.CartCountXpath)).Enabled);
                Console.WriteLine("cart is Empty");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Cart is not empty"+ex.Message);
            }
        }
        public void Logout()
        {
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(UIConfig.Configs.NavBarXpath))).Click();
           
            
            try
            {
                driver.FindElement(By.XPath(UIConfig.Configs.SignoutXpath)).Click();
                WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait2.Until(d => d.Url == UIConfig.Configs.LogoutURL);
                Assert.That(driver.Url, Is.EqualTo(UIConfig.Configs.LogoutURL), "Logged out Successfully");

            }
            catch
            {
                throw new Exception("Failed to Logout");
            }
        }
    }
}
