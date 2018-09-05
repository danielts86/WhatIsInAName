using GalaSoft.MvvmLight;
using System.Collections.Generic;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class VariableViewModel : ViewModelBase
    {
        public VariableViewModel(List<VariableWord> variableWords)
        {
            VariableWords = new VariableWordsViewModel(variableWords);
            VariableWordNavigations = new VariableWordNavigationsViewModel(variableWords);
            VariableWordNavigations.SelectItemChanged += VariableWordNavigationsSelectItemChanged;
        }

        private void VariableWordNavigationsSelectItemChanged(object sender, int index)
        {
            VariableWords.SelectedItem = VariableWords.Items[index];
        }

        public VariableWordsViewModel VariableWords { get; set; }

        public VariableWordNavigationsViewModel VariableWordNavigations { get; set; }
    }
}