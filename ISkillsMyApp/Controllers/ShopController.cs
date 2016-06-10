using ISkillsMyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISkillsMyApp.Controllers
{
    public class ShopController : Controller
    {
        ISkillsContext database = new ISkillsContext();
        private const int PAGE_SIZE = 3;
        // GET: Shop
        public ActionResult Index(int page = 1, int categoryID = 0, string SearchString="")
        {
            return View(Getmodel(page, categoryID, SearchString));
        }
        [HttpPost]
        public ActionResult Index(ProductsModel productsmodel)
        {
            return View(Getmodel(1, productsmodel.CategoryID, productsmodel.SearchString));
        }

        private ProductsModel Getmodel(int page, int categoryID, string SearchString)
        {
            var data = database.Products.Select(p => p).Where(p=>categoryID==0 || p.CategoryID==categoryID)
                .Where(p=>string.IsNullOrEmpty(SearchString) || p.Description.Contains(SearchString))
                .OrderBy(p => p.ProductName).Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            ProductsModel model = new ProductsModel
            {
                Products = data,
                Pagination = new PaginationModel
                {
                    CurrentPage = page,
                    ItemsPerPage = PAGE_SIZE,
                    TotalItems = categoryID==0?
                    database.Products.Count() : database.Products.Select(p=>p).Where(p=>p.CategoryID == categoryID).Count()
                },
                CategoryID=categoryID
            };
            return model;
        }
    }
}