using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace DuplicateFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(@"C:\Users\brbry_000\Downloads\Pipedrive");

            using var reader = new StreamReader(files[0]);
            
                List<Contact> Leads = new List<Contact>();
       
                string[] values = { };
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    values = line.Split(',');

                    Leads.Add(new Contact(values[1], values[0], values[2]));
                }
                     

                foreach(var person in Leads)
            {
                Console.WriteLine($"{person.Name} {person.Email} {person.Number}");
            }

            Console.WriteLine("");

                //Leads duplicates
                IEnumerable<Contact> duplicates = Leads.GroupBy(i => i)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

                //Displays Selected Persons
                if(!duplicates.Any())
                {
                    Console.WriteLine("No Duplicates Found");
                } else
                {
                Console.WriteLine("Duplicates:");
                foreach(var item in duplicates)
                {
                    Console.WriteLine($"{item.Name} {item.Email} {item.Number}");
                }
                }
            
        }
    }
}
