using Microsoft.AspNetCore.Mvc;
using Shop_Klimov.Data.Interfaces;

namespace Shop_Klimov.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategorys IAllCategorys;
        private IItems IAllItems;

        public CategoriesController(ICategorys IAllCategorys, IItems IAllItems)
        {
            this.IAllCategorys = IAllCategorys;
            this.IAllItems = IAllItems;
        }

        public ViewResult Categories()
        {
            ViewBag.Title = "Страница с категориями";

            var categories = IAllCategorys.AllCategories;
            return View(categories);
        }
    }
}
