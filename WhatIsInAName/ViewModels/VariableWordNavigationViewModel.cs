using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using WhatIsInAName.Infrastructure.Data;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class VariableWordNavigationViewModel : ViewModelBase
    {
        private readonly VariableWordNavigation _variableWordNavigation;
        private readonly IDataRepository _dataRepository;

        public VariableWordNavigationViewModel(VariableWordNavigation variableWordNavigation, IDataRepository dataRepository)
        {
            _variableWordNavigation = variableWordNavigation;
            _dataRepository = dataRepository;

            PrevCommand = new RelayCommand(Prev);
            NextCommand = new RelayCommand(Next);

            var synonyms = _variableWordNavigation.Current.Synonyms;
            if (synonyms == null)
            {
                Synonyms = new SynonymsViewModel();
            }
            else
            {
                Synonyms = new SynonymsViewModel(synonyms.Select(s => new SynonymViewModel(s)));
            }
            Synonyms.SynonymChosen += SynonymChosend;

            Navigatie();

            Color = new SolidColorBrush(Colors.Blue);
        }

        private VariableWord _current;
        public VariableWord Current
        {
            get => _current;
            set
            {
                _current = value;
                RaisePropertyChanged();
            }
        }

        public ICommand PrevCommand { get; private set; }

        public ICommand NextCommand { get; private set; }

        private bool _isHasPrev;
        public bool IsHasPrev
        {
            get => _isHasPrev;
            set
            {
                _isHasPrev = value;
                RaisePropertyChanged();
            }
        }

        private bool _isHasNext;
        public bool IsHasNext
        {
            get => _isHasNext;
            set
            {
                _isHasNext = value;
                RaisePropertyChanged();
            }
        }

        private bool _isFocused;
        public bool IsFocused
        {
            get => _isFocused;
            set
            {
                _isFocused = value;
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

        public SolidColorBrush Color
        {
            get => _color;
            set
            {
                _color = value;
                RaisePropertyChanged();
            }
        }
        private SolidColorBrush _color;

        private void Prev()
        {
            _variableWordNavigation.Prev();
            Navigatie();
        }

        private void Next()
        {
            _variableWordNavigation.Next();
            Navigatie();
        }

        private void Navigatie()
        {
            Current = _variableWordNavigation.Current;
            IsHasPrev = _variableWordNavigation.IsHasPrev;
            IsHasNext = _variableWordNavigation.IsHasNext;
        }

        private void SynonymChosend(object sender, Synonym synonym)
        {
            var newVariableWord = new VariableWord("")
            {
                Id = synonym.WordId.HasValue
                        ? synonym.WordId.Value
                        : 0,
                SingularValue = synonym.Value,
            };

            _variableWordNavigation.Add(newVariableWord);
            _variableWordNavigation.Next();
            Navigatie();

            if (!synonym.WordId.HasValue)
            {
                return;
            }

            var synonyms = _dataRepository.GetSynonyms(synonym.WordId.Value);
            if (synonym != null)
            {
                Synonyms.Reload(synonyms.Select(s => new SynonymViewModel(s)));
            }

        }
    }
}