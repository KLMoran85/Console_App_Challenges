using System;
using System.Collections.Generic;
using _02_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Challenge_Tests
{
    [TestClass]
    public class ClaimContentRepository_Tests
    {
        ClaimContentRepository _claimRepo;
        Queue<ClaimContent> _content;

        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimContentRepository();
            _content = _claimRepo.GetClaimContentQueue();

            ClaimContent claim = new ClaimContent(ClaimType.Car, 3, "Car Wreck on I70W", 1500m, DateTime.Parse("2019, 02, 23"), DateTime.Parse("2019, 02, 24"));
            ClaimContent claimTwo = new ClaimContent(ClaimType.Home, 4, "Home Invasion", 700m, DateTime.Parse("2019, 03, 11"), DateTime.Parse("2019, 03, 12"));
            ClaimContent claimThree = new ClaimContent(ClaimType.Theft, 5, "Tire Thief", 100m, DateTime.Parse("2019, 05, 10"), DateTime.Parse("2019, 05, 25"));

            _claimRepo.AddContentToQueue(claim);
            _claimRepo.AddContentToQueue(claimTwo);
            _claimRepo.AddContentToQueue(claimThree);
        }

        [TestMethod]
        public void AddContentToQueue()
        {
            Arrange();

            int actual = _content.Count;

            int expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveNextClaim()
        {
            Arrange();
            int actual = _content.Count;

            Assert.AreEqual(3, actual);

            _claimRepo.RemoveNextClaim();
            int actual2 = _content.Count;
            Assert.AreEqual(2, actual2);

        }
    }
}