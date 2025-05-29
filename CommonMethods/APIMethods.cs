using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using OpenQA.Selenium;
using APIConfig;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;


namespace Selenium_PlaywrightTest.APICommonMethods
{
    public class APIMethods
    {
        public void POSTAuthToken()
        {
            var request = new RestRequest(APIConfig.Configs.AUTHResource, Method.Post);
            var client = new RestClient(APIConfig.Configs.BaseURL);
            request.AddHeader("Content-Type", "application/json");
            var body = File.ReadAllText(@"C:\Users\gopik\Downloads\postpayload.txt");
            request.AddJsonBody(body);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);


        }
       public void GetBookingIds()
        {
            var request = new RestRequest(APIConfig.Configs.BookingResource, Method.Get);
            var client = new RestClient(APIConfig.Configs.BaseURL);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            RestResponse response = client.Execute(request);
            File.WriteAllText(@"C:\Users\gopik\Downloads\BookingIDs.json", response.Content);
        }
        public void GetBookingIDByName()
        {
            var request = new RestRequest(APIConfig.Configs.BookingResource, Method.Get);
            var client = new RestClient(APIConfig.Configs.BaseURL);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddParameter("firstname", "sally");
            request.AddParameter("lastname", "brown");
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);


        }
        public void CreateBooking()
        {
            var request = new RestRequest(APIConfig.Configs.BookingResource, Method.Post);
            var client = new RestClient(APIConfig.Configs.BaseURL);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            var payload = File.ReadAllText(@"C:\Users\gopik\Downloads\payload.txt");
            request.AddJsonBody(payload);
            RestResponse response = client.Execute(request);
            File.WriteAllText(@"C:\Users\gopik\Downloads\CreatedBooking.txt", response.Content);

        }
        public void UpdateBooking()
        {
            var request = new RestRequest(APIConfig.Configs.UpdateBookingResource, Method.Put);
            var client = new RestClient(APIConfig.Configs.BaseURL);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Cookie", "9e396b27748f342");
            request.AddParameter("id", 1);
            var payload = File.ReadAllText(@"C:\Users\gopik\Downloads\UpdateBooking.txt");
            request.AddJsonBody(payload);
            RestResponse response = client.Execute(request);
            File.WriteAllText(@"C:\Users\gopik\Downloads\UpdatedBookingDetails.txt", response.Content);
            Console.WriteLine(response.Content);


        }

    }
}
