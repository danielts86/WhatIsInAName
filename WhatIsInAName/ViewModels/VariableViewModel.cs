using GalaSoft.MvvmLight;
using WhatIsInAName.Infrastructure.Data;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class VariableViewModel : ViewModelBase
    {
        private readonly IDataRepository _dataRepository;

        public VariableViewModel(Variable variable, IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
            VariableWords = new VariableWordsViewModel(variable.VariableWords, _dataRepository);    
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
    }
}