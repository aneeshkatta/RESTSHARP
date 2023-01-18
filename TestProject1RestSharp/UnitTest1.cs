using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text.Json.Nodes;

namespace TestProject1RestSharp
{
    [TestClass]
    public class RestSharpTestCase
    {
        RestClient client;

        [TestInitialize]
        public void SetUp()
        {
            client = new RestClient("http://localhost:4000");
        }
        private RestResponse GetEmployeeList()
        {
            //Arrange
            RestRequest request = new RestRequest("/Employees/list", Method.Get);
            //Act
            RestResponse response = client.Execute(request);
            return response;
        }
        [TestMethod]
        public void OnCallingPostAPI_Return_updateEmployee()
        {   //arrange
            RestRequest request = new RestRequest("/Employees/3", Method.Put);
            JsonObject jsonObjectbody = new JsonObject();

            jsonObjectbody.Add("name", "JAIRAM");
            jsonObjectbody.Add("salary", 600000);//salary changed
            request.AddParameter("application/json", jsonObjectbody, ParameterType.RequestBody);
            //  act
            RestResponse response = client.Execute(request);
            // assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Employees employee = JsonConvert.DeserializeObject<Employees>(response.Content);
            Assert.AreEqual("JAIRAM", employee.name);
            Assert.AreEqual(600000, employee.salary);
        }

    }
}