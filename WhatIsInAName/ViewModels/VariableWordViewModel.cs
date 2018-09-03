using GalaSoft.MvvmLight;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class VariableWordViewModel : ViewModelBase
    {
        private VariableWord _variableWord;
        public VariableWordViewModel(VariableWord variableWord)
        {
            _variableWord = variableWord;

            Value = _variableWord.Word.Value;
        }

        private string _value;
        public string Value
        {
            get
            {
                return _value;
            }
            private set
            {
                _value = value;
                RaisePropertyChanged();
            }
        }
    }
}
