using System;
using System.Collections;
using System.Collections.Generic;
using _02_ClaimsClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimsTest
{
    [TestClass]
    public class ClaimsRepoTest
    {
        private ClaimsRepo _repo;
        private Claims _claims;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsRepo();
            _claims = new Claims(4, TypeOfClaim.Car, "Wreck on I-70", 2000.00d, DateTime.Parse("04/27/2018"), DateTime.Parse("04/28/2018"));
            _repo.AddClaimToQueue(_claims);
        }
        [TestMethod]
        public void AddToQueue()
        {
            //Act
            bool addResult = _repo.AddClaimToQueue(_claims);

            //Assert
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetQueue()
        {
            //Act
            Queue<Claims> claimsQueue = _repo.GetAllClaims();

            //Assert
            bool queueHasClaims = claimsQueue.Contains(_claims);
            Assert.IsTrue(queueHasClaims);
        }
        [TestMethod]
        public void GetNext()
        {
            //Act
            Claims peekNext = _repo.GetNextClaim();

            //Assert
            Assert.AreEqual(_claims, peekNext);
        }
        [TestMethod]
        public void DeleteClaim()
        {
            //Act
            bool dequeueResult = _repo.DeleteClaimFromQueue();

            //Assert
            Assert.IsTrue(dequeueResult);
        }
    }
}
