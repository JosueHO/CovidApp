using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidDTO.Model
{
    public class dtoRegion
    {
        public string iso { get; set; }
        public string name { get; set; }
        public string province { get; set; }
        public decimal? lat { get; set; }
        public decimal? @long { get; set; }
        public List<dtoCity> cities { get; set; }
    }
}
