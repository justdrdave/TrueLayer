using System.Collections.Generic;

namespace TrueLayer_API_Test.API_Test.Models
{
    public class ResponseData
    {
        public int status { get; set; }
        public string body { get; set; }
        public Dictionary<string, string> header = new Dictionary<string, string>();
    }
}