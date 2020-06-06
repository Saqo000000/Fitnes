using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using Fitness.BL.Model;
using System.Linq;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {

            //Arrange
            string userName = Guid.NewGuid().ToString();
            string foodName = Guid.NewGuid().ToString();
            Random rd = new Random();
            UserController userController = new UserController(userName);
            EatingController eatingController = new EatingController(userController.CurrentUser);
            Food food = new Food(foodName, rd.Next(50, 500), rd.Next(50, 500), rd.Next(50, 500), rd.Next(50, 500));
            //Act
            eatingController.Add(food, 100);

            //Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);
        }
    }
}