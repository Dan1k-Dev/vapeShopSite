using DragonVapeShopAPI.Database;
using VapeShop.ClassesDb;

namespace DragonVapeShopAPI.Interfaces
{
    public interface IOnceVapesRepository
    {
        void Add(OnceVapes onces);
        IEnumerable<OnceVapes> GetAll();
        OnceVapes Find(string key);
        OnceVapes Remove(string key);
        void Update(OnceVapes onces);
    }
}
