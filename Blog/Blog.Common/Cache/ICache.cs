using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Common
{
    public interface ICache
    {
        void Add<T>(string key, T value);
        void Add<T>(string key, T value, int cacheDurationInSeconds);
        bool ContainsKey<V>(string key);
        T Get<T>(string key);
        IEnumerable<string> GetAllKey<T>();
        T GetOrCreate<T>(string cacheKey, Func<T> create, int cacheDurationInSeconds = int.MaxValue);
        void Remove<T>(string key);
    }
}
