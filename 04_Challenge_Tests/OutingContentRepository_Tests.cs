using System;
using System.Collections.Generic;
using _04_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Challenge_Tests
{
    [TestClass]
    public class OutingContentRepository_Tests
    {
        OutingContentRepository _outingRepo;
        List<OutingContent> _content;

        [TestInitialize]
        public void Arrange()
        {   
            _outingRepo = new OutingContentRepository();
            _content = _outingRepo.GetOutingContentList();

            OutingContent outing = new OutingContent(65, DateTime.Parse("2019/06/15"), OutingType.Golf, 75m, 300m);
            OutingContent outingTwo = new OutingContent(45, DateTime.Parse("2019/04/22"), OutingType.Bowling, 40m, 400m);
            OutingContent outingThree = new OutingContent(40, DateTime.Parse("2019/07/25"), OutingType.AmusementPark, 50m, 500m);

            _outingRepo.AddOutingContentToList(outing);
            _outingRepo.AddOutingContentToList(outingTwo);
            _outingRepo.AddOutingContentToList(outingThree);
        }

        [TestMethod]
        public void AddOutingContentToList()
        {
            Arrange();

            int actual = _content.Count;
            int expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOutingCostByType()
        {
            Arrange();

            OutingContentRepository outingRepo = new OutingContentRepository();
            OutingContent cost = new OutingContent(50, DateTime.Parse("2019, 08, 23"), OutingType.Concert, 80m, 600m);

            outingRepo.AddOutingContentToList(cost);

            decimal actual = outingRepo.GetOutingCostByType(OutingType.Concert);

            Assert.AreEqual(cost.TotalCostOfOutings, actual);
        }

        [TestMethod]
        public void GetTotalOutingsCost()
        {
            Arrange();

            decimal actual = _outingRepo.GetTotalOutingsCost();
        }
    }
}
