using ecomm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecomm.Controllers
{
    public class ShopController : Controller
    {
        ISkillsContext database = new ISkillsContext();
        private const int PAGE_SIZE = 3;
        // GET: Shop
        public ActionResult Index(int page=1)
        {
            var data = database.Products.Select(p => p).OrderBy(p => p.ProductName).Skip((page-1)*PAGE_SIZE).Take(PAGE_SIZE);
            ProductsModel model = new ProductsModel
            {
                Products = data,
                Pagination = new PaginationModel
                {
                    CurrentPage = page,
                    ItemsPerPage = PAGE_SIZE,
                    TotalItems = database.Products.ToList().Count()
                }
            };
            return View(model);
        }
    }
}