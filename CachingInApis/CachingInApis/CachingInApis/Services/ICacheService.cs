namespace CachingInApis.Services
{
    public interface ICacheService <TEntity> where TEntity : class
    {
        bool SetCacheData(string key, List<TEntity> entity, DateTimeOffset dateTimeOffset);
        bool SetSingleObjectCacheData(string key, TEntity  entity, DateTimeOffset dateTimeOffset);
        List<TEntity> GetCacheData(string key);
        TEntity GetSingleObjectCacheData(string key);
        object RemoveCacheData(string key);
    }
}
