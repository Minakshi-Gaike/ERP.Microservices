using System.Reflection.Metadata;
using System.Runtime.Caching;

namespace CachingInApis.Services
{
    public class CacheService<TEntity> : ICacheService<TEntity> where TEntity : class
    {
        ObjectCache cache=MemoryCache.Default;
        public List<TEntity> GetCacheData(string key)
        {
            List<TEntity> lst = (List<TEntity>)cache.Get(key);
            return lst;
        }

        public TEntity GetSingleObjectCacheData(string key)
        {
            TEntity entity = (TEntity)cache.Get(key);
            return entity;
        }

        public object RemoveCacheData(string key)
        {
            return cache.Remove(key);
        }

        public bool SetCacheData(string key, List<TEntity> entity, DateTimeOffset dateTimeOffset)
        {
            if (!string.IsNullOrEmpty(key))
            {
                cache.Set(key, entity, dateTimeOffset);
            return true;

            }
            else
            {
                return false;
            }
        }

        public bool SetSingleObjectCacheData(string key, TEntity entity, DateTimeOffset dateTimeOffset)
        {
            if (!string.IsNullOrEmpty(key))
            {
                cache.Set(key, entity, dateTimeOffset);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
