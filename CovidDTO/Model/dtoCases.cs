using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidDTO.Model
{
    public class dtoCases
    {
        public DateTime date { get; set; }
        public long confirmed { get; set; }
        public long deaths { get; set; }
        public int recovered { get; set; }
        public int confirmed_diff { get; set; }
        public int deaths_diff { get; set; }
        public int recovered_diff { get; set; }
        public DateTime last_update { get; set; }
        public long active { get; set; }
        public int active_diff { get; set; }
        public decimal fatality_rate { get; set; }
        public dtoRegion region { get; set; }
    }
}
