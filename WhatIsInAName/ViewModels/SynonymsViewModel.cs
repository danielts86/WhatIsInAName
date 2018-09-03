using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WhatIsInAName.ViewModels
{
    public class SynonymsViewModel
    {
        public SynonymsViewModel()
        {
            Synonyms = new ObservableCollection<SynonymViewModel>();
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
    }
}
