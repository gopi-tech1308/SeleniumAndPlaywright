
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace Selenium_PlaywrightTest.Hooks
{
    [Binding]
    public class Hooks
    {
        public static IWebDriver driver;

        [BeforeScenario]
        public static void Setup()
        {
            if(driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();

            }
            
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
