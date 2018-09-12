using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class SynonymsViewModel
    {
        public SynonymsViewModel()
        {
            Synonyms = new ObservableCollection<SynonymViewModel>();
            BrowseCommand = new RelayCommand<SynonymViewModel>(Browse);
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
        private void Browse(SynonymViewModel synonym)
        {
            if (synonym == null)
            {
                return;
            }
            OnSynonymChosened(synonym.Model);
        }

        public event EventHandler<Synonym> SynonymChosen;
        private void OnSynonymChosened(Synonym synonym)
        {
            var handler = SynonymChosen;
            if (handler != null)
            {
               handler(this, synonym);
            }
        }
    }
}
