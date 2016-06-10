using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISkillsMyApp.Models;

namespace ISkillsMyApp.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Index()
        {
            ISkillsContext iSkillsContext = new ISkillsContext();
            List<Categories> categories = iSkillsContext.Categories.ToList();
            return View(categories);
        }
        public ActionResult CategoryProduct(int id)
        {
            ISkillsContext iSkillsContext = new ISkillsContext();
            //  List<Categories> categories = iSkillsContext.Categories.ToList();

            IEnumerable<Product> product = iSkillsContext.Products.Where(x => x.CategoryID == id);
            //  if(product.)
            return PartialView("_CategoryProduct", product);
            // return View(product);
        }
    }
}