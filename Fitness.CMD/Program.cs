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
            Console.WriteLine("Hellow from fitnes club'");
            
            Console.WriteLine("Enter user name ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter user gender ");
            string gender = Console.ReadLine();

            Console.WriteLine("Enter user birthdate ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter user weight ");
            double weight =double.Parse(Console.ReadLine());

            Console.WriteLine("Enter user Height ");
            double height = double.Parse(Console.ReadLine());


            UserController user = new UserController(name,gender,birthdate,weight,height);
            user.Save();

        }
    }
}
