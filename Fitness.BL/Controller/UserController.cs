using System;
using Fitness.BL.Model;
using System.IO;

using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    public class UserController
    {
        public User User { get; }
        public UserController(string userName,string genderName,DateTime birthdate,double weight,double height)
        {
            Gender gender = new Gender(genderName);
            User = new User(userName, gender, birthdate, weight, height);
            //User = user ?? throw new ArgumentNullException("User can't be equal null", nameof(user));
        }

        /// <summary>
        /// Save users data
        /// </summary>
        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Get users data
        /// </summary>
        /// <returns></returns>
        public UserController()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if( formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
            }
        }
    }
}
