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
            using var reader = new StreamReader(@"C:\Users\brbry_000\Downloads\test.csv");
            {
                List<string> Email = new List<string>();
                List<string> Name = new List<string>();
                List<string> Number = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    Email.Add(values[0]);
                    Name.Add(values[1]);
                    Number.Add(values[2]);
                }

                HashSet<string> hashset = new HashSet<string>();
                IEnumerable<string> duplicates = Email.Where(e => !hashset.Add(e));

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
}
