using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Input;
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
            CopyToClipBoardTransfromVaraibleCommand = new RelayCommand(CopyToClipBoardTransfromVaraible);
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

        public ICommand CopyToClipBoardTransfromVaraibleCommand { get; private set; }
        private void CopyToClipBoardTransfromVaraible()
        {
            var transfromVariable = VariableWords.GetTransfromVariable();
            Clipboard.SetText(transfromVariable);
        }

    }
}