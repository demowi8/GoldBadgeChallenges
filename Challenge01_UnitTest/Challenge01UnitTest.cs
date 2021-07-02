using GoldBadge_Challenge01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge01_UnitTest
{
    [TestClass]
    public class Challenge01UnitTest
    {
        //AAA of testing
        //Arrange
        //Act
        //Assert

        [TestMethod]
        //Functions to test need new test method
        public void AddMenuItem_ShouldGetCorrectBool()
        {
            //Arrange

            MenuItems newItem = new MenuItems();
            MenuRepo_Repository repository = new MenuRepo_Repository();

            //Act
            bool addItem = repository.AddAMenuItemToList(newItem);

            //Assert
            Assert.IsTrue(addItem);

        }
        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectList()
        {
            //Arrange
            MenuItems testItems = new MenuItems("Cheeseburger", 1, "Delicious cheese burger with all the fix-ins", 5.50, "100% real beef, american cheese, tomato, lettuce, pickle, onion, ketchup, mustard.");
            MenuRepo_Repository repo = new MenuRepo_Repository();
            repo.AddAMenuItemToList(testItems);

            //Act
            List<MenuItems> items = repo.GetMenuItems();
            bool listHasMenuItems = items.Contains(testItems);

            //Assert
            Assert.IsTrue(listHasMenuItems);

        }

        private MenuItems _menuItems;
        private MenuRepo_Repository _repo;
        [TestInitialize]
        public void Arrangement()
        {
            _menuItems = new MenuItems("Cheeseburger", 1, "Delicious cheese burger with all the fix-ins", 5.50, "100% real beef, american cheese, tomato, lettuce, pickle, onion, ketchup, mustard.");
            _repo = new MenuRepo_Repository();
            _repo.AddAMenuItemToList(_menuItems);
        }



        [TestMethod]
        public void GetByNumber_ShouldReturnCorrectItem()
        {
            //Arrange
            //arrangement method

            //Act
            MenuItems searchResult = _repo.GetItemByNumber(1);

            //Assert
            Assert.AreEqual(_menuItems, searchResult);

        }
        [TestMethod]
        public void GetByName_ShouldReturnCorrectItem()
        {
            //Arrange

            //Act
            MenuItems searchResult = _repo.GetItemByName("Cheeseburger");

            //Assert
            Assert.AreEqual(_menuItems, searchResult);
        }
        [TestMethod]
        public void DeleteExistingItems_ShouldReturnTrue()
        {
            //Arrange
            MenuItems chosenItem = _repo.GetItemByNumber(1);
            //Act
            bool removeResult = _repo.RemoveMenuItem(chosenItem);
            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
