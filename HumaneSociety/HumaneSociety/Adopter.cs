using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Adopter
    {
        //Prompt for Adopter
        public void AdopterPrompt()
        {
            Console.WriteLine("Welcome to the Adopter menu.");
            Console.WriteLine("Enter '1' to search for animal by traits, '2' to create a personal info profile, '3' to return to Portal menu.");
        }
        //Method for menu
  
        //Method for creating a table to share personal info

        //Method to search for an animal by traits
        public void SearchByTraits()
        {
            string option;
            Console.WriteLine("Enter '1' to search by type of animal, '2' by age, '3' for animals that have shots, '4' to return to Adopter menu.");
            switch (option = Console.ReadLine())
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.");
                    SearchByTraits();
                    break;
            }
        }
    }
}
