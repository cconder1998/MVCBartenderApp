using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class OrderProcessor
    {
        public static int CreateOrder(int id, string name, string description, string ingredients, float price)
        {
            OrderModel data = new OrderModel
            {
                Id = id,
                Name = name,
                Description = description,
                Ingredients = ingredients,
                Price = price
            };

            string sql = @"insert into dbo.OrderQueue (Id, Name, Description, Ingredients, Price)
                            values (@Id, @Name, @Description, @Ingredients, @Price);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<OrderModel> LoadOrder()
        {
            string sql = @"select Id, Name, Description, Ingredients, Price 
                            from dbo.OrderQueue;";

            return SqlDataAccess.LoadData<OrderModel>(sql);
        }

        public static int CompleteOrder(int orderId)
        {
            OrderModel data = new OrderModel
            {
                Id = orderId
            };

            string sql = @"delete from dbo.OrderQueue WHERE Id=@Id;";

            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
