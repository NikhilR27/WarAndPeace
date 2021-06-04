using System;
namespace WarAndPeace.Domain
{
    public class Word
    {
        public readonly string Text;
        public readonly int WordCount;

        public Word(string text, int wordCount)
        {
            Text = text;
            WordCount = wordCount;
        }
    }
}
