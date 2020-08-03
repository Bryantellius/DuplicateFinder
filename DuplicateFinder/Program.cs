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
            string[] files = Directory.GetFiles(@"C:\Users\Stbus\Downloads\Pipedrive");

            using var reader = new StreamReader(files[0]);
            
                List<Contact> Leads = new List<Contact>();
       
                string[] values = { };
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    values = line.Split(',');

                    Leads.Add(new Contact(values[1], values[0], values[2]));
                }

                Leads.Add(Leads[1]);

                for(int item = 0; item < Leads.Count; item++)
                {
                    Console.WriteLine($"{Leads[item].Name}\t{Leads[item].Email}\t{Leads[item].Number}");
                }

                //Leads duplicates
                HashSet<Contact> hashset = new HashSet<Contact>();
                IEnumerable<Contact> duplicates = Leads.Where(e => !hashset.Add(e));

                //Displays Selected Persons
                if(!duplicates.Any())
                {
                    Console.WriteLine("No Duplicates Found");
                } else
                {
                Console.WriteLine(String.Join("/n", duplicates));
                }
            
        }
    }
}
