using Shop_Osennikov.Data.Models;

namespace Shop_Osennikov.Data.Interfaces
{
    public interface ICategorys
    {
        IEnumerable<Categories> AllCategories { get; }
        public int Add(Categories category);
        public void Delete(int id);
        public void Update(Categories category);
    }
}
