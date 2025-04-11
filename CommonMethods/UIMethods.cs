﻿using System;
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
            //Actions actions = new Actions(driver);
            //actions.SendKeys(Keys.PageDown).Perform();

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
    }
}
