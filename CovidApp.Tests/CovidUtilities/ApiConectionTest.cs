using CovidDTO.ApiResponse;
using CovidUtilities.ApiConection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CovidApp.Tests.CovidUtilities
{
    [TestClass]
    public class ApiConectionTest
    {
        private readonly string apiUrl = "https://covid-19-statistics.p.rapidapi.com";
        private List<KeyValuePair<string, string>> lstHeader = new List<KeyValuePair<string, string>>();
        [TestMethod]
        public void testApiGetResult()
        {
            lstHeader.Add(new KeyValuePair<string, string>("x-rapidapi-key", "6f6130b1a9msh58a799a321e192cp1ae581jsnbf1c78702cc0"));
            lstHeader.Add(new KeyValuePair<string, string>("x-rapidapi-host", "covid-19-statistics.p.rapidapi.com"));
            lstHeader.Add(new KeyValuePair<string, string>("useQueryString", "true"));
            dtoApiResponse response = new Api(apiUrl,lstHeader).executeGet("regions");
            Assert.IsNotNull(response);
        }
        [TestMethod]
        public void testApiGetCode200()
        {
            lstHeader.Add(new KeyValuePair<string, string>("x-rapidapi-key", "6f6130b1a9msh58a799a321e192cp1ae581jsnbf1c78702cc0"));
            lstHeader.Add(new KeyValuePair<string, string>("x-rapidapi-host", "covid-19-statistics.p.rapidapi.com"));
            lstHeader.Add(new KeyValuePair<string, string>("useQueryString", "true"));
            dtoApiResponse response = new Api(apiUrl, lstHeader).executeGet("regions");
            Assert.AreEqual(200, response.HttpStatusCode);
        }
        [TestMethod]
        public void testApiGetCode404()
        {
            lstHeader.Add(new KeyValuePair<string, string>("x-rapidapi-key", "6f6130b1a9msh58a799a321e192cp1ae581jsnbf1c78702cc0"));
            lstHeader.Add(new KeyValuePair<string, string>("x-rapidapi-host", "covid-19-statistics.p.rapidapi.com"));
            lstHeader.Add(new KeyValuePair<string, string>("useQueryString", "true"));
            dtoApiResponse response = new Api(apiUrl+"/bad", lstHeader).executeGet("regions");
            Assert.AreEqual(404, response.HttpStatusCode);
        }
        [TestMethod]
        public void testApiGetHeaderError()
        {
            dtoApiResponse response = new Api(apiUrl, lstHeader).executeGet("regions");
            Assert.AreEqual(401, response.HttpStatusCode);
        }
    }
}
