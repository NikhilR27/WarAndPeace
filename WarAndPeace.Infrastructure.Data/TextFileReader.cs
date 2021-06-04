using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WarAndPeace.Infrastructure.Data.Interface;

namespace WarAndPeace.Infrastructure.Data
{
    public class TextFileReader : IDataReader
    {
        // Keep the data in memory for the duration of the Program
        private static IList<KeyValuePair<string, int>> words;

        public TextFileReader(string source)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            Initialize(source);
        }

        // Load all the data into memory
        private static void Initialize(string source)
        {
            List<string> allWords = ReadData(source);
            words = ProcessWords(allWords);
        }

        // IDataReader interface implementation
        public IList<KeyValuePair<string, int>> GetBookWords(int? numberOfWords) => numberOfWords.HasValue ? words.Take((int)numberOfWords).ToList() : words;

        public IList<KeyValuePair<string, int>> GetBookWords(Func<KeyValuePair<string, int>, bool> filter, int? numberOfWords)
        {
            return numberOfWords.HasValue ? words.Where(filter).Take((int)numberOfWords).ToList() : words.Where(filter).ToList(); 
        }

        // Private methods
        private static List<string> ReadData(string source)
        {
            var list = new List<string>();
            string contents;
            using (var streamReader = new StreamReader(source))
            {
                contents = CleanText(streamReader.ReadToEnd());
                list = contents.Split(' ', StringSplitOptions.TrimEntries).ToList();
            }

            return list;
        }

        private static string CleanText(string dirtyText)
        {
            // Perform any string clean up here
            // Replace all symbols, except apostrophes, with a space
            // Lower invariant to count accurately
            // Regex is around 8 times slower than string.Replace

            char[] symbolsToRemove = new char[] { ' ', ';', ':', '/', '.','"', '*', '\n', '\r', '\t'};
            string text = dirtyText;

            foreach (var symbol in symbolsToRemove)
            {
                //Replace the symbols with a space
                text = text.Replace(symbol, ' ');
            }
            return text.ToLower();
        }

        private static IList<KeyValuePair<string, int>> ProcessWords(List<string> allWords)
        {
            Dictionary<string, int> words = new();
            foreach (var word in allWords)
            {
                words[word] = words.TryGetValue(word, out int value) ? ++value : 1;
            }

            // Remove empty space
            _ = words.Remove(" ");
            _ = words.Remove(string.Empty);

            return SortDictionary(words.ToList());
        }

        private static IList<KeyValuePair<string, int>> SortDictionary(IList<KeyValuePair<string, int>> list)
        {
            return list.OrderByDescending(l => l.Value).Take(100).ToList();
        }
    }
}
