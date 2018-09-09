namespace WhatIsInAName.Infrastructure.Thesaurus
{
    enum LetterCaseStyles
    {
        /// <summary>
        /// "Example: TheQuickBrownFoxJumpsOverTheLazyDog"
        /// </summary>
        PascalCase,
        /// <summary>
        /// "Example: theQuickBrownFoxJumpsOverTheLazyDog"
        /// </summary>
        CamelCase,
        /// <summary>
        /// Example: "The_quick_brown_fox_jumps_over_the_lazy_dog"
        /// </summary>
        SnakeCase,
        /// <summary>
        /// Example: "The-quick-brown-fox-jumps-over-the-lazy-dog"
        /// </summary>
        KebabCase,
    }
}