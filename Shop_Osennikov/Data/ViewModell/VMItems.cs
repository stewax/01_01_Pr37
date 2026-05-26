using Shop_Osennikov.Data.Models;

namespace Shop_Osennikov.Data.ViewModell
{
    public class VMItems
    {
        public IEnumerable<Items> Items { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
        public int SelectCategory = 0;
    }
}
