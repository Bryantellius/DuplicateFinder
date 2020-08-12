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

            using var reader = new StreamReader(files[^1]);

            List<Contact> Leads = new List<Contact>();

            string[] values = { };
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                values = line.Split(',');

                Leads.Add(new Contact(values[1], values[0], values[2]));
            }

            //Leads duplicates
            Leads = Leads.GetAllRepeated(c => new { c.Name, c.Email, c.Number })
            .ToList();

            if(Leads.Count > 0)
            {
                Leads.ForEach(c => Console.WriteLine($"{c.Name} \t {c.Email} \t {c.Number}"));
            } else
            {
                Console.WriteLine("0 duplicates found");
            }

            

            Console.WriteLine("\nDone");
        }
    }

    public static class Extention
    {
        public static IEnumerable<Contact> GetAllRepeated<Contact>(this IEnumerable<Contact> extList, Func<Contact, object> groupProps)
        {
            //Get all duplicate contacts
            return extList
                .GroupBy(groupProps)
                .Where(c => c.Count() > 1) //Filter only the distinct one
                .SelectMany(c => c); //All in where has to be returned
        }
    }
}
