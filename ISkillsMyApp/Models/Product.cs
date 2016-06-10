using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISkillsMyApp.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description{ get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public string Details { get; set; }
        [ForeignKey("Categories")]
        public int CategoryID { get; set; }

        public virtual Categories Categories { get; set; }
    }
}