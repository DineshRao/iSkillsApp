using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISkillsMyApp.Models;

namespace ISkillsMyApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ISkillsContext db = new ISkillsContext();
        public ShoppingCartController()
        {

        }
        // GET: ShoppingCart
        public ActionResult Index(string returnUrl)
        {
            return View(new ShoppingCartViewModel
            {
                Cart =GetCart(),
                ReturnUrl=returnUrl
            }
                );
        }

        public RedirectToRouteResult AddToCart(int productID, string returnUrl)
        {
            Product product = db.Products.SingleOrDefault(p=>p.ProductID==productID);
            if(product!=null)
            {
                GetCart().AddItem(product,1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productID, string returnUrl)
        {
            GetCart().RemoveItem(productID);
            return RedirectToAction("Index", new { returnUrl });
        }

        private ShoppingCartModel GetCart()
        {
            ShoppingCartModel Cart = (ShoppingCartModel)Session["Cart"];
            if(Cart== null)
            {
                Cart = new ShoppingCartModel();
                Session["Cart"] = Cart;
            }
            return Cart;
        }

        public ViewResult ShippingInfo()
        {
            return View(new ShippingInfo());
        }

        [HttpPost]
        public ActionResult ShippingInfo(ShippingInfo ShippingInfo)
        {
            if(ModelState.IsValid)
            {
                ShoppingCartModel cart = GetCart();
                cart.ShippingInfo = ShippingInfo;
                return RedirectToAction("BillingInfo");
            }
            else
            {
                return View(ShippingInfo);
            }
        }

        public ViewResult BillingInfo()
        {
            return View(new BillingInfo());
        }

        public PartialViewResult CartWidget(ShoppingCartModel cart)
        {
            if (Session["Cart"] != null)
            {
                cart = (ShoppingCartModel)Session["Cart"];
            }
            return PartialView(cart);
        }

        [HttpPost]
        public ActionResult BillingInfo(BillingInfo BillingInfo)
        {
            if (ModelState.IsValid)
            {
                ShoppingCartModel cart = GetCart();
                cart.BillingInfo = BillingInfo;
                ProcessOrder(cart);
                cart.Clear();
                return RedirectToAction("OrderComplete");
            }
            else
            {
                return View(BillingInfo);
            }
        }
        public ActionResult OrderComplete()
        {
            return View("OrderComplete");
        }
        private void ProcessOrder(ShoppingCartModel cart)
        {
            Customer customer = new Customer
            {
                FirstName=cart.BillingInfo.FirstName,
                LastName=cart.BillingInfo.LastName,
                BillingAddress=cart.BillingInfo.Address,
                BillingCity=cart.BillingInfo.City,
                BillingState=cart.BillingInfo.State,
                BillingPostalCode=cart.BillingInfo.Zip,
                CardNumber=cart.BillingInfo.CreditCardNumber,
                ExpirationMonth=cart.BillingInfo.ExpirationMonth,
                ExpirationYear=cart.BillingInfo.ExpirationYear
            };
            db.Customers.Add(customer);
            db.SaveChanges();

            Order order = new Order()
            {
                CustomerID=customer.CustomerID,
                OrderDate=DateTime.Now,
                ShippingAddress=cart.ShippingInfo.Address,
                ShippingCity=cart.ShippingInfo.City,
                ShippingState=cart.ShippingInfo.State,
                ShippingPostalCode=cart.ShippingInfo.Zip,

            };
            db.Orders.Add(order);
            db.SaveChanges();
            foreach(ShoppingCartItemModel item in cart.Items)
            {
                OrderItem orderItem = new OrderItem()
                {
                    OrderID=order.OrderID,
                    ProductID=item.Product.ProductID,
                    Quantity =item.Quantity
                };
                db.OrderItems.Add(orderItem);
            }
            db.SaveChanges();
        }
    }
}