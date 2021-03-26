using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidBL
{
    public class ConnectionServices
    {
        public string CovidServiceUrl
        {
            get { return ConfigurationManager.ConnectionStrings["CovidRapidapi"].ConnectionString; }
        }
        public List<KeyValuePair<string,string>> CovidServiceHeaders { get; }
        public ConnectionServices()
        {
            CovidServiceHeaders = new List<KeyValuePair<string, string>>();
            CovidServiceHeaders.Add(new KeyValuePair<string, string>("x-rapidapi-key", "6f6130b1a9msh58a799a321e192cp1ae581jsnbf1c78702cc0"));
            CovidServiceHeaders.Add(new KeyValuePair<string, string>("x-rapidapi-host", "covid-19-statistics.p.rapidapi.com"));
            CovidServiceHeaders.Add(new KeyValuePair<string, string>("useQueryString", "true"));
        }
    }
}
