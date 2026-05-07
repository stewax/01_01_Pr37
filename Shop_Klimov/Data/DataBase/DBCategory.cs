using MySql.Data.MySqlClient;
using Shop_Klimov.Data.Common;
using Shop_Klimov.Data.Interfaces;
using Shop_Klimov.Data.Models;

namespace Shop_Klimov.Data.DataBase
{
    public class DBCategory : ICategorys
    {
        public IEnumerable<Categories> AllCategories
        {
            get
            {
                List<Categories> categories = new List<Categories>();
                MySqlConnection MySqlConnection = Connection.MySqlOpen();
                MySqlDataReader CategoriesData = Connection.MySqlQuery("SELECT * FROM Shop.Categorys ORDER BY `Name`;", MySqlConnection);

                while (CategoriesData.Read())
                {
                    categories.Add(new Categories()
                    {
                        Id = CategoriesData.IsDBNull(0) ? -1 : CategoriesData.GetInt32(0),
                        Name = CategoriesData.IsDBNull(1) ? null : CategoriesData.GetString(1),
                        Description = CategoriesData.IsDBNull(2) ? null : CategoriesData.GetString(2)
                    });
                }
                return categories;
            }
        }
    }
}
