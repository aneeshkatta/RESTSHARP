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
        public void OnCallingPostAPI_MultileEmployeesAdded()
        {
            List<Employees> EmpList = new List<Employees>();
            EmpList.Add(new Employees("raj", 20000));
            EmpList.Add(new Employees("ravi", 30000));
            foreach (Employees emp in EmpList)
            {
                RestRequest request = new RestRequest("/Employees", Method.Post);
                JsonObject jsonObjectbody = new JsonObject();
                jsonObjectbody.Add("name", emp.name);
                jsonObjectbody.Add("salary", emp.salary);
                request.AddParameter("application/json", jsonObjectbody, ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            }
                  
        }
    }
}