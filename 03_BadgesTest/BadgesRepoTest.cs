using System;
using System.Collections.Generic;
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
            _badges = new Badges(12345, new List<string> { "A5", "A7" });
        }
        [TestMethod]
        public void AddABadge()
        {
            //Act
            bool addResult = _repo.AddBadgeToDictionary(_badges);

            //Assert
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetFullBadgeDictionary()
        {
            //Arrange
            _repo.AddBadgeToDictionary(_badges);
            
            //Act
            Dictionary<int, List<string>> newDictionary = _repo.GetAllBadges();

            //Assert
            bool dictionaryHasBadges = newDictionary.ContainsKey(_badges.BadgeID);
            Assert.IsTrue(dictionaryHasBadges);
        }
        [TestMethod]
        public void UpdateBadge()
        {
            //Arrange
            _repo.AddBadgeToDictionary(_badges);
            string updatedAccess = "A1";

            //Act
            _repo.UpdateAccess(12345, updatedAccess);
            Assert.AreEqual(3, _badges.DoorAccess.Count);
        }
        [TestMethod]
        public void RemoveDoorAccess()
        {
            //Arrange
            _repo.AddBadgeToDictionary(_badges);
            string removedAccess = "A5";

            //Act
            _repo.RemoveAccess(12345, removedAccess);
            Assert.AreEqual(1, _badges.DoorAccess.Count);
        }
    }
}
