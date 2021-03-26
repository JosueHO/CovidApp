using CovidApp;
using CovidApp.Controllers;
using CovidDTO.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CovidApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void IndexDataTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            var model = result.Model;
            var viewbag = result.ViewBag.Regions;
            Assert.AreEqual(Type.Equals(model.GetType(), typeof(List<dtoReport>)),true);
            Assert.AreEqual(Type.Equals(viewbag.GetType(), typeof(List<dtoRegion>)), true);
        }
        [TestMethod]
        public void PartialFilterTest()
        {
            HomeController controller = new HomeController();
            const string parameter = "usa";
            PartialViewResult result = controller.Filter(parameter) as PartialViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void PartialFilterDataTest()
        {
            HomeController controller = new HomeController();
            const string parameter = "usa";
            PartialViewResult result = controller.Filter(parameter) as PartialViewResult;
            var model = result.Model;
            Assert.AreEqual(Type.Equals(model.GetType(), typeof(List<dtoReport>)), true);
        }

        [TestMethod]
        public void ExportTest()
        {
            HomeController controller = new HomeController();
            const string type = "json";
            var result = controller.Export(type);
            Assert.IsInstanceOfType(result, typeof(FileContentResult));
        }
        [TestMethod]
        public void ExportTypeReturnTest()
        {
            HomeController controller = new HomeController();
            const string type = "json";
            var result = controller.Export(type) as FileContentResult;
            Assert.AreEqual("application/octet-stream", result.ContentType);
            Assert.IsTrue(result.FileDownloadName.EndsWith(type));
        }
    }
}
