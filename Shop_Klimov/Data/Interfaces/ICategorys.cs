using Shop_Klimov.Data.Models;

namespace Shop_Klimov.Data.Interfaces
{
    public interface ICategorys
    {
        IEnumerable<Categories> AllCategories { get; }
    }
}
