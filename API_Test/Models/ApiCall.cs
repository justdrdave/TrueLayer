using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace TrueLayer_API_Test.API_Test.Models
{
    public class ApiCall
    {
        public void sendRequest(string url, string requestMethod, string body, Dictionary<string, string> header, ResponseData apiResponse) {

            apiResponse.header.Clear();

            Uri uri = new Uri(url);
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;

            foreach(KeyValuePair<string, string> entry in header)
            {   
                request.Headers.Add(entry.Key, entry.Value);
            }

            request.Method = requestMethod;

            Stream dataStream;

            if (requestMethod == "POST" || requestMethod == "PUT") {
                byte[] byteArray = Encoding.UTF8.GetBytes(body);
                // Get the request stream.  
                dataStream = request.GetRequestStream();
                // Write the data to the request stream.  
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.  
                dataStream.Close();
            }
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            // Get the response.
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    apiResponse.status = System.Convert.ToInt32(((HttpWebResponse)response).StatusCode);

                    for(int i=0; i < response.Headers.Count; ++i)  
                            apiResponse.header.Add(response.Headers.Keys[i], response.Headers[i]);
                    // Get the stream containing content returned by the server.  
                    // The using block ensures the stream is automatically closed.
                    using (dataStream = response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access.  
                        StreamReader reader = new StreamReader(dataStream);
                        // Read the content.  
                        string responseFromServer = reader.ReadToEnd();
                        // Display the content.  
                        apiResponse.body = responseFromServer.Replace("\r\n", "");
                    }
                    
                    // Close the response.  
                    response.Close();
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    apiResponse.status = System.Convert.ToInt32(((HttpWebResponse)response).StatusCode);

                    for(int i=0; i < response.Headers.Count; ++i)  
                            apiResponse.header.Add(response.Headers.Keys[i], response.Headers[i]);
                    // The using block ensures the stream is automatically closed.
                    using (dataStream = response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access.  
                        StreamReader reader = new StreamReader(dataStream);
                        // Read the content.  
                        string responseFromServer = reader.ReadToEnd();
                        // Display the content.  
                        apiResponse.body = responseFromServer.Replace("\r\n", "");
                    }
                    
                    // Close the response.  
                    response.Close();
                    }
            }

        }
    }
}