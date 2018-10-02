using System.Collections.Generic;

namespace WhatIsInAName.Infrastructure.Models
{
    public class Variable
    {
        public Variable()
        {
            VariableWords = new List<VariableWord>();
        }

        public List<VariableWord> VariableWords { get; set; }
    }
}