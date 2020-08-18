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

            using var reader = new StreamReader(files[^1]);

            List<Contact> Leads = new List<Contact>();
            List<Contact> IncompleteLeads = new List<Contact>();

            string[] values = { };
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                values = line.Split(',');

                Leads.Add(new Contact(values[1], values[0], values[2]));
            }

            Console.WriteLine($"{Leads.Count - 1} contacts\n");

            //Leads duplicates
            List<Contact> DuplicateLeads = Leads.GetAllRepeated(c => new { c.Name, c.Email })
            .ToList();


            if (DuplicateLeads.Count > 0)
            {
                DuplicateLeads.ForEach(c => Console.WriteLine($"{c.Name} \t {c.Email} \t {c.Number}"));

                System.Console.WriteLine($"\n{DuplicateLeads.Count()} duplicates");
            }
            else
            {
                Console.WriteLine("0 duplicates found");
            }



            Console.WriteLine("\nDone");
        }
    }

    public static class Extension
    {
        public static IEnumerable<Contact> GetAllRepeated<Contact>(this IEnumerable<Contact> extList, Func<Contact, object> groupProps)
        {
            //Get all duplicate contacts
            extList = extList
                .GroupBy(groupProps)
                .Where(c => c.Count() > 1) //Filter only the distinct one
                .SelectMany(c => c); //One of each sequence returned
            return extList;
        }
    }
}
