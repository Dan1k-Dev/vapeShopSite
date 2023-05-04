using System.Collections.Concurrent;
using DragonVapeShopAPI.Database;
using DragonVapeShopAPI.Interfaces;

namespace DragonVapeShopAPI.ClassInterface
{
    public class VapesRepository : IVapesRepository
    {
        static ConcurrentDictionary<string, Vapess> _vapessCache =
            new ConcurrentDictionary<string, Vapess>();

        public VapesRepository()
        {
            Add(new Vapess { VapeName = "Vape1" });
        }

        public IEnumerable<Vapess> GetAll()
        {
            return _vapessCache.Values;
        }

        public void Add(Vapess vapes)
        {
            vapes.VapeName = Guid.NewGuid().ToString();
            _vapessCache[vapes.VapeName] = vapes;
        }

        public Vapess Find(string key)
        {
            Vapess vapes;
            _vapessCache.TryGetValue(key, out vapes);
            return vapes;
        }

        public Vapess Remove(string key)
        {
            Vapess vapes;
            _vapessCache.TryRemove(key, out vapes);
            return vapes;
        }

        public void Update(Vapess vapes)
        {
            _vapessCache[vapes.VapeName] = vapes;
        }
    }
}
