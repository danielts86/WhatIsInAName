﻿using GalaSoft.MvvmLight;
using System.Linq;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class VariableWordViewModel : ViewModelBase
    {
        private VariableWord _variableWord;

        public VariableWordViewModel(VariableWord variableWord)
        {
            _variableWord = variableWord;

            Value = _variableWord.Word.SingularValue;

            var synonyms = variableWord.Word.Synonyms;
            if (synonyms == null)
            {
                Synonyms = new SynonymsViewModel();
            }
            else
            {
                Synonyms = new SynonymsViewModel(synonyms.Select(s => new SynonymViewModel(s)));
            }
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

        public SynonymsViewModel Synonyms { get; set; }
    }
}
