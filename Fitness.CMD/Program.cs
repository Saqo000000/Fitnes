using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL;
using Fitness.BL.Controller;
using Fitness.BL.Model;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine();
            Console.WriteLine("Hellow from fitnes club'");
            Console.WriteLine("Enter user name ");
            string name = Console.ReadLine();
            UserController userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter user gender ");
                string gender = Console.ReadLine();
                double weight, height;
                DateTime birthdate = ParseDateTime();

                weight = ParseDouble("weight");
                height = ParseDouble("height");
                userController.SetNewUserData(gender, birthdate, height, weight);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine("What do you want to do");
            Console.WriteLine("E-enter eathing");
            ConsoleKeyInfo key = Console.ReadKey();
            EatingController eatingController = new EatingController(userController.CurrentUser);
            if (key.Key==ConsoleKey.E)
            {
               var food= EnterEating();
                eatingController.Add(food.Food,food.Weight);
                Console.WriteLine();
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} ---- {item.Value}");
                    Console.WriteLine();
                }
            }
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Enter name of food:");
            string foodname = Console.ReadLine();
            double weight = ParseDouble("food's weight");
            double calories = ParseDouble("food's calories");
            double proteins = ParseDouble("food's proteins");
            double fats = ParseDouble("food's fats");
            double carbohydrates = ParseDouble("food's carbohydrates");
            Food food = new Food(foodname, proteins, fats, carbohydrates, calories);
            Console.Write("Enter food's calorie");
            return (Food:food, Weight:weight  );
        }





        private static DateTime ParseDateTime()
        {
            Console.WriteLine("Enter user birthdate dd.mm.yyyy ");
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthdate))
                {
                    return birthdate;
                }
                else { Console.WriteLine("Incorrect format birthdate"); }
            }
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter  {name}");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.Write($"Incorrect format field {name}");
                }
            }
        }
    }
}
