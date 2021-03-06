using System;
using System.Text.RegularExpressions;

namespace TesteDiaADia
{
    public static class LearningRegex
    {
        public static void Execute()
        {
            // Define a regular expression for repeated words.
            Regex rx = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b",
              RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Define a test string.
            string text = "The the quick brown fox  fox jumps over the lazy dog dog.";

            // Find matches.
            MatchCollection matches = rx.Matches(text);

            // Report the number of matches found.
            Console.WriteLine("{0} matches found in:\n   {1}",
                              matches.Count,
                              text);

            // Report on each match.
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                Console.WriteLine("'{0}' repeated at positions {1} and {2}",
                                  groups["word"].Value, // Retorna a palavra que se repete
                                  groups[0].Index, // Primeira posição em que aparece
                                  groups[1].Index); // Segunda posição em que aparece
            }
        }
    }
}
