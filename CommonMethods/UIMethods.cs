
using OpenQA.Selenium;

using UIConfig;

using OpenQA.Selenium.Support.UI;

using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;




namespace Selenium_PlaywrightTest.CommonMethods
{
    public class UIMethods
    {
        private static IWebDriver driver = Hooks.Hooks.driver;
        Actions actions = new Actions(driver);

        public void Login()
        {

            driver.Navigate().GoToUrl(Configs.URL);
            Assert.That(Configs.URL, Is.EqualTo(driver.Url), "URL not redirected to Given URL");
            driver.FindElement(By.XPath(Configs.PreSignInBtn)).Click();
            driver.FindElement(By.XPath(Configs.usernameXpath)).SendKeys(Configs.username);
            driver.FindElement(By.XPath(Configs.passwordXpath)).SendKeys(Configs.password);
            try
            {
                driver.FindElement(By.XPath(Configs.LgnBtnXpath)).Click();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                wait.Until(d => d.Url == Configs.PostLoginURL);
                Assert.That(driver.Url, Is.EqualTo(Configs.PostLoginURL), "User is redirected correctly !");

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
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Configs.SizeXpath))).Click();
            
                WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Configs.ColorXpath))).Click();
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                IWebElement FirstProduct = driver.FindElement(By.XPath(Configs.HoverFirstProdXpath));
                actions.MoveToElement(FirstProduct).Perform();
            
                driver.FindElement(By.XPath(Configs.AddcartBtnXpath)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);


        }
        public void RemoveItemFromCart()
        {
           
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Configs.CartXpath))).Click();
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait2.Until(ExpectedConditions.ElementIsVisible(By.XPath(Configs.DeleteXpath))).Click();
            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait3.Until(ExpectedConditions.ElementIsVisible(By.XPath(Configs.DeleteConfirmOkXpath))).Click();
            
            

            try
            {
                driver.FindElement(By.XPath(Configs.CartXpath)).Click();
                WebDriverWait wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait4.Until(d => d.FindElement(By.XPath(Configs.CartCountXpath)).Enabled);
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
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Configs.NavBarXpath))).Click();
           
            
            try
            {
                driver.FindElement(By.XPath(Configs.SignoutXpath)).Click();
                WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait2.Until(d => d.Url == Configs.LogoutURL);
                Assert.That(driver.Url, Is.EqualTo(Configs.LogoutURL), "Logged out Successfully");

            }
            catch
            {
                throw new Exception("Failed to Logout");
            }
        }
    }
}
