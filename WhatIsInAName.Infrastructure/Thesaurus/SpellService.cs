using NHunspell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace WhatIsInAName.Infrastructure.Thesaurus
{
    public class SpellService
    {
        public SpellService()
        {
            var path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            Hunspell.NativeDllPath = path;
        }
        public void Get()
        {
            try
            {
                using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
                {
                    Console.WriteLine("Make suggestions for the misspelled word 'Recommendation'");
                    List<string> suggestions = hunspell.Suggest("Recommendation");
                    Console.WriteLine("There are " + suggestions.Count.ToString() + " suggestions");
                    foreach (string suggestion in suggestions)
                    {
                        Console.WriteLine("Suggestion is: " + suggestion);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
