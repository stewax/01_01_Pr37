using Shop_Klimov.Data.Models;

namespace Shop_Klimov.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Items> AllItems { get; }
    }
}
