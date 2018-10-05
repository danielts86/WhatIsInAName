namespace WhatIsInAName.Infrastructure.Thesaurus
{
    public enum LetterCaseStyles
    {
        None = 0,
        /// <summary>
        /// "Example: TheQuickBrownFoxJumpsOverTheLazyDog"
        /// </summary>
        PascalCase = 1,
        /// <summary>
        /// "Example: theQuickBrownFoxJumpsOverTheLazyDog"
        /// </summary>
        CamelCase = 2,
        /// <summary>
        /// Example: "The_quick_brown_fox_jumps_over_the_lazy_dog"
        /// </summary>
        SnakeCase = 3,
        /// <summary>
        /// Example: "The-quick-brown-fox-jumps-over-the-lazy-dog"
        /// </summary>
        KebabCase = 4,
    }
}