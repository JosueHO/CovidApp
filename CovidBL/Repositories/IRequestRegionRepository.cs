using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidDTO.Model;
namespace CovidBL.Repositories
{
    public interface IRequestRegionRepository
    {
        dtoJsonResultRegions getRegions();
    }
}
