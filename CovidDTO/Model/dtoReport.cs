using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidDTO.Model
{
    public class dtoReport
    {
        [DisplayName("REGION")]
        public string Region { get; set; }
        [DisplayName("PROVINCE")]
        public string Province { get; set; }
        [DisplayName("CASES")]
        public long Cases { get; set; }
        [DisplayName("DEATHS")]
        public long  Deaths { get; set; }
        public bool isRegion { get; set; }
    }
}
