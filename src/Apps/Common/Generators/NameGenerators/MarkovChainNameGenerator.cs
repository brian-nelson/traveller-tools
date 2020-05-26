using System;
using System.Collections.Generic;

namespace TravellerUtils.Libraries.Common.Generators.NameGenerators
{
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    // Adapted from name_generator.js
    // written and released to the public domain by drow <drow@bin.sh>
    // http://creativecommons.org/publicdomain/zero/1.0/
    public class MarkovChainNameGenerator
    {
        private Dictionary<string, Dictionary<string, Token>> _chain;
        private Random _random;

        public MarkovChainNameGenerator(List<string> names)
        {
            _chain = ConstructChain(names);

            _random = new Random();
        }

        private Dictionary<string, Dictionary<string, Token>> ConstructChain(List<string> sourceNames)
        {
            var chain = new Dictionary<string, Dictionary<string, Token>>();

            for (int i = 0; i < sourceNames.Count; i++)
            {
                string fullName = sourceNames[i];
                var nameParts = fullName.Split(" ".ToCharArray());

                IncrementChain(chain, "parts", nameParts.Length.ToString());

                for (int j = 0; j < nameParts.Length; j++)
                {
                    var name = nameParts[j];
                    IncrementChain(chain, "name_len", name.Length.ToString());

                    var c = name.Substring(0, 1);
                    IncrementChain(chain, "initial", c);

                    var remaining = name.Substring(1);
                    var last_c = c;

                    while (remaining.Length > 0)
                    {
                        c = remaining.Substring(0, 1);
                        IncrementChain(chain, last_c, c);

                        remaining = remaining.Substring(1);
                        last_c = c;
                    }
                }
            }

            ScaleChain(chain);

            return chain;
        }

        private void ScaleChain(Dictionary<string, Dictionary<string, Token>> chain)
        {
            Dictionary<string, Token> tableLength = new Dictionary<string, Token>();

            foreach (var chainKey in chain.Keys)
            {
                tableLength.Add(chainKey, new Token() { Key = chainKey, Value = 0 });

                var tokenDictionary = chain[chainKey];

                foreach (var tokenKey in tokenDictionary.Keys)
                {
                    var token = tokenDictionary[tokenKey];

                    var count = tokenDictionary[tokenKey].Value;
                    var weighted = Math.Floor(Math.Pow(count, 1.3));

                    token.Value = Convert.ToInt32(weighted);

                    tableLength[chainKey].Value += Convert.ToInt32(weighted);
                }
            }

            chain["table_len"] = tableLength;
        }

        private void IncrementChain(Dictionary<string, Dictionary<string, Token>> chain, string key, string token)
        {
            Dictionary<string, Token> tokenDictionary;

            if (!chain.ContainsKey(key))
            {
                tokenDictionary = new Dictionary<string, Token>();

                chain.Add(key, tokenDictionary);
            }
            else
            {
                tokenDictionary = chain[key];
            }

            Token t = null;
            if (tokenDictionary.ContainsKey(token))
            {
                t = tokenDictionary[token];
            }

            if (t is null)
            {
                t = new Token {Key = token};

                tokenDictionary.Add(token, t);
            }

            t.Value++;
        }

        private string SelectLink(string key)
        {
            var tableLenDictionary = _chain["table_len"];

            if (!tableLenDictionary.ContainsKey(key))
            {
                return null;
            }

            var len = tableLenDictionary[key].Value;
            var idx = Convert.ToInt32(Math.Floor(_random.NextDouble() * len));

            var tokenDictionary = _chain[key];

            int t = 0;

            foreach (var tokenKey in tokenDictionary.Keys)
            {
                t += tokenDictionary[tokenKey].Value;

                if (idx < t)
                {
                    return tokenKey;
                }
            }

            return "-";
        }

        public string GenerateName()
        {
            var parts = Convert.ToInt32(SelectLink("parts"));
            List<string> nameParts = new List<string>();

            for (int i = 0; i < parts; i++)
            {
                var name_len = Convert.ToInt32(SelectLink("name_len"));

                string c = SelectLink("initial");
                string name = c;
                string last_c = c;

                while (name.Length < name_len)
                {
                    c = SelectLink(last_c);

                    if (c != null)
                    {
                        name += c;
                        last_c = c;
                    }
                    else
                    {
                        break;
                    }
                }

                nameParts.Add(name);
            }

            return string.Join(" ", nameParts);
        }

        public List<string> GenerateNames(int count)
        {
            List<string> output = new List<string>();

            for (int i = 0; i < count; i++)
            {
                output.Add(GenerateName());
            }

            return output;
        }
    }
}
