using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WhatIsInAName.Infrastructure.Thesaurus
{
    internal class Formatting
    {
        public static LetterCaseStyles GetLetterCaseStyle(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Contains(" "))
            {
                return LetterCaseStyles.None;
            }

            if (input.Contains("_"))
            {
                return LetterCaseStyles.SnakeCase;
            }

            if (input.Contains("-"))
            {
                return LetterCaseStyles.KebabCase;
            }

            if (char.IsUpper(input[0]))
            {
                return LetterCaseStyles.PascalCase;
            }

            return LetterCaseStyles.CamelCase;
        }

        public static List<string> SplitInputByLetterCaseStyle(string input, LetterCaseStyles letterCaseStyle)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new List<string>();
            }

            switch (letterCaseStyle)
            {
                case LetterCaseStyles.PascalCase:
                    return SplitPascalOrCamelCase(input);
                case LetterCaseStyles.CamelCase:
                    var result = SplitPascalOrCamelCase(input);
                    var firstWord = result[0];
                    var firstChar = firstWord[0];
                    firstChar = char.ToLower(firstChar);
                    firstWord = firstChar + firstWord.Remove(0, 1);
                    result[0] = firstWord;
                    return result;
                case LetterCaseStyles.SnakeCase:
                    return SplitUnderscore(input);
                case LetterCaseStyles.KebabCase:
                    return SplitDash(input);
                default:
                    var splits = input.Split(new[] { ' ' });
                    return splits.ToList();
            }
        }

        private static List<string> SplitPascalOrCamelCase(string variable)
        {
            var pascalCaseWordPartsRegex = new Regex(@"[\p{Lu}]?[\p{Ll}]+|[0-9]+[\p{Ll}]*|[\p{Lu}]+(?=[\p{Lu}][\p{Ll}]|[0-9]|\b)|[\p{Lo}]+",
                RegexOptions.IgnorePatternWhitespace | RegexOptions.ExplicitCapture | RegexOptions.Compiled);
            var result = string.Join(" ", pascalCaseWordPartsRegex
                                        .Matches(variable).Cast<Match>()
                                        .Select(match => match.Value.ToCharArray().All(char.IsUpper) &&
                                            (match.Value.Length > 1 || (match.Index > 0 && variable[match.Index - 1] == ' ') || match.Value == "I")
                                            ? match.Value
                                            : match.Value.ToLower()));
            if (result.Length == 0)
            {
                return new List<string>();
            }

            result = char.ToUpper(result[0]) + result.Substring(1, result.Length - 1);

            var split = result.Split(new[] { ' ' });
            return split.ToList();
        }

        private static List<string> SplitUnderscore(string variable)
        {
            var split = variable.Split(new[] { '_' });
            return split.ToList();
        }

        private static List<string> SplitDash(string variable)
        {
            var split = variable.Split(new[] { '-' });
            return split.ToList();
        }
    }
}