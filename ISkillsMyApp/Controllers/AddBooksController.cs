using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISkillsMyApp.Models;
using System.IO;


namespace ISkillsMyApp.Controllers
{
    public class AddBooksController : Controller
    {
        
        public ActionResult Index()
        {
            // ISkillsContext SkillsContext
            ISkillsContext SkillsContext = new ISkillsContext();
           // ProductsModel productsModel = new ProductsModel();

            
            ViewBag.CategoryID = new SelectList(SkillsContext.Categories, "CategoryID", "CategoryName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ProductName,Description,Price,Image,Details,CategoryID")]Product product)
        {
            ISkillsContext SkillsContext = new ISkillsContext();
            if (ModelState.IsValid)
            {
                try
                {
                    
                    SkillsContext.Products.Add(product);
                    SkillsContext.SaveChanges();
                }
                catch (Exception e)
                {
                    string t = e.StackTrace;
                }
                //return RedirectToAction("Index", "HomePage");
                return View("Index_Submit");
                //return RedirectToAction("Index_Submit", "AddBooks");

                
            }
         else
                {
                    //return RedirectToAction("Index", "HomePage");
                    //return RedirectToAction("Index_Submit", "AddBooks");
                }
            ViewBag.CategoryID = new SelectList(SkillsContext.Categories, "CategoryID", "CategoryName", product.CategoryID);

            return View(product);

           
        }
        
    }
}
       // [HttpPost]
        //public ActionResult GetValue(FormCollection fc)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string ProductName = Request.Form["product_name"];
        //        string CategoryName = Request.Form["category_name"];
        //        string Description = Request.Form["description_name"];
        //        string Price = Request.Form["price_name"];
        //        string Details = Request.Form["details_name"];

        //        //var url = file.ToString(); //getting complete url  ;
        //        //var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
        //        //var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg)  
        //        //    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
        //        //    string myfile = name + "_" + DateTime.Now + ext; //appending the name with id  
        //        //    // store the file inside ~/project folder(Img)  
        //        //    var path = Path.Combine(Server.MapPath("~/Img"), myfile);
        //        //    //tbl.Image_url = path;
        //        //    //obj.tbl_details.Add(tbl);
        //        //    //obj.SaveChanges();
        //        //    //file.SaveAs(path);
        //        var product = new Product
        //        {
        //            ProductName = ProductName,
        //            CategoryID = Convert.ToInt32(CategoryName),
        //            Description = Description,
        //            Price = Convert.ToDecimal(Price),
        //            Details = Details,
        //        };
        //        try
        //        {
        //            using (var db = new ISkillsContext())
        //            {
        //                db.Products.Add(product);
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            string EXP = e.StackTrace;
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}
   // }
//}