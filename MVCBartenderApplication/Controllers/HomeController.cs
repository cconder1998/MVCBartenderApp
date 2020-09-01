using MVCBartenderApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLogic.ItemProcessor;
using static DataLibrary.BusinessLogic.OrderProcessor;

namespace MVCBartenderApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Menu";

            var data = LoadItems();
            List<MenuItemModel> items = new List<MenuItemModel>();

            foreach (var row in data)
            {
                items.Add(new MenuItemModel
                {
                    DrinkId = row.DrinkId,
                    Name = row.Name,
                    Description = row.Description,
                    Ingredients = row.Ingredients,
                    Price = row.Price
                });
            }

            return View(items);
        }
        
        public ActionResult PlaceOrder(OrderQueueModel model)
        {
            var data = LoadOrder();
            int Id = 1;
            for (int i = 0; i < data.Count; i++)
            {
                DataLibrary.Models.OrderModel row = data[i];
                Id = row.Id + 1;
            }
            
            CreateOrder(Id,
                           model.Name,
                           model.Description,
                           model.Ingredients,
                           model.Price);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(MenuItemModel model)
        {
            RemoveItem(model.DrinkId);
            return RedirectToAction("BartenderMenu");
        }

        public ActionResult Complete(OrderQueueModel model)
        {
            CompleteOrder(model.Id);
            return RedirectToAction("Queue");
        }

        public ActionResult BartenderMenu()
        {
            ViewBag.Message = "Bartender Menu";

            var data = LoadItems();
            List<MenuItemModel> items = new List<MenuItemModel>();

            foreach (var row in data)
            {
                items.Add(new MenuItemModel
                {
                    DrinkId = row.DrinkId,
                    Name = row.Name,
                    Description = row.Description,
                    Ingredients = row.Ingredients,
                    Price = row.Price
                });
            }

            return View(items);
        }

        public ActionResult AddItems()
        {
            ViewBag.Message = "The Bartender can add new items to the menu.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItems(MenuItemModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateItem(model.DrinkId,
                           model.Name,
                           model.Description,
                           model.Ingredients,
                           model.Price);
                return RedirectToAction("BartenderMenu");
            }

            return View();
        }


        public ActionResult Details(MenuItemModel model)
        {
            MenuItemModel item = new MenuItemModel
            { DrinkId = model.DrinkId,
              Name = model.Name,
              Description = model.Description,
              Ingredients = model.Ingredients,
              Price = model.Price
            };
            return View(item);
        }

        public ActionResult Detail(OrderQueueModel model)
        {
            OrderQueueModel item = new OrderQueueModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Ingredients = model.Ingredients,
                Price = model.Price
            };
            return View(item);
        }



        public ActionResult Queue()
        {
            ViewBag.Message = "Order Queue";

            var data = LoadOrder();
            List<OrderQueueModel> orders = new List<OrderQueueModel>();

            foreach (var row in data)
            {
                orders.Add(new OrderQueueModel
                {
                    Id = row.Id,
                    Name = row.Name,
                    Description = row.Description,
                    Ingredients = row.Ingredients,
                    Price = row.Price
                });
            }

            return View(orders);
        }
    }
}