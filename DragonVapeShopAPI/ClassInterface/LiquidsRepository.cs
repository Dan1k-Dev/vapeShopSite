using DragonVapeShopAPI.Database;
using DragonVapeShopAPI.Interfaces;
using System.Collections.Concurrent;
using VapeShop.ClassesDb;

namespace DragonVapeShopAPI.ClassInterface
{
    public class LiquidsRepository : ILiquidsRepository
    {
        static ConcurrentDictionary<string, Liquids> _liquidsCache =
            new ConcurrentDictionary<string, Liquids>();

        public LiquidsRepository()
        {
            Add(new Liquids { LiquidName = "liquid1" });
        }

        public IEnumerable<Liquids> GetAll()
        {
            return _liquidsCache.Values;
        }

        public void Add(Liquids vapes)
        {
            vapes.LiquidName = Guid.NewGuid().ToString();
            _liquidsCache[vapes.LiquidName] = vapes;
        }

        public Liquids Find(string key)
        {
            Liquids liquids;
            _liquidsCache.TryGetValue(key, out liquids);
            return liquids;
        }

        public Liquids Remove(string key)
        {
            Liquids liquids;
            _liquidsCache.TryRemove(key, out liquids);
            return liquids;
        }

        public void Update(Liquids liquids)
        {
            _liquidsCache[liquids.LiquidName] = liquids;
        }
    }
}
