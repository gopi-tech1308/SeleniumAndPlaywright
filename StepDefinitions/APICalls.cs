using Reqnroll;
using Selenium_PlaywrightTest.APICommonMethods;


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
        [Then(@"I will Create a Booking")]
        public void IWillCreateABooking()
        {
            AP.CreateBooking();
        }
        [Then(@"I will Update a Boooking")]
        public void IWillUpdateABooking()
        {
            AP.UpdateBooking();
        }
    }
}
