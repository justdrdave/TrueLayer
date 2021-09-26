using TrueLayer_API_Test.API_Test.Models;
using TechTalk.SpecFlow;
using Xunit;
using Xunit.Abstractions;

namespace TrueLayer_API_Test.API_Test.Models
{
    [Binding]

    public class ApiTestSteps
    {
        private ResponseData response = new ResponseData();
        private RequestData request = new RequestData();
        private RequestHeaders headers = new RequestHeaders();
        private ExpectedResponses expected = new ExpectedResponses();
        private ApiCall apiCall = new ApiCall();

        private string body = "{}";
        private string id = "0";
        private string query = "";

        private readonly ITestOutputHelper output;

        public ApiTestSteps(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Given(@"I wish to query the (.*) position")]
        public void GivenIWishToQueryThePosition(string satellite)
        {
            // API currently only supports ISS, placeholder for when additional satellites are added
            if(satellite == "ISS"){
                this.id ="25544";
            }
        }

        [Given(@"I wish to query the (.*) tles")]
        public void GivenIWishToQueryTheTLES(string satellite)
        {
            // API currently only supports ISS, placeholder for when additional satellites are added
            if(satellite == "ISS"){
                this.id ="25544";
            }
        }

        [When(@"I submit a (.*) to the position API with (.*) parameters")]
        public void WhenISubmitARequestToThePositionAPIWithParameters(string requestType, string querystring)
        {
            this.query = querystring;
            this.apiCall.sendRequest(this.request.getPositionBaseURL().Replace("ID", this.id) + querystring, requestType, "", this.headers.getValidHeader(), this.response);
        }

        [When(@"I submit a (.*) to the tles API with (.*) format")]
        public void WhenISubmitARequestToTheTLESAPIWithParameters(string requestType, string querystring)
        {
            this.query = querystring;
            this.apiCall.sendRequest(this.request.getTlesBaseURL().Replace("ID", this.id) + querystring, requestType, "", this.headers.getValidHeader(), this.response);
        }

        [Then(@"I should get a (.*) response")]
        public void I_should_get_a_response(int status)
        {
            // Confirm you get the expected http response code
            Assert.Equal(status, this.response.status);
        }

        [Then(@"I should get the expected position data")]
        public void ThenIShouldGetTheExpectedPositionData()
        {
            //output.WriteLine(this.response.body);
            // Have hardcoded expected results based on query string, would like to create a table of expected data by timestamp and units which could be used to build the expected result for comparison
            Assert.Equal(this.expected.getExpectedPositionData(this.query), this.response.body);
        }

        [Then(@"I should get the expected tles data")]
        public void ThenIShouldGetTheExpectedTLESData()
        {
            output.WriteLine(this.response.body);
            // Have hardcoded expected results based on query string, would like to create a table of expected data by timestamp and units which could be used to build the expected result for comparison
            // As some data is dependent on the timestamp and this endpoint always uses the current timestamp will only validate the unchanging parts of the response
            foreach (var entry in this.expected.getExpectedTLESData(query)) {
                Assert.Contains(entry, this.response.body);
            }        
        }
    }
}