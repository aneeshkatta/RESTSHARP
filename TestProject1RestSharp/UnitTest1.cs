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
        public void OnCallingGetAPI_ReturnEmployeeList()
        {
            RestResponse response = GetEmployeeList();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            List<Employees> employeeList = JsonConvert.DeserializeObject<List<Employees>>(response.Content);
            Assert.AreEqual(5, employeeList.Count);
            foreach (Employees emp in employeeList)
            {
                Console.WriteLine(emp.id + "\t" + emp.name + "\t" + emp.salary);
            }
        }
        [TestMethod]
        public void OnCallingPostAPI_PostEmployeeObject()
        {
            RestRequest request = new RestRequest("/Employees", Method.Post);
            JsonObject jsonObjectbody = new JsonObject();
            jsonObjectbody.Add("name", "ramya");
            jsonObjectbody.Add("salary", 30000);
            request.AddParameter("application/json", jsonObjectbody, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Employees employee = JsonConvert.DeserializeObject<Employees>(response.Content);
            Assert.AreEqual("ramya", employee.name);
            Assert.AreEqual(30000, employee.salary);
        }
    }
}