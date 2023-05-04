using DragonVapeShopAPI.Database;

namespace DragonVapeShopAPI.Interfaces
{
    public interface IVapesRepository
    {
        void Add(Vapess vapes);
        IEnumerable<Vapess> GetAll();
        Vapess Find(string key);
        Vapess Remove(string key);
        void Update(Vapess vapes);
    }
}
