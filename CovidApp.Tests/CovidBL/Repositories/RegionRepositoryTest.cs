using CovidBL.Repositories;
using CovidBL.Repositories.Implements;
using CovidDTO.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CovidApp.Tests.CovidBL.Repositories
{
    [TestClass]
    public class RegionRepositoryTest
    {
        private IRequestRegionRepository repository = new RequestRegionRepository();
        [TestMethod]
        public void TestRegionResult()
        {
            var result = repository.getRegions();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestRegionResultType()
        {
            var result = repository.getRegions();
            Assert.AreEqual(Type.Equals(result.GetType(), typeof(dtoJsonResultRegions)), true);
        }
    }
}
