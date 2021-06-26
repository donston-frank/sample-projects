using System.Linq;
using System.Text;
using System;
using System.Text.RegularExpressions;

namespace MyRegExApp
{
    public static class RegExClassExtn
    {
        public static string BuildNewSentance(this string text)
        {
            if(string.IsNullOrEmpty(text)) throw new ArgumentNullException(nameof(text));

            StringBuilder strBuilder = new StringBuilder();

            var words = Regex.Split(text, @"\W+");
            var separators = Regex.Split(text, @"[a-zA-Z]+");

            if(text.Length > 0 && separators.Length > 0 && text.IndexOf(separators.FirstOrDefault()) == 0)
            {
                strBuilder.Append(separators[0]);
            }

            int i = 1;
            foreach (var match in words)
            {
                if (Regex.Split(match, @"\d+").Length > 0)
                    match.BuildAlphaNumericWord(strBuilder, separators, ref i);

                else
                {
                    match.BuilNewWord(strBuilder, separators, ref i);
                }

            }
            return strBuilder.ToString();
        }

        private static void BuildAlphaNumericWord(this string numericStr, StringBuilder builder, string[] separators, ref int index)
        {
            var words = Regex.Split(numericStr, @"\d+");

            foreach (var match in words)
            {
                match.BuilNewWord(builder, separators, ref index);
            }
        }

        private static void BuilNewWord(this string word, StringBuilder builder, string[] separators, ref int index)
        {
            if (string.IsNullOrEmpty(word)) return; 

            if (word.Contains("_"))
            {
                var splitWords = word.Split('_', System.StringSplitOptions.None);
                int i = 0;
                foreach(string splitStr in splitWords)
                {
                    if (!string.IsNullOrEmpty(splitStr))
                    {
                        splitStr.BuilNewWord(builder, separators, ref index);
                    }
                    if (++i == splitWords.Length) return;
                }    
            }

            if (word.Length > 2)
            {
                builder.Append(word.FirstOrDefault());
                builder.Append(word.Substring(1, word.Length - 2).Distinct().Count());
                builder.Append(word.LastOrDefault());
            }
            else
            {
                builder.Append(word);
            }

            builder.Append(separators[index++]);
        }
    }
}
