using DragonVapeShopAPI.Database;
using System.Collections.Concurrent;
using DragonVapeShopAPI.Interfaces;
using VapeShop.ClassesDb;

namespace DragonVapeShopAPI.ClassInterface
{
    public class ConsumablesRepository : IConsumableRepository
    {
        static ConcurrentDictionary<string, Consumables> _consumableCache =
            new ConcurrentDictionary<string, Consumables>();

        public ConsumablesRepository()
        {
            Add(new Consumables { ConsumableName = "Cons1" });
        }

        public IEnumerable<Consumables> GetAll()
        {
            return _consumableCache.Values;
        }

        public void Add(Consumables consumables)
        {
            consumables.ConsumableName = Guid.NewGuid().ToString();
            _consumableCache[consumables.ConsumableName] = consumables;
        }

        public Consumables Find(string key)
        {
            Consumables consumables;
            _consumableCache.TryGetValue(key, out consumables);
            return consumables;
        }

        public Consumables Remove(string key)
        {
            Consumables consumables;
            _consumableCache.TryRemove(key, out consumables);
            return consumables;
        }

        public void Update(Consumables consumables)
        {
            _consumableCache[consumables.ConsumableName] = consumables;
        }
    }
}
