using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Employee
    {
        Animal_Info animal = new Animal_Info();

        public void EmployeePrompt()
        {
            Console.WriteLine("Employee Menu\nENTER '1' to search for an animal, '2' to add an animal to database.");
        }
        //Method for employee menu 
        public void EmployeeMenu()
        {
            EmployeePrompt();
            string option;
            switch(option = Console.ReadLine())
            {
                case "1"://For Searching for an animal

                    break;
                case "2"://For Adding an animal to database
                    AddAnimal();
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.\n");
                    EmployeeMenu();
                    break;
            }
        }
        //Method to Add an animal to the database
        public void AddAnimal()
        {
            animal.ID = 1;

        }

        //Method to search for animals by traits(properties)

        //Method to adopt an animal(change IsAdopted to true)

        //Method to check if animal has had shots, and if not administer shots

    }
}
