using System;
using Fitness.BL.Model;
using System.IO;

using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    public class UserController:ControllerBase
    {
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        private const string Users_File_Name = "users.dat";


        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User's name can't be empty", nameof(userName));
            }
            Users = GetUsersData();
            CurrentUser = Users.Find(u => u.Name == userName ? true : false);
            if (CurrentUser==null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                Save();
                IsNewUser = true;
            }
        }

        /// <summary>
        /// get save users list
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(Users_File_Name) ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime birthdate,double height=1,double weight=1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            CurrentUser.BirthDate = birthdate;
            Save();
        }

        /// <summary>
        /// Save users data
        /// </summary>
        public void Save()
        {
            Save(Users_File_Name, Users);
        }
       
    }
}
