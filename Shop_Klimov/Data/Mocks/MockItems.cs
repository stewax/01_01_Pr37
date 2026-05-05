using Shop_Klimov.Data.Interfaces;
using Shop_Klimov.Data.Models;

namespace Shop_Klimov.Data.Mocks
{
    public class MockItems : IItems
    {
        public ICategorys _category = new MockCaregorys();

        public IEnumerable<Items> AllItems
        {
            get
            {
                return new List<Items>()
                {
                    new Items
                    {
                        Id = 0,
                        Name = "DEXP MB-70",
                        Description = "Благодаря черному корпусу с лаконичным дизайном всё круто",
                        Img = "https://avatars.mds.yandex.net/get-mpic/12351018/2a00000192dd49c8c427748d259169171140/900x1200",
                        Price = 8499,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    },
                    new Items
                    {
                        Id = 7,
                        Name = "Samsung Galaxy Buds2 Pro",
                        Description = "Беспроводные наушники с активным шумоподавлением и звуком от AKG для погружения в музыку",
                        Img = "https://avatars.mds.yandex.net/get-mpic/5123789/2a00000193cd4ef5ab6789012cdef345678901b/900x1200",
                        Price = 14990,
                        Category = _category.AllCategories.Where(x => x.Id == 1).First()
                    },
                    new Items
                    {
                        Id = 8,
                        Name = "Apple iPad Air 5",
                        Description = "Мощный планшет с чипом M1, 10.9\" дисплеем Liquid Retina и поддержкой Apple Pencil 2-го поколения",
                        Img = "https://avatars.mds.yandex.net/get-mpic/4891256/2a00000192de5fa6bc7890123def456789012c/900x1200",
                        Price = 54990,
                        Category = _category.AllCategories.Where(x => x.Id == 2).First()
                    },
                    new Items
                    {
                        Id = 9,
                        Name = "Xiaomi Redmi Watch 3",
                        Description = "Умные часы с AMOLED-экраном, отслеживанием пульса, сна и более 100 спортивными режимами",
                        Img = "https://avatars.mds.yandex.net/get-mpic/6734512/2a00000191ef6ab7cd8901234ef567890123d/900x1200",
                        Price = 6499,
                        Category = _category.AllCategories.Where(x => x.Id == 3).First()
                    },
                    new Items
                    {
                        Id = 10,
                        Name = "Sony WH-1000XM5",
                        Description = "Флагманские беспроводные наушники с лучшим в классе шумоподавлением и до 30 часов автономной работы",
                        Img = "https://avatars.mds.yandex.net/get-mpic/3456789/2a00000190fa7bc8de9012345fa678901234e/900x1200",
                        Price = 29990,
                        Category = _category.AllCategories.Where(x => x.Id == 1).First()
                    }
                };
            }
        }
    }
}
