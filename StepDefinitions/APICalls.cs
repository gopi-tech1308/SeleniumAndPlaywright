using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using ReqnrollTests;
using Selenium_PlaywrightTest.APICommonMethods;
using Selenium_PlaywrightTest.CommonMethods;

namespace Selenium_PlaywrightTest.StepDefinitions
{
    
    [Binding]
    public class APICallsSteps
    {
        APIMethods AP=new APIMethods();
       

        [Given(@"I do POST to Create a Auth Token")]
        public void IDoPostToCreateAAuthToken()
        {
            AP.POSTAuthToken();

        }
        [Then(@"I will get all the bookingIDS")]
        public void IWillGetAllTheBookingIDs()
        {
            AP.GetBookingIds();
        }
        [Then(@"I will get BookingID by Name")]
        public void IWillGetBookingIDByName()
        {
            AP.GetBookingIDByName();
        }
    }
}
