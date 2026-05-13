using Microsoft.AspNetCore.Mvc;
using Shop_Klimov.Data.Interfaces;
using Shop_Klimov.Data.Models;
using Shop_Klimov.Data.ViewModell;

namespace Shop_Klimov.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IHostEnvironment hostingEnvironment;

        private IItems IAllItems;
        private ICategorys IAllCategorys;
        VMItems VMItems = new VMItems();

        public ItemsController(IItems IAllItems, ICategorys IAllCategorys, IHostEnvironment environment)
        {
            this.IAllItems = IAllItems;
            this.IAllCategorys = IAllCategorys;
            this.hostingEnvironment = environment;
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

        /// <summary>
        /// Метод добавления предмета
        /// </summary>
        /// <param name="name">Наименование предмета</param>
        /// <param name="description">Описание предмета</param>
        /// <param name="files">Изображение</param>
        /// <param name="price">Цена</param>
        /// <param name="idCategory">Код категории</param>
        /// <returns></returns>
        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int idCategory)
        {
            if (files != null)
            {
                var uploads = Path.Combine(hostingEnvironment.ContentRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            Items newItems = new Items();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = files.FileName;
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Categories() { Id = idCategory };

            int id = IAllItems.Add(newItems);

            return Redirect("/Items/Update?id=" + id);
        }
    }
}
