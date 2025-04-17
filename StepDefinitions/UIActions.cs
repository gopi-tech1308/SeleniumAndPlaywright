using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using ReqnrollTests;
using Selenium_PlaywrightTest.Hooks;
using Selenium_PlaywrightTest.CommonMethods;

namespace ReqnrollTests.StepDefinitions
{
    
   
    [Binding]
    public class UIActionsSteps
    {

        UIMethods com = new UIMethods();


        [Given(@"I Go to the website and Login")]
        public void GivenIGoToTheWebsiteAndLogin()
        {
            com.Login();

        }
        [When(@"I Scroll Down to see Items")]
        public void WhenIScrollDownToSeeItems()
        {
            com.ScrollDown();
        }
        [Then(@"I Hover on to Product and Add to Cart")]
        public void ThenIHoverOnToProductAndAddToCart()
        {
            com.HoverAndAddTocart();
        }
        [Then(@"I Remove the product from cart")]
        public void ThenIRemoveTheProductFromCart()
        {
            com.RemoveItemFromCart();
        }
        [Then(@"I Logout from website")]
        public void ThenILogoutFromWebsite()
        {
            com.Logout();
        }
    }
}
