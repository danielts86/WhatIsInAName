using System.Collections.Generic;
using System.Collections.ObjectModel;
using WhatIsInAName.Infrastructure.Models;
using GalaSoft.MvvmLight;
using WhatIsInAName.Infrastructure.Data;

namespace WhatIsInAName.ViewModels
{
    public class VariableWordsViewModel : ViewModelBase
    {
        private readonly IDataRepository _dataRepository;

        public VariableWordsViewModel(List<VariableWord> variableWords, IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
            Items = new ObservableCollection<VariableWordViewModel>();
            foreach (var variableWord in variableWords)
            {
                var variableWordViewModel = new VariableWordViewModel(variableWord, _dataRepository);
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
