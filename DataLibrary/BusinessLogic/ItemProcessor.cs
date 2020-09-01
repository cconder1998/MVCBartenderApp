using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class ItemProcessor
    {
        public static int CreateItem(int drinkId, string name, string description, string ingredients, float price)
        {
            ItemModel data = new ItemModel
            {
                DrinkId = drinkId,
                Name = name,
                Description = description,
                Ingredients = ingredients,
                Price = price
            };

            string sql = @"insert into dbo.MenuTable (DrinkId, Name, Description, Ingredients, Price)
                            values (@DrinkId, @Name, @Description, @Ingredients, @Price);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<ItemModel> LoadItems()
        {
            string sql = @"select Id, DrinkId, Name, Description, Ingredients, Price 
                            from dbo.MenuTable;";

            return SqlDataAccess.LoadData<ItemModel>(sql);
        }

        public static int RemoveItem(int drinkId)
        {
            ItemModel data = new ItemModel
            {
                DrinkId = drinkId
            };

            string sql = @"delete from dbo.MenuTable WHERE DrinkId=@DrinkId;";

            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
