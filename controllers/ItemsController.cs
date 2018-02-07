using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            List<Item> allItems = Item.GetAll();
            return View("index", allItems);
        }

        [HttpGet("/items/new")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpPost("/items")]
        public ActionResult Create()
        {
            Item newItem = new Item(Request.Form["new-item"]);
            List<Item> allItems = Item.GetAll();
            return View("index", allItems);
        }
        [HttpGet("/items/{id}")]
       public ActionResult Details(int id)
       {
           Item item = Item.Find(id);
           return View(item);
       }

       [HttpPost("/items/list/clear")]
        public ActionResult ItemListClear()
        {
          Item.ClearAll();
          List<Item> allItems = new List<Item> {};
          return View("index", allItems);
        }
    }
}
