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
                MySqlConnection.Close();
                return categories;
            }
        }

        public int Add(Categories category)
        {
            MySqlConnection MySqlConnection = Connection.MySqlOpen();

            Connection.MySqlQuery(
                $"INSERT INTO `Categorys` (`Name`, `Description`) VALUES ('{category.Name}', '{category.Description}');",
                MySqlConnection);
            MySqlConnection.Close();

            int IdCategory = -1;

            MySqlConnection = Connection.MySqlOpen();
            MySqlDataReader mySqlDataReaderCategory = Connection.MySqlQuery(
                $"SELECT `Id` FROM `Categorys` WHERE `Name` = '{category.Name}' AND `Description` = '{category.Description}';",
                MySqlConnection);

            if (mySqlDataReaderCategory.HasRows)
            {
                mySqlDataReaderCategory.Read();
                IdCategory = mySqlDataReaderCategory.GetInt32(0);
            }

            MySqlConnection.Clone();

            return IdCategory;
        }

        public void Delete(int id)
        {
            MySqlConnection MySqlConnection = Connection.MySqlOpen();

            Connection.MySqlQuery(
                $"DELETE FROM `Categorys` WHERE `Id` = {id};",
                MySqlConnection);
            MySqlConnection.Close();
        }

        public void Update(Categories category)
        {
            MySqlConnection MySqlConnection = Connection.MySqlOpen();

            Connection.MySqlQuery(
                $"UPDATE `Categorys` SET `Name` = '{category.Name}', `Description` = '{category.Description}' WHERE `Id` = {category.Id};",
                MySqlConnection);
            MySqlConnection.Close();
        }
    }
}
