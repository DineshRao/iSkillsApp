using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISkillsMyApp.Models
{
    public class ProductsModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PaginationModel Pagination { get; set; }

        public int CategoryID { get; set; }

        public string SearchString { get; set; }

        public SelectList Categories()
        {
            ISkillsContext db = new ISkillsContext();
            var Categories = from c in db.Categories
                             orderby c.CategoryName
                             select new
                             {
                                 c.CategoryID,
                                 c.CategoryName
                             };
            return new SelectList(Categories,"CategoryID","CategoryName");
        }
    }
}