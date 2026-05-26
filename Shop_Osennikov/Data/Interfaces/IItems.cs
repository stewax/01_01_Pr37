using Shop_Osennikov.Data.Models;

namespace Shop_Osennikov.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Items> AllItems { get; }
        public int Add(Items item);
        public void Delete(int id);
        public void Update(Items item);
    }
}
