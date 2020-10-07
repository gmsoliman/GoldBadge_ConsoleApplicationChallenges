using System;
using _02_ClaimsClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimsTest
{
    [TestClass]
    public class ClaimsRepoTest
    {
        private Claims _claim;
        private ClaimsRepo _repo;
        [TestMethod]
        public void Arrange()
        {
            _repo = new ClaimsRepo();
            _claim = new Claims(4, TypeOfClaim.Car, "Wreck on I-70.", 2000.00d, DateTime, DateTime);
        }
    }
}
