using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using RestSharp;
using NUnit.Framework;

namespace GoogleSearch.Steps
{
    [Binding]
    class Post
    {

        RestResponse response;
        [Given(@"User make a post call")]
        public void GivenUserMakeAPostCall()
        {
            RestClient restClient = new RestClient("https://reqres.in/");

            JObject obj = new JObject();
            obj.Add("email", "tester.123@abc.in");
            obj.Add("password", "tester");

            RestRequest req = new RestRequest("/api/register", Method.Post);
            req.AddParameter("application/json", obj, ParameterType.RequestBody);

            response = restClient.Execute(req);
            
        }

        [Given(@"Verify the status code")]
        public void GivenVerifyTheStatusCode()
        {
            var status = response.StatusCode;
            var code = (int)status;

            Assert.AreEqual(400, code);
        }


    }
}
