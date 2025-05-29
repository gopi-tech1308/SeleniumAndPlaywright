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
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 1300);");

        }
        public void HoverAndAddTocart()
        {
            
                driver.FindElement(By.XPath(UIConfig.Configs.SizeXpath)).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath(UIConfig.Configs.ColorXpath)).Click();
                Thread.Sleep(1000);
                Actions actions = new Actions(driver);
                IWebElement FirstProduct = driver.FindElement(By.XPath(UIConfig.Configs.HoverFirstProdXpath));
                actions.MoveToElement(FirstProduct).Perform();
                driver.FindElement(By.XPath(UIConfig.Configs.AddcartBtnXpath)).Click();
                Thread.Sleep(1000);
              
        }
        public void RemoveItemFromCart()
        {
            Thread.Sleep(1000);

            driver.FindElement(By.XPath(UIConfig.Configs.CartXpath)).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(UIConfig.Configs.DeleteXpath)).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(UIConfig.Configs.DeleteConfirmOkXpath)).Click();
            

            try
            {
                driver.FindElement(By.XPath(UIConfig.Configs.CartXpath)).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait.Until(d => d.FindElement(By.XPath(UIConfig.Configs.CartCountXpath)).Enabled);
                Console.WriteLine("cart is Empty");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Cart is not empty"+ex.Message);
            }
        }
        public void Logout()
        {
            driver.FindElement(By.XPath(UIConfig.Configs.NavBarXpath)).Click();
            
            try
            {
                driver.FindElement(By.XPath(UIConfig.Configs.SignoutXpath)).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait.Until(d => d.Url == UIConfig.Configs.LogoutURL);
                Assert.That(driver.Url, Is.EqualTo(UIConfig.Configs.LogoutURL), "Logged out Successfully");

            }
            catch
            {
                throw new Exception("Failed to Logout");
            }
        }
    }
}
