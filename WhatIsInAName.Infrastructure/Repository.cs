using System;
using System.Collections.Generic;
using System.Linq;
using WhatIsInAName.Infrastructure.Data;
using WhatIsInAName.Infrastructure.Entities;
using WhatIsInAName.Infrastructure.Models;
using WhatIsInAName.Infrastructure.Thesaurus;

namespace WhatIsInAName.Infrastructure
{
    public class Repository : IRepository
    {
        private readonly IDataProvider _dataProvider;
        private readonly ISpellService _spellService;

        public Repository()
        {
            _dataProvider = new SqlDataProvider();
            _spellService = new HunspellSpellService();
        }

        public Variable GetVariable(string input)
        {
            var inputLetterCaseStyle = Formatting.GetLetterCaseStyle(input);
            var words = Formatting.SplitInputByLetterCaseStyle(input, inputLetterCaseStyle);
            try
            {
                var variableWords = _dataProvider.GetVariableWords(words);
                var variable = new Variable
                {
                    LetterCaseStyle = inputLetterCaseStyle,
                    VariableWords = variableWords.ToList(),
                };
                return variable;
            }
            catch (Exception)
            {
                foreach (var word in words)
                {
                    var wordSuggestions = _spellService.GetWordSuggestions(word);
                    
                }
                
            }
            return null;
        }

        public IEnumerable<Synonym> GetSynonyms(int wordId)
        {
           return  _dataProvider.GetSynonyms(wordId);
        }
    }
}