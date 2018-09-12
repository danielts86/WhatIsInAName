using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows.Media;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class VariableWordNavigationViewModel : ViewModelBase
    {
        private readonly VariableWordNavigation _variableWordNavigation;

        public VariableWordNavigationViewModel(VariableWordNavigation variableWordNavigation)
        {
            _variableWordNavigation = variableWordNavigation;

            PrevCommand = new RelayCommand(Prev);
            NextCommand = new RelayCommand(Next);

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
            Current =_variableWordNavigation.Current;
            IsHasPrev = _variableWordNavigation.IsHasPrev;
            IsHasNext = _variableWordNavigation.IsHasNext;
        }
    }
}