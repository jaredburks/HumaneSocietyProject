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
        AdopterInfo adopter;
        decimal bank;
        public Employee()
        {
            database = new AnimalInfoDataContext();
        }
        public void EmployeePrompt()
        {
            Console.WriteLine("Employee Menu\nENTER '1' to search for an animal, '2' to add an animal to database,\n'3' to Import CSV, '4' to check Humane Society Bank,\n'5' to return to Portal.");
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
                    ImportCSV();
                    EmployeeMenu();
                    break;
                case "4":
                    CheckFunds();
                    EmployeeMenu();
                    break;
                case "5"://Back to Portal
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
            Console.WriteLine("Enter animal type, name, age, room#, IsAdopted(false for no, true for yes), HasShots(false for no, true for yes), daily food intake.");
            animal = new Animal_Info
            {
                Animal_type = Console.ReadLine(),
                Name = Console.ReadLine(),
                Age = Convert.ToInt32(Console.ReadLine()),
                Room_ = Convert.ToInt32(Console.ReadLine()),
                IsAdopted = Convert.ToBoolean(Console.ReadLine()),
                HasShots = Convert.ToBoolean(Console.ReadLine()),
                Food_Daily = Console.ReadLine(),
                Price = 200.00M
            };
            database.Animal_Infos.InsertOnSubmit(animal);
            database.SubmitChanges();
            DisplayAnimalInfo(animal);
        }

        //Method to search for animals by ID
        public void AnimalSearch()
        {
            var db = database.Animal_Infos.ToArray();

            if (db.Length == 0)
            {
                Console.WriteLine("No animals in database.\n");
            }
            else
            {
                Console.WriteLine("Enter the ID of the animal you want to find");
                int creature = Convert.ToInt16(Console.ReadLine());

                foreach (Animal_Info element in database.Animal_Infos)
                {
                    if (element.ID == creature)
                    {
                        Console.WriteLine("Found animal ID: " + element.ID);
                        DisplayAnimalInfo(element);
                        if (element.HasShots == false)
                        {
                            AskForShots(element);
                        }
                        if (element.IsAdopted == false)
                        {
                            AskToAdopt(element);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No animal with that ID in database.\n");
                    }
                }
            }
        }
        public void AskToAdopt(Animal_Info animal)
        {
            string pick;
            Console.WriteLine("Would you like to change adoption status for " + animal.Name + " ?");
            Console.WriteLine("Enter 'y' for yes, 'n' for no");
            switch (pick = Console.ReadLine())
            {
                case "y":
                    GetAdopter();
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Please enter 'y' or 'n' in lower case.\n");
                    AskToAdopt(animal);
                    break;
            }
        }
        //Method to get Adopter ID and take their moneys
        public void GetAdopter()
        {
            Console.WriteLine("Enter the ID of the person that is adopting.\n");
            int person = Convert.ToInt16(Console.ReadLine());

            foreach (AdopterInfo element in database.AdopterInfos)
            {
                if (element.ID == person)
                {
                    Console.WriteLine("Found adopter ID: " + element.ID);
                    //If they have enough cash, take $200
                    PayUp(element);
                }
                else
                {
                    Console.WriteLine("No person with that ID in database.");
                }
            }
        }
        public void CheckFunds()
        {
            Console.WriteLine("Humane Society has $" + bank + " in funds.\n");
        }
        //Take adopter's cash to pay for animal
        public void PayUp(AdopterInfo person)
        {
            if (person.Wallet >= 200)
            {
                person.Wallet = person.Wallet - 200;
                bank += 200;
                ChangeAdoptedStatus(animal);
            }
            else
            {
                Console.WriteLine("Not enough money to adopt today :(\n");
            }
        }
        //Method to adopt an animal(change IsAdopted to true)
        public void ChangeAdoptedStatus(Animal_Info animal)
        {
            animal.IsAdopted = true;
            Console.WriteLine(animal.Name + " is now adopted.\n");
        }
        public void AskForShots(Animal_Info element)
        {
            string pick;
            Console.WriteLine("Would you like to administer " + animal.Name + " shots?");
            Console.WriteLine("Enter 'y' for yes, 'n' for no");
            switch (pick = Console.ReadLine())
            {
                case "y":
                    GiveShots(animal);
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Please enter 'y' or 'n' in lower case.\n");
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
        public void ImportCSV()
        {
            // Create the IEnumerable data source
            string[] lines = System.IO.File.ReadAllLines(@"C:/Users/Jared/Documents/Visual Studio 2015/Projects/HumaneSocietyLog.csv");

            // Create the query. Put field 2 first, then
            // reverse and combine fields 0 and 1 from the old field
            IEnumerable<string> query =
                from line in lines
                let x = line.Split(',')
                select x[0] + ", " + (x[1] + " " + x[2] + " " + x[3] + " " + x[4] + " " + x[5] + " " + x[6]);

            // Execute the query and write out the new file. Note that WriteAllLines
            // takes a string[], so ToArray is called on the query.
            System.IO.File.WriteAllLines(@"C:/Users/Jared/Documents/Visual Studio 2015/Projects/HumaneSocietyLog2.csv", query.ToArray());

            Console.WriteLine("HumaneSocietyLog2.csv written to disk. Press any key to return to Employee Menu.\n");
            Console.ReadKey();
        }
        //Method to display animal info
        public void DisplayAnimalInfo(Animal_Info animal)
        {
            Console.WriteLine("ID: " + animal.ID);
            Console.WriteLine("Name: " + animal.Name);
            Console.WriteLine("Type: " + animal.Animal_type);
            Console.WriteLine("Age: " + animal.Age);
            Console.WriteLine("Room#: " + animal.Room_);
            Console.WriteLine("Adopted: " + animal.IsAdopted);
            Console.WriteLine("Has Shots: " + animal.HasShots);
            Console.WriteLine("Food Daily: " + animal.Food_Daily);
            Console.WriteLine("Price: $" + animal.Price);
        }
    }
}
