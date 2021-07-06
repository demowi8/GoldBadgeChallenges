using GoldBadge_Challenge02;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge02UnitTest
{
    [TestClass]
    public class Challenge02UnitTest
    {
        [TestMethod]
        public void AddClaimToQueue_ShouldGetCorrectBool()
        {
            //Arrange
            Claims newClaim = new Claims();
            ClaimRepository repository = new ClaimRepository();

            //Act
            bool addClaim = repository.AddClaimToQueue(newClaim);
            //Assert
            Assert.IsTrue(addClaim);
        }
        [TestMethod]
        public void GetClaimQueue_ShouldReturnQueue()
        {
            //Arrange
            Claims testClaim = new Claims(1, ClaimType.Car, "Accident on highway 465", 7500.32m, new DateTime(2020, 4, 2), new DateTime(2020, 4, 27));
            ClaimRepository repo = new ClaimRepository();
            repo.AddClaimToQueue(testClaim);
            //Act
            Queue<Claims> claims = repo.GetClaimQueue();
            bool queueHasClaims = claims.Contains(testClaim);
            //Assert
            Assert.IsTrue(queueHasClaims);
        }
        [TestMethod]
        public void MyTestMethod()
        {

        }
    }
}
