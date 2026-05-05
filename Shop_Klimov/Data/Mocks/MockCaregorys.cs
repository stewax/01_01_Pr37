using Shop_Klimov.Data.Interfaces;
using Shop_Klimov.Data.Models;

namespace Shop_Klimov.Data.Mocks
{
    public class MockCaregorys : ICategorys
    {
        public IEnumerable<Categories> AllCategories
        {
            get
            {
                return new List<Categories>
                {
                    new Categories
                    {
                        Id = 0,
                        Name = "Компьютерная периферия",
                        Description = "Мыши, клавиатуры, веб-камеры и другие аксессуары для ПК"
                    },
                    new Categories
                    {
                        Id = 1,
                        Name = "Аудиотехника",
                        Description = "Беспроводные и проводные наушники, колонки, гарнитуры"
                    },
                    new Categories
                    {
                        Id = 2,
                        Name = "Планшеты и ноутбуки",
                        Description = "Мобильные компьютеры для работы, учёбы и развлечений"
                    },
                    new Categories
                    {
                        Id = 3,
                        Name = "Умные часы и фитнес-браслеты",
                        Description = "Носимые устройства для отслеживания активности и уведомлений"
                    }
                };
            }
        }
    }
}
