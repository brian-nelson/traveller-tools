using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TravellerUtils.Libraries.Common.Generators.NameGenerators
{
    public static class NameReader
    {
        public static List<string> LoadNames(string filename)
        {
            //Dictionary to remove duplicates
            Dictionary<string, string> names = new Dictionary<string, string>();

            IEnumerable<string> temp = File.ReadAllLines(filename);

            foreach (var line in temp)
            {
                string trimmedLine = line.Trim();

                //Ignore comment lines
                if (trimmedLine.Length > 0
                    && !trimmedLine.StartsWith("#"))
                {
                    if (!names.ContainsKey(trimmedLine))
                    {
                        names.Add(trimmedLine, trimmedLine);
                    }
                }
            }

            return names.Keys.ToList();
        }
    }
}
