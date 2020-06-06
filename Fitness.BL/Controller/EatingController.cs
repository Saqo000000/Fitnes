using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Fitness.BL.Controller
{
    public class EatingController:ControllerBase
    {
        private User user;
        private const string Foods_File_Name = "foods.date";
        private const string Eatings_File_Name = "eatings.date";
        public List<Food> Foods { get; }
        public Eating Eating { get; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User cant be empty", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }
        public void Add(Food food,double wieght)
        {
            Food product = Foods.SingleOrDefault((f) => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, wieght);
                Save();
            }
            else
            {
                Eating.Add(product, wieght);
                Save();
            }
        }


        private Eating GetEating()
        {
            return Load<Eating>(Eatings_File_Name) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            var e = Load<List<Food>>(Foods_File_Name) ?? new List<Food>();
            return Load<List<Food>>(Foods_File_Name) ?? new List<Food>();
        }
        private void Save()
        {
            Save(Foods_File_Name, Foods);
            Save(Eatings_File_Name, Eating);
        }
    }
}
