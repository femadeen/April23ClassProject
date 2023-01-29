using System;
using System.Collections.Generic;
using System.IO;

namespace April23NewProject
{
    public class CountryRepository
    {
        public CountryRepository()
        {
            ConvertToCountryObject();
        }
        public List<Country> CountriesData = new List<Country>();

         string file = "C:\\Users\\Oluwafemi\\Documents\\April23NewProject\\CountryFIle\\country1.txt";
        public List<Country> AddCountries()
        {
            Console.WriteLine("how many countries you would like to register");
            int response = int.Parse(Console.ReadLine());
            for(int i = 0; i < response; i++)
            {
                Console.WriteLine($" Enter Country{i+1}");
                string countryName = Console.ReadLine();
                Console.WriteLine($" Enter Country population{i+1}");
                int countryPopulation  = int.Parse(Console.ReadLine());
                Console.WriteLine($" Enter Country landmass{i+1}");
                double  countryLandmass = double.Parse(Console.ReadLine());
                bool isDeveloped = false;  
                if(countryPopulation > 2000000)
                {
                   isDeveloped = true; 
                }
                Country country = new Country(countryName, countryPopulation, countryLandmass, isDeveloped);
                CountriesData.Add(country);
            }
            return CountriesData;     
        }

         public void WriteToFile()
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(file, true))
                {
                    foreach(var country in CountriesData) 
                    {
                         sw.WriteLine(country.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

         public void RefreshFile()
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(file, false))
                {
                    foreach(var country in CountriesData) 
                    {
                         sw.WriteLine(country.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

         public string[] ReadCountriesFromFile()
        {
            string[] content = null;
            try
            {
                content = File.ReadAllLines(file);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return content;
        }
        
         public void ConvertToCountryObject()
        {
            var countriesFromFile = ReadCountriesFromFile();
            foreach(var content in countriesFromFile)
            {
                var country =  Country.ToCountry(content); 
                CountriesData.Add(country);
            }
        }

         private Country FindCountryById( int countryId)
        {
            Country result = null;
            foreach(var country in CountriesData)
            {
                if(countryId == country.Id)
                {
                    result = country;
                }
            }
            return result;  
        }

        public void GetCountry()
        {
            Console.WriteLine("what is the country's ID you would like to find");
            int response = int.Parse(Console.ReadLine());
            var result = FindCountryById(response);
            if(result != null)
            {
                Console.WriteLine(result.ToString());
            }
            else
            {
                Console.WriteLine("invalid Id input");
            }
        }
       
        public void PrintAllCountries()
        {
            foreach(var country in CountriesData)
            {
                Console.WriteLine(country.ToString());
            }
        }

        public void CountryUpdate()
        {
            PrintAllCountries();
            Console.WriteLine("Enter the country's ID you would like to update");
            int response = int.Parse(Console.ReadLine());
            var country= FindCountryById(response);
            if(country != null)
            {
                Console.WriteLine("Enter new Country's population");
                int newPopulation = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new Country's landmass");
                double newLandMass = double.Parse(Console.ReadLine());  
                country.Population = newPopulation;
                country.LandMass = newLandMass;
                RefreshFile();
                Console.WriteLine($"Country {country.CountryName} has been successfully updated");
            }
            else
            {
                Console.WriteLine("No country has the entry ID");
            }
           
        }

        public void DeleteCountry()
        {
            PrintAllCountries();
            Console.WriteLine("Enter country's ID you would like to delete");
            int countryId = int.Parse(Console.ReadLine());
            var country = FindCountryById(countryId);
            if(country != null)
            {
               CountriesData.Remove(country);
               RefreshFile();
               Console.WriteLine($"the country {country.CountryName} has been deleted");
            }
            else
            {
                Console.WriteLine("No country's Id exist");
            }
            
        }
    
        


    }
}