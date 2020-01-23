using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Common
{
    public class RedisCache : ICache
    {
        ///<summary>
        ///连接redis
        ///</summary>
        public RedisCache()
        {
            Redis.Initialization();
        }
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        public void Add<T>(string key, T value)
        {
            Redis.Current.Set(key, value);
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <param name="cacheDurationInSeconds">过期时间</param>
        public void Add<T>(string key, T value, int cacheDurationInSeconds)
        {
            Redis.Current.Set(key, value, cacheDurationInSeconds);
        }

        /// <summary>
        ///缓存是否存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key</param>
        /// <returns></returns>
        public bool ContainsKey<T>(string key)
        {
            return Redis.Current.Exists(key);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return Redis.Current.Get<T>(key);
        }

        /// <summary>
        /// 获取所有的key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<string> GetAllKey<T>()
        {
            return Redis.Current.Keys("*");
        }

        /// <summary>
        /// 获取缓存，不存在就创建
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="create"></param>
        /// <param name="cacheDurationInSeconds"></param>
        /// <returns></returns>
        public T GetOrCreate<T>(string cacheKey, Func<T> create, int cacheDurationInSeconds = int.MaxValue)
        {
            if (ContainsKey<T>(cacheKey))
            {
                return Get<T>(cacheKey);
            }
            else
            {
                var result = create();
                Add(cacheKey, result, cacheDurationInSeconds);
                return result;
            }
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key</param>
        public void Remove<T>(string key)
        {
            Redis.Current.Del(key);
        }

        ///<summary>
        ///更新key的过期时间
        ///</summary>
        /// <param name="key">key</param>
        /// <param name="cacheDurationInSeconds">过期时间</param>
        public void Expire(string key, int cacheDurationInSeconds = int.MaxValue)
        {
            Redis.Current.Expire(key, cacheDurationInSeconds);
        }
    }
}
