using System.Collections.Generic;

namespace WhatIsInAName.Infrastructure.Thesaurus
{
    internal interface ISpellService
    {
        List<string> GetWordSuggestions(string word);
    }
}