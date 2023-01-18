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
        public void GivenEmployeeIdOnDelete_ShouldReturnSucessStatus()
        {
            //arrange
            RestRequest request = new RestRequest("/Employees/5", Method.Delete);
            //act
            RestResponse response = client.Execute(request);
            //assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}