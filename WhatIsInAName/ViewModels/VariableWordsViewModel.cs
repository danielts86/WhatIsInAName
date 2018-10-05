using System.Collections.Generic;
using System.Collections.ObjectModel;
using WhatIsInAName.Infrastructure.Models;
using GalaSoft.MvvmLight;
using WhatIsInAName.Infrastructure;
using System.Linq;

namespace WhatIsInAName.ViewModels
{
    public class VariableWordsViewModel : ViewModelBase
    {
        private readonly IRepository _repository;

        public VariableWordsViewModel(List<VariableWord> variableWords, IRepository dataRepository)
        {
            _repository = dataRepository;
            Items = new ObservableCollection<VariableWordViewModel>();
            foreach (var variableWord in variableWords)
            {
                var variableWordViewModel = new VariableWordViewModel(variableWord, _repository);
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

        public string GetTransfromVariable()
        {
            var transfromVariable = string.Join("", Items.Select(w => w.VariableWordNavigation.Current.SingularValue));
            return transfromVariable;
        }
    }
}
