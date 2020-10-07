using System;
using _03_BadgesClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_BadgesTest
{
    [TestClass]
    public class BadgesRepoTest
    {
        private BadgesRepo _repo;
        private Badges _badges;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgesRepo();
            _badges = new Badges();
        }
        [TestMethod]
        public void AddABadge()
        {
            //Act
            bool addResult = _repo.AddBadgeToDictionary(_badges);

            //Assert
            Assert.IsTrue(addResult);
        }
    }
}
