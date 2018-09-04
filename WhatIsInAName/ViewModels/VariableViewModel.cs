using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class VariableViewModel : ViewModelBase
    {
        public VariableViewModel()
        {
            VariableWordNavigations = new ObservableCollection<VariableWordNavigationViewModel>();

            VariableWordNavigation v = new VariableWordNavigation(
                new VariableWord
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
                });
            v.AddRange(new[] {
                new VariableWord { Word = new Word { SingularValue = "Next1" } },
                new VariableWord { Word = new Word { SingularValue = "Next2" } } });


            var navigation = new VariableWordNavigationViewModel(v);

            VariableWordNavigation v1 = new VariableWordNavigation(new VariableWord { Word = new Word { SingularValue = "CurrentValue" } });
            v1.AddRange(new[] { new VariableWord { Word = new Word { SingularValue = "Next1Next1Next1Next1Next1" } }, new VariableWord { Word = new Word { SingularValue = "Next2" } } });


            var navigation1 = new VariableWordNavigationViewModel(v1);

            VariableWordNavigations.Add(navigation);
            VariableWordNavigations.Add(navigation1);

            SelectedItem = VariableWordNavigations[0];
        }

        public ObservableCollection<VariableWordNavigationViewModel> VariableWordNavigations { get; set; }

        private VariableWordNavigationViewModel _selectedItem;
        public VariableWordNavigationViewModel SelectedItem
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