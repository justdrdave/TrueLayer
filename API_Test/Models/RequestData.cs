using System;

namespace TrueLayer_API_Test.API_Test.Models
{
    public class RequestData
    {
        public string requestContext { get; set; }
        public string requestVerificationToken { get; set; }
        public string requestVerificationCookie { get; set; }
        public string truRatingApplicationCookie { get; set; }
        public string accessToken { get; set; }

       
        public string getPositionBaseURL() {
            return "https://api.wheretheiss.at/v1/satellites/ID/positions";
        }

        public string getTlesBaseURL() {

            return "https://api.wheretheiss.at/v1/satellites/ID/tles";
        }
    }
}