using System.Collections.Generic;

namespace WarAndPeace.Application.Interface
{
    public interface IBookReaderService
    {
        IList<KeyValuePair<string, int>> GetWords();
        IList<KeyValuePair<string, int>> GetTopXUsedWords(int numberOfWords);
        IList<KeyValuePair<string, int>> GetTopXUsedWordsLongerThanYChars(int numberOfWords, int minWordLength);
    }
}
