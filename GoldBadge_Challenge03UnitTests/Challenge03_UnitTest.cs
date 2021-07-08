using GoldBadge_Challenge03;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GoldBadge_Challenge03UnitTests
{
    [TestClass]
    public class Challenge03_UnitTest
    {
        private Badge_Repository _repo;
        private Badges _badge;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new Badge_Repository();
            _badge.AccessDoorsAvailable.Add("A1");
            _badge = new Badges("12345", _badge.AccessDoorsAvailable);
            _repo.AddToBadgeDictionary(_badge); 
        }
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            
            //Act
            //Assert
        }
    }
}
