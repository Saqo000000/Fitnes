using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name;
        public double Proteins { get;}
        public double Fats { get;}
        public double Carbohydrates { get;}
        /// <summary>
        /// calorie for 100gramm food
        /// </summary>
        public double Calories { get; }


        public Food(string name) : this(name, 0, 0, 0, 0) { }
        public Food(string name, double Proteins, double Fats, double Carbohydrates, double Calories)
        {
            this.Proteins = Proteins / 100.0;
            this.Fats = Fats / 100.0;
            this.Carbohydrates = Carbohydrates / 100.0;
            this.Calories = Calories / 100.0;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
        //public override bool Equals(object obj)
        //{

        //    if (obj is Food food)
        //    {
        //        return food.Name == Name ? true : false;
        //    }
        //    else { throw new Exception("There are uncompare objects"); }
        //}
    }
}
