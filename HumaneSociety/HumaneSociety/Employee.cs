using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Employee
    {
        AnimalInfoDataContext database;
        Animal_Info animal;

        public void EmployeePrompt()
        {
            Console.WriteLine("Employee Menu\nENTER '1' to search for an animal, '2' to add an animal to database, '3' to return to Portal.");
        }
        //Method for employee menu 
        public void EmployeeMenu()
        {
            EmployeePrompt();
            string option;
            switch(option = Console.ReadLine())
            {
                case "1"://For Searching for an animal
                    AnimalSearch();
                    EmployeeMenu();
                    break;
                case "2"://For Adding an animal to database
                    AddAnimal();
                    EmployeeMenu();
                    break;
                case "3":

                    break;
                case "3"://Back to Portal
                    Portal portal = new Portal();
                    portal.Run();
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
            database = new AnimalInfoDataContext();
            Console.WriteLine("Enter animal type, name, age, room#, IsAdopted(false for no, true for yes), HasShots(false for no, true for yes), and amount of food");
            animal = new Animal_Info
            {
                Animal_type = Console.ReadLine(),
                Name = Console.ReadLine(),
                Age = Convert.ToInt32(Console.ReadLine()),
                Room_ = Convert.ToInt32(Console.ReadLine()),
                IsAdopted = Convert.ToBoolean(Console.ReadLine()),
                HasShots = Convert.ToBoolean(Console.ReadLine()),
                Amount_of_Food = Console.ReadLine(),
                Price = 200.00M
            };
            database.Animal_Infos.InsertOnSubmit(animal);
            database.SubmitChanges();
            DisplayAnimalInfo(animal);
        }

        //Method to search for animals by ID
        public void AnimalSearch()
        {
            Console.WriteLine("Enter the ID of the animal you want to find");
            int creature = Convert.ToInt16(Console.ReadLine());
            database = new AnimalInfoDataContext();

            foreach(Animal_Info element in database.Animal_Infos)
            {
                if(element.ID == creature)
                {
                    Console.WriteLine("Found animal ID: " + element.ID);
                    DisplayAnimalInfo(element);
                    if(element.HasShots == false)
                    {
                        AskForShots(element);
                    }
                }
                else
                {
                    Console.WriteLine("No animal with that ID in database.");
                }
            }
        }
        //Method to adopt an animal(change IsAdopted to true)
        public void ChangeAdoptedStatus(Animal_Info animal)
        {
            if(animal.IsAdopted == false)
            {
                animal.IsAdopted = true;
                Console.WriteLine(animal.Name + " is now adopted.");
            }
            else
            {
                Console.WriteLine(animal.Name + " is already adopted.");
            }
        }
        public void AskForShots(Animal_Info element)
        {
            string pick;
            Console.WriteLine("Would you like to administer " + animal.Name + " shots?");
            switch (pick = Console.ReadLine())
            {
                case "yes":
                    GiveShots(animal);
                    break;
                case "no":
                    break;
                default:
                    Console.WriteLine("Please enter 'yes' or 'no' in lower case.");
                    AskForShots(element);
                    break;
            }
        }
        //Method to administer shots to animal
        public void GiveShots(Animal_Info animal)
        {
                animal.HasShots = true;
                Console.WriteLine(animal.Name + " has been given shots.");
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
