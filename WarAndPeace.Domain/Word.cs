using System;
namespace WarAndPeace.Domain
{
    public class Word
    {
        public readonly string Text;
        public readonly int Count;

        public Word(string text, int count)
        {
            Text = text;
            Count = count;
        }
    }
}
