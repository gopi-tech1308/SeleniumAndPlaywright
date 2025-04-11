using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using Microsoft.Playwright;
using OpenQA.Selenium;
using RestSharp;
using Newtonsoft.Json.Linq;
namespace Selenium_PlaywrightTest
{
    public class Tests
    {

        [Test]
        public void SeleniumTest()
        {
            //WebDriver driver = new ChromeDriver();
            WebDriver driver = new EdgeDriver();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            driver.Navigate().GoToUrl("https://www.youtube.com/");
            IWebElement SearchBar = driver.FindElement(By.XPath("//div[contains(@class,'ytSearchboxComponentInputBox ytSearchboxComponentInputBoxDark')]//form//input[contains(@name,'search_query')]"));

            SearchBar.Click();
            SearchBar.SendKeys("SVSC");
            SearchBar.SendKeys(Keys.Enter);
            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]
      public async Task PlaywrightTest()
        {
            
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false});
           
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync("https://www.youtube.com/");
            await page.ClickAsync("//div[contains(@class,'ytSearchboxComponentInputBox')]//form//input[contains(@name,'search_query')]");
            await page.FillAsync("//div[contains(@class,'ytSearchboxComponentInputBox')]//form//input[contains(@name,'search_query')]", "SVSC");
            await page.Keyboard.PressAsync("Enter");
            await page.WaitForTimeoutAsync(9000);
            await browser.CloseAsync();
            Console.WriteLine("Browser Closed");


        }
        [Test]
        public void GetJSON()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("/posts/2", Method.Get);
            RestResponse response = client.Execute(request);
            string jsonstring = response.Content;
            JObject json = JObject.Parse(jsonstring);
            if ((int)json["id"] == 2 & (string)json["title"]== "qui ")
            {
                Console.WriteLine("Success");

            }
            else
            {
                Assert.Fail("Expected Results to be qui But found " + (string)json["title"]);
            }
            


            
        }
    }
}