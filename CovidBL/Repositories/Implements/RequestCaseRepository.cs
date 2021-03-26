using CovidDTO.ApiResponse;
using CovidDTO.Model;
using CovidUtilities.ApiConection;
using CovidUtilities.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidBL.Repositories.Implements
{
    public class RequestCaseRepository : IRequestCaseRepository
    {
        private readonly ConnectionServices connection = new ConnectionServices();
        public List<dtoReport> GetCases(string region = "", int limit = 0)
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrEmpty(region))
            {
                parameters.Add(new KeyValuePair<string, string>("iso", region));
            }
            dtoApiResponse response = new Api(connection.CovidServiceUrl, connection.CovidServiceHeaders).executeGet("reports", parameters);
            if (response.HttpStatusCode != 200)
                throw new ConnectionApiException("Error al consumir servicio", response.HttpStatusCode);
            else
            {
                dtoJsonResultCases cases = JsonConvert.DeserializeObject<dtoJsonResultCases>(response.Response);
                List<dtoReport> result = new List<dtoReport>();
                if (string.IsNullOrEmpty(region))
                {
                    result = cases.data.GroupBy(g => g.region.iso).Select(l => new dtoReport
                    {
                        Cases = l.Sum(s => s.confirmed),
                        Deaths = l.Sum(d => d.deaths),
                        isRegion = false,
                        Province = "",
                        Region = l.First().region.name
                    }).ToList();
                }
                else
                {
                    result = cases.data.GroupBy(g => g.region.province).Select(l => new dtoReport
                    {
                        Cases = l.Sum(s => s.confirmed),
                        Deaths = l.Sum(d => d.deaths),
                        isRegion = true,
                        Province = l.First().region.province,
                        Region = l.First().region.name
                    }).ToList();
                }
                result = result.OrderByDescending(o => o.Cases).Take((limit > 0 ? limit : result.Count())).ToList();
                return result;
            }
        }
    }
}
