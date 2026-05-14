using MySql.Data.MySqlClient;
using Shop_Klimov.Data.Common;
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

        public int Add(Categories category)
        {
            MySqlConnection MySqlConnection = Connection.MySqlOpen();

            Connection.MySqlQuery(
                $"INSERT INTO `categories` (`Name`, `Description`) VALUES ('{category.Name}', '{category.Description}');",
                MySqlConnection);
            MySqlConnection.Close();

            int IdCategory = -1;

            MySqlConnection = Connection.MySqlOpen();
            MySqlDataReader mySqlDataReaderCategory = Connection.MySqlQuery(
                $"SELECT `Id` FROM `categories` WHERE `Name` = '{category.Name}' AND `Description` = '{category.Description}';",
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
                $"DELETE FROM `categories` WHERE `Id` = {id};",
                MySqlConnection);
            MySqlConnection.Close();
        }

        public void Update(Categories category)
        {
            MySqlConnection MySqlConnection = Connection.MySqlOpen();

            Connection.MySqlQuery(
                $"UPDATE `categories` SET `Name` = '{category.Name}', `Description` = '{category.Description}' WHERE `Id` = {category.Id};",
                MySqlConnection);
            MySqlConnection.Close();
        }
    }
}
