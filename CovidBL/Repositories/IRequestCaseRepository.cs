using CovidDTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidBL.Repositories
{
    public interface IRequestCaseRepository
    {
        List<dtoReport> GetCases(string region = "", int limit = 0);
    }
}
