using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows.Input;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            SearchCommand = new RelayCommand(Search);

            var v = new VariableWord
            {
                Word = new Word
                {
                    SingularValue = "CurrentValue",
                    Synonyms = new List<Synonym>
                        {
                            new Synonym { Value = "s333331", Similarity = 10 },
                            new Synonym { Value = "s34643643643", Similarity = 10 },
                            new Synonym { Value = "s64364361", Similarity = 10 },
                            new Synonym { Value = "411241241s3", Similarity = 10 },
                            new Synonym { Value = "s43734731", Similarity = 10 },
                            new Synonym { Value = "s3hgfhdfh", Similarity = 10 },
                            new Synonym { Value = "faaaaaaaaaaaas1", Similarity = 10 },
                            new Synonym { Value = "faaaaaaaaaaaas3", Similarity = 10 },
                            new Synonym { Value = "faaaaaaaaaaaas1", Similarity = 10 },
                            new Synonym { Value = "faaaaaaaaaaaas3", Similarity = 10 },
                            new Synonym { Value = "faaa", Similarity = 10 },
                        }
                }
            };

            var v1 = new VariableWord { Word = new Word { SingularValue = "CurrentValue" } };

            Variable = new VariableViewModel(new List<VariableWord>(new[] { v, v1 }));
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

        public VariableViewModel Variable { get; set; }

        private void Search()
        {
            //var word = _dataRepository.Search(UserSearch);
            //
            //Word.Load(word);
        }
    }
}
