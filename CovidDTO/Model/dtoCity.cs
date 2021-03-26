using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidDTO.Model
{
    public class dtoCity
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public int? fips { get; set; }
        public decimal? lat { get; set; }
        public decimal? @long { get; set; }
        public long confirmed { get; set; }
        public long deaths { get; set; }
        public int confirmed_diff { get; set; }
        public int deaths_diff { get; set; }
        public DateTime last_update { get; set; }
    }
}
