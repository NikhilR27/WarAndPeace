using System.Collections.Generic;

namespace WarAndPeace.Domain
{
    public class WordCollection
    {
        public readonly IEnumerable<Word> Words;
        public WordCollection( IEnumerable<Word> words)
        {
            Words = words;
        }        
    }

    public static class WordCollectionExtensions
    {
        public static void SortDescending(this WordCollection wordCollection)
        {
            //TODO
            //implement bubble sort
        }
    }
}
