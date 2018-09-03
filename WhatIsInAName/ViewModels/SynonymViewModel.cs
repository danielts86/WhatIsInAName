using GalaSoft.MvvmLight;
using System.Windows.Media;
using WhatIsInAName.Infrastructure.Models;

namespace WhatIsInAName.ViewModels
{
    public class SynonymViewModel : ViewModelBase
    {
        private readonly Synonym _synonym;
        public SynonymViewModel(Synonym synonym)
        {
            _synonym = synonym;
            Value = _synonym.Value;
        }

        private string _value;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                RaisePropertyChanged();
            }
        }

        public SolidColorBrush BackgroundColor => SimilarityToColor();

        private SolidColorBrush SimilarityToColor()
        {
            switch (_synonym.Similarity)
            {
                default: return new SolidColorBrush(Colors.Green);
            }
        }
    }
}
