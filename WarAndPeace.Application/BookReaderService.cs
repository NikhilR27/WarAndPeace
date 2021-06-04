using System.Collections.Generic;
using WarAndPeace.Application.Interface;
using WarAndPeace.Infrastructure.Data.Interface;

namespace WarAndPeace.Application
{
    public class BookReaderService : IBookReaderService
    {
        private readonly IDataReader _dataReader;

        public BookReaderService(IDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public IList<KeyValuePair<string, int>> GetWords()
        {
            return _dataReader.GetBookWords();
        }

        public IList<KeyValuePair<string, int>> GetTopXUsedWords(int numberOfWords)
        {
            return _dataReader.GetBookWords(numberOfWords);
        }

        public IList<KeyValuePair<string, int>> GetTopXUsedWordsLongerThanYChars(int numberOfWords, int minWordLength)
        {
            return _dataReader.GetBookWords(x => x.Key.Length > minWordLength, numberOfWords);
        }
    }
}
