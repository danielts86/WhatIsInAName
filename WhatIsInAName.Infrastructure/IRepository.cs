using System.Collections.Generic;
using WhatIsInAName.Infrastructure.Entities;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.Infrastructure
{
    public interface IRepository
    {
        Variable GetVariable(string input);
        IEnumerable<Synonym> GetSynonyms(int wordId);
    }
}