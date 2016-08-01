using RestSharp;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NP6Api
{
    /// <summary>
    /// Class for manage request to the API
    /// </summary>
    public class Connection
    {
        public Connection(string xKey, string url)
        {
            _url = url;
            _xKey = xKey;
        }

        private string _url;
        private readonly string _xKey;

        /// <summary>
        /// Make a request to the route, specifying method, data and if it's a import
        /// </summary>
        /// <param name="route">The route URL</param>
        /// <param name="method">The method to use</param>
        /// <param name="data">Optional. A model or json to send. null by default</param>
        /// <param name="import">Optional. flag to specify if it's a import. false by default</param>
        /// <returns>Return NResponse with StatusCode and Body</returns>
        public NResponse Request(string route, Method method, dynamic data = null, bool import = false)
        {
            var client = new RestClient(_url + route);

            var request = new RestRequest(method) { Timeout = 10000 };

            if (route.IndexOf("imports") != -1)
            {
                request.AddHeader("Accept", "application/vnd.mperf.v8.import.v1+json");                
            }

            if (import)
            {
                if (method != Method.GET && method != Method.DELETE)
                {
                    request.AddHeader("Content-Disposition", "form-data; filename=" + data.fileName);
                    request.AddFile("data", data.filePath);
                }
            }
            else
            {
                if (method != Method.GET && data != null)
                {
                    request.RequestFormat = DataFormat.Json;
                    request.JsonSerializer = NewtonsoftJsonSerializer.Default;
                    request.AddBody(data);
                }
            }

            request.AddHeader("X-Key", _xKey);
            var response = client.Execute(request);

            NResponse ret = new NResponse();
            ret.StatusCode = response.StatusCode;
            ret.Body = (JToken)JsonConvert.DeserializeObject(response.Content);

            return ret;
        }
    }

    public class NResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public JToken Body { get; set; }
    }
}