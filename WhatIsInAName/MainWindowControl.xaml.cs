namespace WhatIsInAName
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using WhatIsInAName.Infrastructure;
    using WhatIsInAName.ViewModels;

    public partial class MainWindowControl : UserControl
    {
        private readonly IRepository _repository;

        public MainWindowControl()
        {
            _repository = new Repository();

            this.InitializeComponent();

            var m = new MainViewModel(_repository);
            DataContext = m;
        }
    }
}