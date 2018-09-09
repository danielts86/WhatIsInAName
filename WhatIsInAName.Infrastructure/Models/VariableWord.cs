namespace WhatIsInAName.Infrastructure.Models
{
    public class VariableWord
    {
        public VariableWord(string defualtWord, Word word)
        {
            DefualtWord = defualtWord;
            Word = word;
        }

        public string DefualtWord { get; private set; }

        public Word Word { get; private set; }
    }
}