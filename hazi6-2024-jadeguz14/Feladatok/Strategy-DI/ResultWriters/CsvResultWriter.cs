using Lab_Extensibility.AnonymizerAlgorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Extensibility.ResultWriters
{
    public class CsvResultWriter : IResultWriter
    {

        private readonly string _outputFileName;


        public CsvResultWriter(string outputFileName)
        {
            _outputFileName = outputFileName;
        }

        public void Write(List<Person> persons)
        {
            string outFileName = Path.ChangeExtension(_outputFileName, "processed.txt");
            using (StreamWriter writer = new StreamWriter(outFileName))
            {
                foreach (Person p in persons)
                    writer.WriteLine($"{p.FirstName}; {p.LastName}; {p.State}; {p.City}; {p.Age}; {p.Weight}; {p.Decease}");
            }

            Console.WriteLine($"Output file generated ({outFileName})");
        }

    }
}
