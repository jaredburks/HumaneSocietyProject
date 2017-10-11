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
        AdopterInfo adopter;
        public Adopter()
        {
            database = new AnimalInfoDataContext();
            employee = new Employee();
        }
        public void AdopterPrompt()
        {
            Console.WriteLine("Welcome to the Adopter menu.");
            Console.WriteLine("Enter '1' to search for animal by traits, '2' to create a personal info profile, '3' to return to Portal menu.\n");
        }
        public void AdopterMenu()
        {
            string option;
            AdopterPrompt();
            switch (option = Console.ReadLine())
            {
                case "1":
                    SearchMenu();
                    AdopterMenu();
                    break;
                case "2":
                    AddProfile();
                    AdopterMenu();
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
        public void AddProfile()
        {
            Console.WriteLine("Enter first name, last name, age, city\n");
            try
            {
                adopter = new AdopterInfo()
                {
                    First_Name = Console.ReadLine(),
                    Last_Name = Console.ReadLine(),
                    Age = Convert.ToInt32(Console.ReadLine()),
                    City = Console.ReadLine(),
                    Wallet = 400.00M
                };
            }
            catch(FormatException)
            {
                Console.WriteLine("You've entered an invalid response. For age and room# you must type a number.");
                Console.WriteLine("For IsAdopted and HasShots you must type 'true' or 'false'\n");
                AddProfile();
            }
            database.AdopterInfos.InsertOnSubmit(adopter);
            database.SubmitChanges();
            DisplayAdopterInfo(adopter);
        }
        public void DisplayAdopterInfo(AdopterInfo adopter)
        {
            Console.WriteLine("ID: " + adopter.ID);
            Console.WriteLine("First Name: " + adopter.First_Name);
            Console.WriteLine("Last Name: " + adopter.Last_Name);
            Console.WriteLine("Age: " + adopter.Age);
            Console.WriteLine("City: " + adopter.City);
            Console.WriteLine("Wallet: $" + adopter.Wallet + "\n");
        }
        public void SearchMenu()
        {
            string option;
            Console.WriteLine("Enter '1' to search by type of animal, '2' by age, '3' for animals that have shots, '4' to return to Adopter menu.\n");
            switch (option = Console.ReadLine())
            {
                case "1":
                    SearchByType();
                    break;
                case "2":
                    SearchByAge();
                    break;
                case "3":
                    SearchByShots();
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
        public void SearchByType()
        {
            Console.WriteLine("Enter the type of animal you want to search for.\nNOTE: Case sensitive.\n");
            string type = Console.ReadLine();

            IEnumerable<Animal_Info> query =
            from animal in database.Animal_Infos
            where animal.Animal_type == type
            orderby animal.ID
            select animal;
            foreach (Animal_Info element in query)
            {
                employee.DisplayAnimalInfo(element);
            }
        }
        public void SearchByAge()
        {
            try
            {
                Console.WriteLine("Enter the age (as an integer in years) of the animal(s) you want to search by.");
                int age = Convert.ToInt32(Console.ReadLine());

                IEnumerable<Animal_Info> query =
                from animal in database.Animal_Infos
                where animal.Age == age
                orderby animal.ID
                select animal;
                foreach (Animal_Info element in query)
                {
                    employee.DisplayAnimalInfo(element);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter only numbers for age.");
                SearchByAge();
            }            
        }
        public void SearchByShots()
        {
            IEnumerable<Animal_Info> query =
            from animal in database.Animal_Infos
            where animal.HasShots == true
            orderby animal.ID
            select animal;
            foreach(Animal_Info element in query)
            {
                employee.DisplayAnimalInfo(element);
            }
        }
    }
}
