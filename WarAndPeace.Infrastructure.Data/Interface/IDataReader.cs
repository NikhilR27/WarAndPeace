using System;
using System.Collections.Generic;

namespace WarAndPeace.Infrastructure.Data.Interface
{
    public interface IDataReader
    {
        IList<KeyValuePair<string, int>> GetBookWords(int? take = null);
        IList<KeyValuePair<string, int>> GetBookWords(Func<KeyValuePair<string, int>, bool> filter, int? take);
    }
}
