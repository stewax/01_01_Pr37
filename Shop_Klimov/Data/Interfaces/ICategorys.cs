using Shop_Klimov.Data.Models;

namespace Shop_Klimov.Data.Interfaces
{
    public interface ICategorys
    {
        IEnumerable<Categories> AllCategories { get; }
        public int Add(Categories category);
        public void Delete(int id);
        public void Update(Categories category);
    }
}
