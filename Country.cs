using System;
using System.Collections.Generic;
using System.IO;

namespace April23NewProject
{
    public class Country
    {  
        static int Count = 1;

        public  int Id {get; set;}
        public string CountryName {get; set;}
        public int Population {get; set;}
        public double LandMass {get; set;}
        public bool Isdeveloped {get; set;}
        
        public Country(string countryName, int population, double landmass, bool isDeveloped)
        {
            CountryName = countryName;
            Population = population;
            LandMass = landmass;
            Isdeveloped = isDeveloped;
            Id = Count;
            Count++;
        }
        public override string ToString()
        {
            return $"{Id}\t{CountryName}\t{Population}\t{LandMass}\t{Isdeveloped}";
        }

       public static Country ToCountry(string contents)
       {
           var countries = contents.Split("\t");
           var id = int.Parse(countries[0]);
           var countryName = countries[1];
           var population = int.Parse(countries[2]);
           var landMass = double.Parse(countries[2]);
           var isDeveloped = bool.Parse(countries[4]);
           Country country = new Country(countryName, population, landMass, isDeveloped);
           return country;
       }
        
    }
}