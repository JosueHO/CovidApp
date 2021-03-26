using CovidDTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidUtilities.ApiConection;
using CovidDTO.ApiResponse;
using Newtonsoft.Json;
using CovidUtilities.Exceptions;

namespace CovidBL.Repositories.Implements
{
    public class RequestRegionRepository : IRequestRegionRepository
    {
        private readonly ConnectionServices connection = new ConnectionServices();
        public dtoJsonResultRegions getRegions()
        {
            dtoApiResponse response = new Api(connection.CovidServiceUrl, connection.CovidServiceHeaders).executeGet("regions");

            if (response.HttpStatusCode != 200)
                throw new ConnectionApiException("Error al consumir servicio", response.HttpStatusCode);
            else
            {
                dtoJsonResultRegions regions = JsonConvert.DeserializeObject<dtoJsonResultRegions>(response.Response);
                return regions;
            }
        }
    }
}
