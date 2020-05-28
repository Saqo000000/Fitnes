using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.BL.Model
{
    class User
    {

        public string Name { get; }
        public Gender Gender { get; }
        public DateTime BirthDate { get; }
        public double Weight { get; set; }
        public double Height { get; set; }
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="gender">Gender</param>
        /// <param name="birthdate">Birthday date</param>
        /// <param name="weight">Weight</param>
        /// <param name="height">Height</param>
        public User(string name,Gender gender,DateTime birthdate,
                    double weight,double height)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name of user can't be null or empty", nameof(name));
            }
            if (gender==null)
            {
                throw new ArgumentNullException("Field can't be null", nameof(gender));
            }
            if (birthdate<DateTime.Parse("01.01.1900")&& birthdate>=DateTime.Now)
            {
                throw new ArgumentException("Impossibly birthdate", nameof(birthdate));
            }
            if (height<=30 || height>=250)
            {
                throw new ArgumentException("Height can't be less than 30sm and more than 250sm", nameof(height));
            }
            if (weight<=30)
            {
                throw new ArgumentException("Weight can't be less than 20kg ", nameof(weight));
            }
            Name = name;
            Weight = weight;
            Height = height;
            Gender = gender;
            BirthDate = birthdate;
        }

        public override string ToString()
        {
            return Name + "\t" + Gender + "\t" + BirthDate + "\t" + Weight + "\t" + Height;
        }
    }
}
