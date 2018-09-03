using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class VariableViewModel : ViewModelBase
    {
        public VariableViewModel()
        {
            VariableWordNavigations = new ObservableCollection<VariableWordNavigationViewModel>();

            VariableWordNavigation v = new VariableWordNavigation(new VariableWord { Word = new Word { Value = "CurrentValue" } });
            v.AddRange(new[] { new VariableWord { Word = new Word { Value = "Next1" } }, new VariableWord { Word = new Word { Value = "Next2" } } });


            var navigation = new VariableWordNavigationViewModel(v);

            VariableWordNavigation v1 = new VariableWordNavigation(new VariableWord { Word = new Word { Value = "CurrentValue" } });
            v1.AddRange(new[] { new VariableWord { Word = new Word { Value = "Next1Next1Next1Next1Next1" } }, new VariableWord { Word = new Word { Value = "Next2" } } });


            var navigation1 = new VariableWordNavigationViewModel(v1);

            VariableWordNavigations.Add(navigation);
            VariableWordNavigations.Add(navigation1);
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
