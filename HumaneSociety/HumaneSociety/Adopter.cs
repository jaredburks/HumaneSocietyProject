using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Adopter
    {
        AnimalInfoDataContext database;
        Employee employee;

        public Adopter()
        {
            database = new AnimalInfoDataContext();
            employee = new Employee();
        }

        //Prompt for Adopter
        public void AdopterPrompt()
        {
            Console.WriteLine("Welcome to the Adopter menu.");
            Console.WriteLine("Enter '1' to search for animal by traits, '2' to create a personal info profile, '3' to return to Portal menu.");
        }
        //Method for menu
        public void AdopterMenu()
        {
            string option;
            AdopterPrompt();
            switch (option = Console.ReadLine())
            {
                case "1":
                    SearchMenu();
                    break;
                case "2":
                    break;
                case "3":
                    Portal portal = new Portal();
                    portal.Run();
                    break;
                default:
                    Console.WriteLine("Please enter a vaild option.\n");
                    AdopterMenu();
                    break;
            }
        }
  
        //Method for creating a table to share personal info

        //Method to search for an animal by traits
        public void SearchMenu()
        {
            string option;
            Console.WriteLine("Enter '1' to search by type of animal, '2' by age, '3' for animals that have shots, '4' to return to Adopter menu.");
            switch (option = Console.ReadLine())
            {
                case "1":
                    SearchByType();
                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "4":
                    AdopterMenu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.\n");
                    SearchMenu();
                    break;
            }
        }

        //Method for search
        public void SearchByType()
        {
            string type = Console.ReadLine();
            foreach (Animal_Info element in database.Animal_Infos)
            {
                if ( element.Animal_type == type)
                {
                    employee.DisplayAnimalInfo(element);
                }
                else
                {
                    Console.WriteLine("No animal of that type in database.");
                }
            }
        }
    }
}
