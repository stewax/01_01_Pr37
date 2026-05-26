using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Shop_Osennikov.Data.Interfaces;
using Shop_Osennikov.Data.Models;

namespace Shop_Osennikov.Controllers
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

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Title = "Добавление категории";
            return View();
        }

        [HttpGet]
        public ViewResult Update(int id)
        {
            Data.Models.Categories item = IAllCategorys.AllCategories.FirstOrDefault(x => x.Id == id);
            return View(item);
        }

        /// <summary>
        /// Метод добавления категории
        /// </summary>
        /// <param name="name">Наименование категории</param>
        /// <param name="description">Описание категории</param>
        /// <returns></returns>
        [HttpPost]
        public RedirectResult Add(string name, string description)
        {
            Data.Models.Categories newCategory = new Data.Models.Categories();

            newCategory.Name = name;
            newCategory.Description = description;

            int id = IAllCategorys.Add(newCategory);

            return Redirect("/Categories/Update?id=" + id);
        }

        /// <summary>
        /// Метод удаления категории
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public RedirectResult Delete(int id)
        {
            IAllCategorys.Delete(id);
            return Redirect("/Categories/Categories");
        }

        /// <summary>
        /// Метод обновления категории
        /// </summary>
        /// <param name="name">Наименование категории</param>
        /// <param name="description">Описание категории</param>
        /// <returns></returns>
        [HttpPost]
        public RedirectResult Update(int id, string name, string description)
        {
            Data.Models.Categories category = new Data.Models.Categories()
            {
                Id = id,
                Name = name,
                Description = description
            };

            IAllCategorys.Update(category);
            return Redirect("/Categories/Categories");
        }
    }
}
