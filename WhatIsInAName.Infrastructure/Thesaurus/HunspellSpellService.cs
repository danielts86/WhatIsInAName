using NHunspell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace WhatIsInAName.Infrastructure.Thesaurus
{
    internal class HunspellSpellService : ISpellService
    {
        public HunspellSpellService()
        {
            var path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            Hunspell.NativeDllPath = path;
        }
        public List<string> GetWordSuggestions(string word)
        {
            try
            {
                using (var hunspell = new Hunspell("en_us.aff", "en_us.dic"))
                {
                    var suggestions = hunspell.Suggest(word);
                    suggestions.Remove(word); //Sometimes hunspell put the same search word in the suggestion
                    return suggestions;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}