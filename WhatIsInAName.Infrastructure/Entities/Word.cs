using System.Collections.Generic;

namespace WhatIsInAName.Infrastructure.Entities
{
    public class Word
    {
        public Word()
        {
            Synonyms = new List<Synonym>();
        }

        public int Id { get; set; }

        public string PluralValue { get; set; }

        public string SingularValue { get; set; }

        public string Definition { get; set; }

        public List<Synonym> Synonyms { get; set; }
    }
}