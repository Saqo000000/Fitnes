using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL;
using Fitness.BL.Controller;
using Fitness.BL.Model;
using System.Globalization;
using System.Resources;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.ReadLine();
            CultureInfo culture = CultureInfo.CreateSpecificCulture("ddn-us");
            ResourceManager resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages",typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello",culture));
            Console.WriteLine(resourceManager.GetString("EnterName", culture));

            /*
            Console.WriteLine(Languages.Messages.Hello);
            Console.WriteLine(Languages.Messages.EnterName);//get strings from resourses file
            */
            string name = Console.ReadLine();
            UserController userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter user gender ");
                string gender = Console.ReadLine();
                double weight, height;
                DateTime birthdate = ParseDateTime("user birthdate");

                weight = ParseDouble("weight");
                height = ParseDouble("height");
                userController.SetNewUserData(gender, birthdate, height, weight);
            }
            Console.WriteLine(userController.CurrentUser);
            EatingController eatingController = new EatingController(userController.CurrentUser);
            ExerciseController exerciseController = new ExerciseController(userController.CurrentUser);
            while (true)
            {
                Console.WriteLine("What do you want to do");
                Console.WriteLine("E-enter eathing");
                Console.WriteLine("A-enter exercise");
                Console.WriteLine("Q-enter exit");
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var food = EnterEating();
                        eatingController.Add(food.Food, food.Weight);
                        Console.WriteLine();
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} ---- {item.Value}");
                            Console.WriteLine();
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.activity, exe.begin, exe.finish);
                        foreach(Exercise item in exerciseController.Exercises)
                        {
                            Console.WriteLine(item.Activity+"\t"+ 
                                item.Start.ToShortTimeString() + "\t"+ 
                                item.Finish.ToShortTimeString() );
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                } 
            }
        }

        private static (DateTime begin, DateTime finish,Activity activity) EnterExercise()
        {
            Console.Write("Enter exercise name:");
            string name = Console.ReadLine();
            double energy = ParseDouble("Rasxod energy v minutu");
            DateTime begin = ParseDateTime("Start time exercise");
            DateTime end = ParseDateTime("Finish time exercise");
            Activity activity = new Activity(name, energy);
            return (begin, end, activity);
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





        private static DateTime ParseDateTime(string value)
        {
            Console.WriteLine($"Enter {value} dd.mm.yyyy ");
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthdate))
                {
                    return birthdate;
                }
                else { Console.WriteLine($"Incorrect format {value}"); }
            }
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter  {name} ");
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
