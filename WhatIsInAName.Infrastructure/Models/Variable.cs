using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
