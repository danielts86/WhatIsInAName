using System.Collections.Generic;
using WhatIsInAName.Infrastructure.Entities;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.Infrastructure.Data
{
    internal interface IDataProvider
    {
        IEnumerable<VariableWord> GetVariableWords(List<string> words);

        IEnumerable<Synonym> GetSynonyms(int wordId);
    }
}