using CovidBL.Repositories;
using CovidBL.Repositories.Implements;
using CovidDTO.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace CovidApp.Controllers
{
    public class HomeController : Controller
    {
        private IRequestCaseRepository repositoryCase;
        private IRequestRegionRepository repositoryRegion;
        public HomeController()
        {
            if (repositoryCase == null)
                repositoryCase = new RequestCaseRepository();
            if (repositoryRegion == null)
                repositoryRegion = new RequestRegionRepository();
        }
        public ActionResult Index()
        {
            ViewBag.Regions = repositoryRegion.getRegions().data;
            List<dtoReport> model = new List<dtoReport>();//repositoryCase.GetCases(limit: 10);
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public PartialViewResult Filter(string region)
        {
            List<dtoReport> model = repositoryCase.GetCases(region, 10);
            return PartialView("partial/RegionDetail", model);
        }

        public ActionResult Export(string type, string region = "")
        {
            List<dtoReport> model = repositoryCase.GetCases(region, 10);
            string title = string.IsNullOrEmpty(region) ? "COVID regions." + type.ToLower() : "COVID " + region + "." + type.ToLower();
            byte[] fileBuffer;
            string fileContain = "";
            fileContain = JsonConvert.SerializeObject(model, Formatting.Indented);
            if (type.ToLower() == "xml")
            {
                fileContain = JsonConvert.DeserializeXmlNode("{Regions:" + fileContain + "}", "Root").OuterXml;
            }
            else if (type.ToLower() == "csv")
            {
                DataTable dataTable = (DataTable)JsonConvert.DeserializeObject(fileContain, (typeof(DataTable)));
                var lines = new List<string>();
                string[] columnNames = dataTable.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName).
                                                  ToArray();
                var header = string.Join(",", columnNames);
                lines.Add(header);
                var valueLines = dataTable.AsEnumerable()
                                   .Select(row => string.Join(",", row.ItemArray));
                lines.AddRange(valueLines);
                fileContain = string.Join(Environment.NewLine, lines);
            }
            using (var ms = new MemoryStream())
            {
                TextWriter tw = new StreamWriter(ms);
                tw.Write(fileContain);
                tw.Flush();
                ms.Position = 0;
                fileBuffer = ms.ToArray();
            }
            Response.AppendCookie(new HttpCookie("fileDownloadToken", "true"));
            return File(fileBuffer, "application/octet-stream", title);
        }
    }

}
