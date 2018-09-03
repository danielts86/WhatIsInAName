using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace WhatIsInAName.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            SearchCommand = new RelayCommand(Search);
            Variable = new VariableViewModel();
        }

        public ICommand SearchCommand { get; private set; }

        private string _userSearch;
        public string UserSearch { get => _userSearch;
            set
            {
                _userSearch = value;
                RaisePropertyChanged();
            }
        }

        public VariableViewModel Variable { get; set; }

        private void Search()
        {
            //var word = _dataRepository.Search(UserSearch);
            //
            //Word.Load(word);
        }
    }
}
