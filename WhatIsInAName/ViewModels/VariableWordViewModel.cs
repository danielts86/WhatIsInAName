using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WhatIsInAName.Infrastructure;
using WhatIsInAName.Infrastructure.Data;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class VariableWordViewModel : ViewModelBase
    {
        private VariableWord _variableWord;
        private VariableWordNavigation _variableWordNavigation;
        private readonly IRepository _repository;

        public VariableWordViewModel(VariableWord variableWord, IRepository dataRepository)
        {
            _variableWord = variableWord;
            _repository = dataRepository;

            Value = _variableWord.SingularValue;

            _variableWordNavigation = new VariableWordNavigation(_variableWord);
            VariableWordNavigation = new VariableWordNavigationViewModel(_variableWordNavigation, _repository);
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
    }
}
