using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL;
using Fitness.BL.Controller;

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
                Console.WriteLine($"Enter user {name}");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Incorrect format  {name}");
                }
            }
        }
    }
}
