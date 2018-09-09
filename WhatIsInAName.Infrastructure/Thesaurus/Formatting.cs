using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WhatIsInAName.Infrastructure.Thesaurus
{
    public class Formatting
    {
        public static List<string> SperateVariable(string variable)
        {
            if (string.IsNullOrEmpty(variable))
            {
                return new List<string>();
            }

            if (variable.Contains(" "))
            {
                throw new InvalidOperationException("Could not sperate varible if in contains spaces");
            }

            var letterCaseStyle = GetLetterCaseStyle(variable);
            var result = FormatVariableByLetterCaseStyle(variable, letterCaseStyle);

            return result;
        }

        private static LetterCaseStyles GetLetterCaseStyle(string variable)
        {
            if (variable.Contains("_"))
            {
                return LetterCaseStyles.SnakeCase;
            }

            if (variable.Contains("-"))
            {
                return LetterCaseStyles.KebabCase;
            }

            if (char.IsUpper(variable[0]))
            {
                return LetterCaseStyles.PascalCase;
            }

            return LetterCaseStyles.CamelCase;
        }

        private static List<string> FormatVariableByLetterCaseStyle(string variable, LetterCaseStyles letterCaseStyle)
        {
            var format = new List<string>();
            switch (letterCaseStyle)
            {
                case LetterCaseStyles.PascalCase:
                    return FormatPascalOrCamelCase(variable);
                case LetterCaseStyles.CamelCase:
                    var result = FormatPascalOrCamelCase(variable);
                    var firstWord = result[0];
                    var firstChar = firstWord[0];
                    firstChar = char.ToLower(firstChar);
                    firstWord = firstChar + firstWord.Remove(0, 1);
                    result[0] = firstWord;
                    return result;
                case LetterCaseStyles.SnakeCase:
                    return FormatUnderscore(variable);
                case LetterCaseStyles.KebabCase:
                    return FormatDash(variable);
            }

            return format;
        }

        private static List<string> FormatPascalOrCamelCase(string variable)
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

        private static List<string> FormatUnderscore(string variable)
        {
            var split = variable.Split(new[] { '_' });
            return split.ToList();
        }

        private static List<string> FormatDash(string variable)
        {
            var split = variable.Split(new[] { '-' });
            return split.ToList();
        }
    }
}
