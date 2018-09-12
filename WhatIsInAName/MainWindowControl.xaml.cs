namespace WhatIsInAName
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using WhatIsInAName.Infrastructure.Data;
    using WhatIsInAName.ViewModels;

    public partial class MainWindowControl : UserControl
    {
        private readonly IDataRepository _dataRepository;

        public MainWindowControl()
        {
            _dataRepository = new SqlDataRepository();
            //var r = s.Search(new System.Collections.Generic.List<string> { "process" });

            this.InitializeComponent();

            var m = new MainViewModel(_dataRepository);
            DataContext = m;
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "MainWindow");
        }
    }
}