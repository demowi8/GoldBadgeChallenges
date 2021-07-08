using GoldBadge_Challenge03;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GoldBadge_Challenge03UnitTests
{
    [TestClass]
    public class Challenge03_UnitTest
    {
        private Badge_Repository _repo;
        private Badges _badge;
        private List<string> _doorAccess;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new Badge_Repository();
            
            _doorAccess = new List<string>() { "A1", "A2" };

            _badge = new Badges("12345", _doorAccess);
        }
        [TestMethod]
        public void AddToDictionary_ShouldGetCorrectBool()
        {
            //Arrange
            Arrange();
            //Act
             
            bool addBadge = _repo.AddToBadgeDictionary("12345",_badge);
            //Assert
            Assert.IsTrue(addBadge);
        }
    }
}
