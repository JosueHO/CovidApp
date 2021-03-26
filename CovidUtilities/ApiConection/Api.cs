using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CovidDTO.ApiResponse;
using RestSharp;

namespace CovidUtilities.ApiConection
{
    public class Api
    {
        private string apiUrl;
        private List<KeyValuePair<string, string>> headerList;
        public Api(string _apiUrl, List<KeyValuePair<string, string>> _headerList)
        {
            apiUrl = _apiUrl;
            headerList = _headerList;
        }
        public dtoApiResponse executeGet(string method, List<KeyValuePair<string, string>> parameters = null)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
            RestClient client = new RestClient(apiUrl);
            RestRequest request = new RestRequest(method, Method.GET);
            if (headerList != null)
            {
                foreach (var header in headerList)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    request.AddParameter(parameter.Key, parameter.Value);
                }
            }
            IRestResponse response = client.Execute(request);
            HttpStatusCode statusCode = response.StatusCode;
            return new dtoApiResponse
            {
                HttpStatusCode = (int)statusCode,
                Response = response.Content.ToString()
            };
        }

    }
}
