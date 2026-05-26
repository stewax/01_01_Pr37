using MySql.Data.MySqlClient;
using Shop_Osennikov.Data.Common;
using Shop_Osennikov.Data.Interfaces;
using Shop_Osennikov.Data.Models;

namespace Shop_Osennikov.Data.DataBase
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

        public int Add(Items item)
        {
            MySqlConnection MySqlConnection = Connection.MySqlOpen();

            Connection.MySqlQuery(
                $"INSERT INTO `Items` (`Name`, `Description`, `Img`, `Price`, `IdCategory`) VALUES ('{item.Name}', '{item.Description}', '{item.Img}', {item.Price}, {item.Category.Id});",
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
