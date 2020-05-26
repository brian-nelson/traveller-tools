using System;
using System.Collections.Generic;
using System.Linq;
using TravellerUtils.Libraries.Common.Generators.NameGenerators;

namespace TravellerUtils
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> names = NameReader.LoadNames("../../../../../Resources/StarNames.txt");

            var nameGenerator = new MarkovChainNameGenerator(names.ToList());

            var generated = nameGenerator.GenerateNames(100);

            foreach (string name in generated)
            {
                Console.WriteLine(name);
            }
        }
    }
}
