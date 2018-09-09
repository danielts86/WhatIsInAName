using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WhatIsInAName.ViewModels
{
    public class SynonymsViewModel
    {
        public SynonymsViewModel()
        {
            Synonyms = new ObservableCollection<SynonymViewModel>();
            BrowseCommand = new RelayCommand(Browse);
        }

        public SynonymsViewModel(IEnumerable<SynonymViewModel> synonyms) : this()
        {
            Load(synonyms);
        }

        private void Load(IEnumerable<SynonymViewModel> synonyms)
        {
            foreach (var synonym in synonyms)
            {
                Synonyms.Add(synonym);
            }
        }

        public void Reload(IEnumerable<SynonymViewModel> synonyms)
        {
            Synonyms.Clear();
            Load(synonyms);
        }

        public ObservableCollection<SynonymViewModel> Synonyms { get; set; }

        public ICommand BrowseCommand { get; set; }
        private void Browse()
        {
            
        }

        //public event EventHandler<int> SynonymBrowsed;
        //private void OnSelectItemChanged()
        //{
        //    var handler = SynonymBrowsed;
        //    if (handler != null)
        //    {
        //        handler(this, );
        //    }
        //}
    }
}
