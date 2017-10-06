using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Employee
    {
        Animal_Info animal;

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
            animal = new Animal_Info
            {
                Animal_type = Console.ReadLine(),
                Name = Console.ReadLine(),
                Age = Convert.ToInt32(Console.ReadLine()),
                Room_ = Convert.ToInt32(Console.ReadLine()),
                IsAdopted = Convert.ToBoolean(Console.ReadLine()),
                HasShots = Convert.ToBoolean(Console.ReadLine()),
                Amount_of_Food = Console.ReadLine(),
                Price = Convert.ToDecimal(Console.ReadLine())
            };
            DisplayAnimalInfo(animal);
        }

        //Method to search for animals by traits(properties)

        //Method to adopt an animal(change IsAdopted to true)
        public void ChangeAdoptedStatus(Animal_Info animal)
        {
            if(animal.IsAdopted == false)
            {
                animal.IsAdopted = true;
            }
            Console.WriteLine(animal.Name + " is now adopted");
        }
        //Method to administer shots to animal
        public void GiveShots(Animal_Info animal)
        {
            if(animal.HasShots == false)
            {
                animal.HasShots = true;
            }
            Console.WriteLine(animal.Name + " has been given shots");
        }
        //Method for import/export CSV file (like excel)

        //Method to display animal info
        public void DisplayAnimalInfo(Animal_Info animal)
        {
            Console.WriteLine("Name: " + animal.Name);
            Console.WriteLine("Type: " + animal.Animal_type);
            Console.WriteLine("Age: " + animal.Age);
            Console.WriteLine("Room#: " + animal.Room_);
            Console.WriteLine("Adopted: " + animal.IsAdopted);
            Console.WriteLine("Has Shots: " + animal.HasShots);
            Console.WriteLine("Amount of Food: " + animal.Amount_of_Food);
            Console.WriteLine("Price: " + animal.Price);
        }
    }
}
