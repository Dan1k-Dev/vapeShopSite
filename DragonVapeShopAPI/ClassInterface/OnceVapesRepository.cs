using DragonVapeShopAPI.Database;
using DragonVapeShopAPI.Interfaces;
using System.Collections.Concurrent;
using VapeShop.ClassesDb;

namespace DragonVapeShopAPI.ClassInterface
{
    public class OnceVapesRepository : IOnceVapesRepository
    {
        static ConcurrentDictionary<string, OnceVapes> _oncesCache =
            new ConcurrentDictionary<string, OnceVapes>();

        public OnceVapesRepository()
        {
            Add(new OnceVapes { OnceVapeName = "Once1" });
        }

        public IEnumerable<OnceVapes> GetAll()
        {
            return _oncesCache.Values;
        }

        public void Add(OnceVapes onces)
        {
            onces.OnceVapeName = Guid.NewGuid().ToString();
            _oncesCache[onces.OnceVapeName] = onces;
        }

        public OnceVapes Find(string key)
        {
            OnceVapes onces;
            _oncesCache.TryGetValue(key, out onces);
            return onces;
        }

        public OnceVapes Remove(string key)
        {
            OnceVapes onces;
            _oncesCache.TryRemove(key, out onces);
            return onces;
        }

        public void Update(OnceVapes onces)
        {
            _oncesCache[onces.OnceVapeName] = onces;
        }
    }
}
