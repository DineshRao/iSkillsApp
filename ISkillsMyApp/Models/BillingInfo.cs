using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISkillsMyApp.Models
{
    public class BillingInfo
    {
        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter credit card number")]
        public string CreditCardNumber { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter Zip")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter expiration month")]
        public string ExpirationMonth { get; set; }
        [Required(ErrorMessage = "Please enter expiration year")]
        public string ExpirationYear { get; set; }

        public SelectList Months()
        {
            return new SelectList(new string[] { "Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sept","Oct","Nov","Dec" });
        }

        public SelectList Years()
        {
            return new SelectList(new string[] { "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025" });
        }
    }
}