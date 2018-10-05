using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows.Input;
using WhatIsInAName.Infrastructure;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IRepository _repository;

        public MainViewModel(IRepository repository)
        {
            _repository = repository;

            SearchCommand = new RelayCommand(Search);
        }

        public ICommand SearchCommand { get; private set; }

        private string _userSearch;
        public string UserSearch
        {
            get => _userSearch;
            set
            {
                _userSearch = value;
                RaisePropertyChanged();
            }
        }

        private VariableViewModel _variable;
        public VariableViewModel Variable
        {
            get => _variable;
            set
            {
                _variable = value;
                RaisePropertyChanged();
            }
        }

        private void Search()
        {
            var variable = _repository.GetVariable(UserSearch);
            Variable = new VariableViewModel(variable, _repository);
        }
    }
}
