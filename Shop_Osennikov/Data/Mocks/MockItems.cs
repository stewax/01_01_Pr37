using MySql.Data.MySqlClient;
using Shop_Osennikov.Data.Common;
using Shop_Osennikov.Data.Interfaces;
using Shop_Osennikov.Data.Models;

namespace Shop_Osennikov.Data.Mocks
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
                        Id = 1,
                        Name = "Samsung Galaxy Buds2 Pro",
                        Description = "Беспроводные наушники с активным шумоподавлением и звуком от AKG для погружения в музыку",
                        Img = "https://c.dns-shop.ru/thumb/st4/fit/500/500/9c643728619d17df359aef323dea8024/ebe0f042a9d882b01e333cd0581fc57c90ba6dd2a540b1a0f8640ef8d47b9c76.jpg.webp",
                        Price = 14990,
                        Category = _category.AllCategories.Where(x => x.Id == 1).First()
                    },
                    new Items
                    {
                        Id = 2,
                        Name = "Apple iPad Air 5",
                        Description = "Мощный планшет с чипом M1, 10.9\" дисплеем Liquid Retina и поддержкой Apple Pencil 2-го поколения",
                        Img = "https://avatars.mds.yandex.net/get-mpic/5214322/2a00000195cbea632ab02e7e55e19889f9f1/180x240",
                        Price = 54990,
                        Category = _category.AllCategories.Where(x => x.Id == 2).First()
                    },
                    new Items
                    {
                        Id = 3,
                        Name = "Xiaomi Redmi Watch 3",
                        Description = "Умные часы с AMOLED-экраном, отслеживанием пульса, сна и более 100 спортивными режимами",
                        Img = "https://avatars.mds.yandex.net/get-mpic/14794092/2a0000019be71514b251745ed3dec5458636/180x240_multiply",
                        Price = 6499,
                        Category = _category.AllCategories.Where(x => x.Id == 3).First()
                    },
                    new Items
                    {
                        Id = 4,
                        Name = "Sony WH-1000XM5",
                        Description = "Флагманские беспроводные наушники с лучшим в классе шумоподавлением и до 30 часов автономной работы",
                        Img = "https://avatars.mds.yandex.net/get-mpic/15246975/2a00000197acc3cb3aad6d78985be7165582/180x240_multiply",
                        Price = 29990,
                        Category = _category.AllCategories.Where(x => x.Id == 1).First()
                    }
                };
            }
        }

        public int Add(Items item)
        {
            MySqlConnection MySqlConnection = Connection.MySqlOpen();

            Connection.MySqlQuery(
                $"INSERT INTO `Items` (`Name`, `Description`, `Img`, `Price`, `IdCategory`) VALUES (`{item.Name}`, `{item.Description}`, `{item.Img}`, `{item.Price}`, `{item.Category.Id}`);",
                MySqlConnection);
            MySqlConnection.Close();

            int IdItem = -1;

            MySqlConnection = Connection.MySqlOpen();
            MySqlDataReader mySqlDataReaderItem = Connection.MySqlQuery(
                $"SELECT `Id` FROM `Items` WHERE `Name` = '{item.Name}' AND `Description` = '{item.Description}' AND `Price` = {item.Price} AND `IdCategory` = {item.Category.Id};",
                MySqlConnection);

            if (mySqlDataReaderItem.HasRows)
            {
                mySqlDataReaderItem.Read();
                IdItem = mySqlDataReaderItem.GetInt32(0);
            }

            MySqlConnection.Clone();
            return IdItem;
        }

        public void Delete(int id)
        {
            MySqlConnection MySqlConnection = Connection.MySqlOpen();

            Connection.MySqlQuery(
                $"DELETE FROM `Items` WHERE `Id` = {id};",
                MySqlConnection);
            MySqlConnection.Close();
        }

        public void Update(Items item)
        {
            MySqlConnection MySqlConnection = Connection.MySqlOpen();

            Connection.MySqlQuery(
                $"UPDATE `Items` SET `Name` = '{item.Name}', `Description` = '{item.Description}', `Img` = '{item.Img}', `Price` = {item.Price}, `IdCategory` = {item.Category.Id} WHERE `Id` = {item.Id};",
                MySqlConnection);
            MySqlConnection.Close();
        }
    }
}
