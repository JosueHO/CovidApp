using CovidBL.Repositories;
using CovidBL.Repositories.Implements;
using CovidDTO.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CovidApp.Tests.CovidBL.Repositories
{
    [TestClass]
    public class CaseRepositoryTest
    {
        private IRequestCaseRepository repository = new RequestCaseRepository();
        [TestMethod]
        public void TestCasesResult()
        {
            var result = repository.GetCases();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }
        [TestMethod]
        public void TestCasesResultType()
        {
            var result = repository.GetCases();
            Assert.AreEqual(Type.Equals(result.GetType(), typeof(List<dtoReport>)),true);
        }
        [TestMethod]
        public void TestCasesGlobalLimit()
        {
            int limit = 10;
            var result = repository.GetCases(limit:limit);
            Assert.IsTrue(result.Count() == limit);
        }
        [TestMethod]
        public void TestCasesRegionLength()
        {
            var region = "usa";
            var result = repository.GetCases(region:region);
            Assert.IsTrue(result.Count() > 0);
        }
        [TestMethod]
        public void TestCasesRegionLimit()
        {
            int limit = 10;
            var region = "usa";
            var result = repository.GetCases(region, limit);
            Assert.IsTrue(result.Count() == limit);
        }
        [TestMethod]
        public void TestErrorRegion()
        {
            var region = "abcde";
            var result = repository.GetCases(region:region);
            Assert.IsTrue(result.Count() == 0);
        }
    }
}
