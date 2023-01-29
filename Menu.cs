using System;
namespace April23NewProject
{
    public class Menu
    {
        public static CountryRepository countryRepo;

        public Menu()
        {
            countryRepo = new CountryRepository();
        }
        public void MainMenuSelection()
        {
            Console.WriteLine("Enter 1 to add a country");
            Console.WriteLine("Enter 2 to update a country");
            Console.WriteLine("Enter 3 to delete a country");
            Console.WriteLine("Enter 4 to view all countries");
            Console.WriteLine("Enter 5 to get country by ID");   
        }

        public void HandleMenuSelection()
        {
            MainMenuSelection();
            int response = int.Parse(Console.ReadLine());
            switch(response)
            {
                case 1:
                countryRepo.AddCountries();
                break;
                case 2:
                countryRepo.CountryUpdate();
                break;
                case 3:
                countryRepo.DeleteCountry();
                break;
                case 4:
                countryRepo.PrintAllCountries();
                break;
                case 5:
                countryRepo.GetCountry();
                break;
                default:
                Console.WriteLine("invalid selection");
                break;
            }
        }
        public void MainMenu()
        {
            bool input = true;
            while(input)
            {
                HandleMenuSelection();
               Console.WriteLine("Enter yes to contiue and no to exit the app");
               string response = Console.ReadLine();
               if(response.ToLower() == "no")
               {
                   input = false;
                   Console.WriteLine("Thanks for using my App");
               }
            }
            
   
        }
    }
}