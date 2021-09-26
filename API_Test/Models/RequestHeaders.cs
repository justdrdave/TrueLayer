using System.Collections.Generic;

namespace TrueLayer_API_Test.API_Test.Models
{
    public class RequestHeaders
    {
             public Dictionary<string, string> getValidHeader()
        {
            Dictionary<string, string> header = new  Dictionary<string, string>();
            header["User-Agent"] = "API-Test";
            //header.Add("Connection", "keep-alive");
            header.Add("Accept-Language", "en-US,en;q=0.9");
            header.Add("Content-Type", "application/json;charset=UTF-8");
            header.Add("Accept-Encoding", "gzip, deflate, br");
            return header;
        }
    }
}