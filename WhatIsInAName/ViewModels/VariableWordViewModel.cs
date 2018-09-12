using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WhatIsInAName.Infrastructure.Data;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class VariableWordViewModel : ViewModelBase
    {
        private VariableWord _variableWord;
        private VariableWordNavigation _variableWordNavigation;
        private readonly IDataRepository _dataRepository;

        public VariableWordViewModel(VariableWord variableWord, IDataRepository dataRepository)
        {
            _variableWord = variableWord;
            _dataRepository= dataRepository;

            Value = _variableWord.Word.SingularValue;

            _variableWordNavigation = new VariableWordNavigation(_variableWord);
            VariableWordNavigation = new VariableWordNavigationViewModel(_variableWordNavigation);

            var synonyms = variableWord.Word.Synonyms;
            if (synonyms == null)
            {
                Synonyms = new SynonymsViewModel();
            }
            else
            {
                Synonyms = new SynonymsViewModel(synonyms.Select(s => new SynonymViewModel(s)));
            }
            Synonyms.SynonymChosen += SynonymChosend;
        }

        private string _value;
        public string Value
        {
            get => _value;
            private set
            {
                _value = value;
                RaisePropertyChanged();
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                RaisePropertyChanged();
            }
        }

        public VariableWordNavigationViewModel VariableWordNavigation { get; set; }

        public SynonymsViewModel Synonyms { get; set; }

        private void SynonymChosend(object sender, Synonym synonym)
        {
            var newVariableWord = new VariableWord("", new Word
            {
                                
            });
            
            if (!synonym.WordId.HasValue)
            {
                return;
            }

            List<Synonym> synonyms = _dataRepository.GetSynonyms(synonym.WordId.Value).ToList();

        }
    }
}
