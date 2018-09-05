using System.Collections.Generic;
using System.Collections.ObjectModel;
using WhatIsInAName.Infrastructure.Models;
using GalaSoft.MvvmLight;

namespace WhatIsInAName.ViewModels
{
    public class VariableWordsViewModel : ViewModelBase
    {
        public VariableWordsViewModel(List<VariableWord> variableWords)
        {
            Items = new ObservableCollection<VariableWordViewModel>();
            foreach (var variableWord in variableWords)
            {
                var variableWordViewModel = new VariableWordViewModel(variableWord);
                Items.Add(variableWordViewModel);
            }
            SelectedItem = Items[0];
        }

        public ObservableCollection<VariableWordViewModel> Items { get; set; }

        private VariableWordViewModel _selectedItem;
        public VariableWordViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != null)
                {
                    _selectedItem.IsSelected = false;
                }

                _selectedItem = value;
                _selectedItem.IsSelected = true;
                RaisePropertyChanged();
            }
        }
    }
}
