using MySql.Data.MySqlClient;
using Shop_Klimov.Data.Common;
using Shop_Klimov.Data.Interfaces;
using Shop_Klimov.Data.Models;

namespace Shop_Klimov.Data.DataBase
{
    public class DBItems : IItems
    {
        public IEnumerable<Categories> Categories = new DBCategory().AllCategories;

        public IEnumerable<Items> AllItems
        {
            get
            {
                List<Items> items = new List<Items>();
                MySqlConnection connection = Connection.MySqlOpen();
                MySqlDataReader ItemsData = Connection.MySqlQuery("SELECT * FROM Shop.Items ORDER BY `Name`;", connection);

                while (ItemsData.Read())
                {
                    items.Add(new Items()
                    {
                        Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                        Name = ItemsData.IsDBNull(1) ? "" : ItemsData.GetString(1),
                        Description = ItemsData.IsDBNull(2) ? "" : ItemsData.GetString(2),
                        Img = ItemsData.IsDBNull(3) ? "" : ItemsData.GetString(3),
                        Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                        Category = ItemsData.IsDBNull(5) ? null : Categories.Where(x => x.Id == ItemsData.GetInt32(5)).First()
                    });
                }
                connection.Close();
                return items;
            }
        }
    }
}
