using System.Collections.Generic;

namespace WhatIsInAName.Infrastructure.Models
{
    public class Word
    {
        public int Id { get; set; }

        public string PluralValue { get; set; }

        public string SingularValue { get; set; }

        public string Definition { get; set; }

        public List<Synonym> Synonyms { get; set; }
    }
}