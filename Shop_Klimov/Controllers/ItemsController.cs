using Microsoft.AspNetCore.Mvc;
using Shop_Klimov.Data.Interfaces;
using Shop_Klimov.Data.Models;
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

        public ViewResult List(int id = 0, string sort = "")
        {
            ViewBag.Title = "Страница с предметами";

            VMItems.Items = IAllItems.AllItems;
            VMItems.Categories = IAllCategorys.AllCategories;
            VMItems.SelectCategory = id;

            if (sort == "asc")
            {
                VMItems.Items = VMItems.Items.OrderBy(i => i.Price);
            }
            else if (sort == "desc")
            {
                VMItems.Items = VMItems.Items.OrderByDescending(i => i.Price);
            }

            return View(VMItems);
        }

        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Categories> Categories = IAllCategorys.AllCategories;

            return View(Categories);
        }
    }
}
