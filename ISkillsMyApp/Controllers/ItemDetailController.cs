using ISkillsMyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISkillsMyApp.Controllers
{
    public class ItemDetailController : Controller
    {
        // GET: ItemDetail
        ISkillsContext db = new ISkillsContext();
        public ActionResult Index(int id)
        {
            var data = db.Products.SingleOrDefault(p => p.ProductID == id);
            
            return View(data);
        }
    }
}