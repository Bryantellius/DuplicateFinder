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

            using var reader = new StreamReader(files[files.Length - 1]);

            List<Contact> Leads = new List<Contact>();

            string[] values = { };
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                values = line.Split(',');

                Leads.Add(new Contact(values[1], values[0], values[2]));
            }

            //Leads duplicates
            Leads.getAllRepeated(z => new { z.Name, z.Email, z.Number })
            .ToList()
            .ForEach(z => Console.WriteLine("{0} \t {1} \t {2}", z.Name, z.Email, z.Number));
            Console.WriteLine("Done");
        }
    }

    public static class Extention
    {
        public static IEnumerable<Contact> getAllRepeated<Contact>(this IEnumerable<Contact> extList, Func<Contact, object> groupProps) where Contact : class
        {
            //Get all duplicate contacts
            return extList
                .GroupBy(groupProps)
                .Where(z => z.Count() > 1) //Filter only the distinct one
                .SelectMany(z => z); //All in where has to be returned
        }
    }
}
