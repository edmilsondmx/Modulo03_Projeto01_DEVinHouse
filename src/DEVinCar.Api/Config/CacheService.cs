using DEVinCer.Domain.Interfaces.Service;
using Microsoft.Extensions.Caching.Memory;

namespace DEVinCar.Api.Config;

public class CacheService<TEntity>
{
    private readonly IMemoryCache _cache;
    private string _baseKey;
    private TimeSpan _expirationTime;

    public CacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public void Config(string baseKey, TimeSpan expirationTime)
    {
        _baseKey = baseKey;
        _expirationTime = expirationTime;
    }

    public string Mountkey(string parametro)
    {
        return $"{_baseKey}: {parametro}";
    }

    public TEntity Set(string parametro, TEntity entity)
    {
        return _cache.Set<TEntity>(Mountkey(parametro), entity, _expirationTime);
    }

    public bool TryGetValue(string parametro, out TEntity entity)
    {
        return _cache.TryGetValue<TEntity>( Mountkey(parametro), out entity );
    }

    public void Remove(string parametro)
    {
        _cache.Remove(Mountkey(parametro));
    }
}
