using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISkillsMyApp.Models
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartModel Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}