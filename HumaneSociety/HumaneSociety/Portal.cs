using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Portal
    {
        public void WelcomePromt()
        {
            Console.WriteLine("Welcome to the Humane Society Portal!");
            Console.WriteLine("Enter '1' for Employee, or '2' for Adopter\n");
        }
        public void Run()
        {
            WelcomePromt();
            string option;
            switch(option = Console.ReadLine())
            {
                case "1"://For Employees
                    Employee employee = new Employee();
      
                    break;
                case "2"://For adopters
                    Adopter adopter = new Adopter();

                    break;
                default:
                    Console.WriteLine("Please enter a valid option.\n");
                    Run();
                    break;
            }
        }
    }
}
