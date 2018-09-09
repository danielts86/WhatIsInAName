using System.Collections.Generic;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.Infrastructure.Data
{
    public interface IDataRepository
    {
        Variable Search(string input);
    }
}