using DragonVapeShopAPI.Database;
using VapeShop.ClassesDb;

namespace DragonVapeShopAPI.Interfaces
{
    public interface IConsumableRepository
    {
        void Add(Consumables consumables);
        IEnumerable<Consumables> GetAll();
        Consumables Find(string key);
        Consumables Remove(string key);
        void Update(Consumables consumables);
    }
}
