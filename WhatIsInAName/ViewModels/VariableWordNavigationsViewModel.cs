﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using WhatIsInAName.Infrastructure.Models;
using GalaSoft.MvvmLight;
using System;

namespace WhatIsInAName.ViewModels
{
    public class VariableWordNavigationsViewModel : ViewModelBase
    {
        public VariableWordNavigationsViewModel(VariableWord variableWord)
        {
            //Items = new ObservableCollection<VariableWordNavigationViewModel>();
            //var variableWordNavigation = new VariableWordNavigation(variableWord);
            //var variableWordNavigationViewModel = new VariableWordNavigationViewModel(variableWordNavigation);
            //Items.Add(variableWordNavigationViewModel);
            //SelectedItem = Items[0];
        }

        public event EventHandler<int> SelectItemChanged;
        private void OnSelectItemChanged()
        {
            var handler = SelectItemChanged;
            if (handler != null)
            {
                handler(this, Items.IndexOf(SelectedItem));
            }
        }

        public ObservableCollection<VariableWordNavigationViewModel> Items { get; set; }

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
                if (_selectedItem != null)
                {
                    _selectedItem.IsSelected = true;
                    OnSelectItemChanged();
                }

                RaisePropertyChanged();
            }
        }
    }
}