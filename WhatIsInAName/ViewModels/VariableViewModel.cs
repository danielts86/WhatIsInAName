using GalaSoft.MvvmLight;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class VariableViewModel : ViewModelBase
    {
        public VariableViewModel(Variable variable)
        {
            VariableWords = new VariableWordsViewModel(variable.VariableWords);
            VariableWordNavigations = new VariableWordNavigationsViewModel(variable.VariableWords);
            VariableWordNavigations.SelectItemChanged += VariableWordNavigationsSelectItemChanged;
        }

        private void VariableWordNavigationsSelectItemChanged(object sender, int index)
        {
            VariableWords.SelectedItem = VariableWords.Items[index];
        }

        private VariableWordsViewModel _variableWords;
        public VariableWordsViewModel VariableWords
        {
            get => _variableWords;
            set
            {
                _variableWords = value;
                RaisePropertyChanged();
            }
        }

        private VariableWordNavigationsViewModel _variableWordNavigations;
        public VariableWordNavigationsViewModel VariableWordNavigations
        {
            get => _variableWordNavigations;
            set
            {
                _variableWordNavigations = value;
                RaisePropertyChanged();
            }
        }
    }
}