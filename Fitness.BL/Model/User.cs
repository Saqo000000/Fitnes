using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.BL.Model
{
    [Serializable]
    public class User
    {
        public string Name { get; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        private double weight;
        public double Weight
        {   
            get => weight; 
            set
            {   if (value <= 30) throw new ArgumentException("Weight can't be less than 20kg ", nameof(value)); }
        }
        private double height;
        public double Height 
        { 
            get=>height; 
            set
            { if (value <= 30 || value >= 250) throw new ArgumentException("Height can't be less than 30sm and more than 250sm", nameof(value)); }
        }
        
        /// <summary>
        /// set currect age for user
        /// </summary>
        public int Age { 
            get 
            { 
                DateTime todaydate = DateTime.Today;
                int age = todaydate.Year - BirthDate.Year;
                if (BirthDate>todaydate.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
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

        public User(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User's name can't be empty", nameof(userName));
            }
            Name = userName;
        }
        public override string ToString()
        {
            return "Name="+Name + "\t" + "Age="+Age + "\t" + "Gender="+Gender + 
                "\t" + "BirthDate=" + BirthDate + "\t" + "Weight=" + Weight + "\t" + "Height=" + Height;
        }
    }
}
