using System;
using System.Collections.Generic;
using _01_MenuClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_MenuTest
{
    [TestClass]
    public class MenuRepoTests
    {
        private Menu _items;
        private MenuRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepo();
            _items = new Menu(5, "Food", "Description of Food", "list of ingredients", 10d);
            _repo.AddItemToMenu(_items);
        }

        [TestMethod]
        public void AddToMenu()
        {
            //ACT
            bool addResult = _repo.AddItemToMenu(_items);

            //ASSERT
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMenu()
        {
            //ACT
            List<Menu> listOfMenuItems = _repo.GetFullMenu();

            //ASSERT
            bool menuHasItems = listOfMenuItems.Contains(_items);
            Assert.IsTrue(menuHasItems);
        }

        [TestMethod]
        public void GetByItemNumber()
        {
            //ACT
            Menu searchResult = _repo.GetItemByNumber(5);

            //ASSERT
            Assert.AreEqual(_items, searchResult);
        }

        [TestMethod]
        public void UpdateItem()
        {
            //ARRANGE
            Menu updatedItem = new Menu(2, "New Food", "New Description of Food", "New list of ingredients", 9.99d);

            //ACT
            bool updatedResult = _repo.ChangeMenuItem(5, updatedItem);

            //ASSERT
            Assert.IsTrue(updatedResult);
        }

        [TestMethod]
        public void DeleteItem()
        {
            //ARRANGE
            Menu itemToBeRemoved = _repo.GetItemByNumber(5);

            //ACT
            bool removeResult = _repo.DeleteItemFromMenu(itemToBeRemoved);

            //ASSERT
            Assert.IsTrue(removeResult);
        }
    }
}
