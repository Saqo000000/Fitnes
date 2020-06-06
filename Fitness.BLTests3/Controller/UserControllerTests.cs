using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using Fitness.BL.Model;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        //[TestMethod()]
        //public void UserControllerTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            string username = Guid.NewGuid().ToString();
            var birthdate = DateTime.Now.AddYears(18);
            double weight = 90;
            double height = 190;
            string gender = "Male";

            //Act
            UserController userController = new UserController(username);
            userController.SetNewUserData(gender, birthdate, height, weight);
            //var e = userController;
            UserController userController2 = new UserController(username);

            //Assert
            Assert.AreEqual(username, userController2.CurrentUser.Name);
           // var t=userController2.CurrentUser.Weight;
            Assert.AreEqual(weight, userController2.CurrentUser.Weight);
            Assert.AreEqual(height, userController2.CurrentUser.Height);
            Assert.AreEqual(gender, userController2.CurrentUser.Gender.Name);
            Assert.AreEqual(weight, userController2.CurrentUser.Weight);
            Assert.AreEqual(birthdate, userController2.CurrentUser.BirthDate);
        }

        [TestMethod()]
        public void SaveTest()
        {
            
            //Arrange
            string username = Guid.NewGuid().ToString();


            //Act
            UserController userController = new UserController(username);


            //Assert
            Assert.AreEqual(username, userController.CurrentUser.Name);
            
            //Assert.Fail();
        }
    }
}