using Microsoft.AspNetCore.Mvc;
using Shop_Klimov.Data.Interfaces;
using Shop_Klimov.Data.ViewModell;

namespace Shop_Klimov.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategorys IAllCategorys;
        VMItems VMItems = new VMItems();

        public ItemsController(IItems IAllItems, ICategorys IAllCategorys)
        {
            this.IAllItems = IAllItems;
            this.IAllCategorys = IAllCategorys;
        }

        public ViewResult List(int id = 0)
        {
            ViewBag.Title = "Страница с предметами";

            VMItems.Items = IAllItems.AllItems;
            VMItems.Categories = IAllCategorys.AllCategories;
            VMItems.SelectCategory = id;

            return View(VMItems);
        }
    }
}
