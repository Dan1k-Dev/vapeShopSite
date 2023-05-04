using DragonVapeShopAPI.Database;
using VapeShop.ClassesDb;

namespace DragonVapeShopAPI.Interfaces
{
    public interface ILiquidsRepository
    {
        void Add(Liquids liquids);
        IEnumerable<Liquids> GetAll();
        Liquids Find(string key);
        Liquids Remove(string key);
        void Update(Liquids liquids);
    }
}
