using System.Collections.Generic;
using WhatIsInAName.Infrastructure.Thesaurus;

namespace WhatIsInAName.Infrastructure.Models
{
    public class Variable
    {
        public Variable()
        {
            VariableWords = new List<VariableWord>();
        }

        public List<VariableWord> VariableWords { get; set; }

        public LetterCaseStyles LetterCaseStyle { get; set; }
    }
}