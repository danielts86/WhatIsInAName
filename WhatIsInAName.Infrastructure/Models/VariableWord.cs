namespace WhatIsInAName.Infrastructure.Models
{
    public class VariableWord : Word
    {
        public VariableWord(string defualtWord) : base()
        {
            DefualtWord = defualtWord;
        }

        public string DefualtWord { get; private set; }
    }
}