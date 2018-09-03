namespace WhatIsInAName.Infrastructure.Models
{
    public class Synonym
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public int WordId { get; set; }

        public int Similarity { get; set; }

        public int Rank { get; set; }
    }
}