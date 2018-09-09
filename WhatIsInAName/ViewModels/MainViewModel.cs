using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows.Input;
using WhatIsInAName.Infrastructure.Data;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataRepository _dataRepository;

        public MainViewModel(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;

            SearchCommand = new RelayCommand(Search);

            //var v = new VariableWord("CurrentValue",
            //    new Word
            //    {
            //        SingularValue = "CurrentValue",
            //        Synonyms = new List<Synonym>
            //            {
            //                new Synonym { Value = "s333331", Similarity = 10 },
            //                new Synonym { Value = "s34643643643", Similarity = 10 },
            //                new Synonym { Value = "s64364361", Similarity = 10 },
            //                new Synonym { Value = "411241241s3", Similarity = 10 },
            //                new Synonym { Value = "s43734731", Similarity = 10 },
            //                new Synonym { Value = "s3hgfhdfh", Similarity = 10 },
            //                new Synonym { Value = "faaaaaaaaaaaas1", Similarity = 10 },
            //                new Synonym { Value = "faaaaaaaaaaaas3", Similarity = 10 },
            //                new Synonym { Value = "faaaaaaaaaaaas1", Similarity = 10 },
            //                new Synonym { Value = "faaaaaaaaaaaas3", Similarity = 10 },
            //                new Synonym { Value = "faaa", Similarity = 10 },
            //            }
            //    }

            //);

            //var v1 = new VariableWord("CurrentValue", new Word { SingularValue = "CurrentValue" });

            //var variable = new Variable();
            //variable.VariableWords.Add(v);
            //variable.VariableWords.Add(v1);
            //Variable = new VariableViewModel(variable);
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
            var variable = _dataRepository.Search(UserSearch);
            Variable = new VariableViewModel(variable);
        }
    }
}
