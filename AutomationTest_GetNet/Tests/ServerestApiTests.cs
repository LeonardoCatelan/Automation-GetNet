using NUnit.Framework;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using AutomationTest_GetNet.RESTRequests;
using Newtonsoft.Json.Linq;

namespace Automation_GetNet.Tests
{
    [TestFixture]
    public class ServerestApiTests
    {
        [Test]
        public void RegistrationTest()
        {
            try
            {
                string url = "https://serverest.dev/usuarios";
                string name = "Fulano da Silva";
                string email = "leocatelan" + DateTime.Now.ToString("ddMMyyHHmmssff") + "@gmail.com"; //A "random" email to be used in every execution
                string password = "teste";
                string administrador = "true"; //Boolean but the request ask for a string

                var data = new
                {
                    nome = name,
                    email = email,
                    password = password,
                    administrador = administrador
                };

                string jsonData = JsonConvert.SerializeObject(data);
                HttpResponseMessage response = WebRequest.Post(url, jsonData);
                Assert.AreEqual((int)response.StatusCode, 201);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void ConsultTest()
        {
            try 
            { 
                string url = "https://serverest.dev/usuarios";

                HttpResponseMessage response = WebRequest.Get(url);
                Assert.AreEqual((int)response.StatusCode, 200);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void ConsultTestById()
        {
            try
            {
                int expectedBehaviour = 200; //Expected status code
                string expectedEmail = "leocatelan2212115522525@gmail.com"; //Expected email

                string id = "zgT2LfvaQzBu2OVs";
                string url = "https://serverest.dev/usuarios";
                string concatUrl = $"{url}/{id}";

                HttpResponseMessage response = WebRequest.Get(concatUrl);
                string body = response.Content.ReadAsStringAsync().Result;

                Assert.AreEqual((int)response.StatusCode, expectedBehaviour); //First validating if the status code is the expected

                dynamic parsedBody = JObject.Parse(body);
                string email = parsedBody.email;

                Assert.AreEqual(email, expectedEmail); //Then, validating if the e-mail we get from the request is the same that we want
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
