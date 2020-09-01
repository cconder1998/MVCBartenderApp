using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBartenderApplication.Models
{
    public class MenuItemModel
    {
        [Display(Name = "Item ID")]
        public int DrinkId { get; set; }

        [Required(ErrorMessage = "Field Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Field Required")]
        public string Ingredients { get; set; }

        [DataType(DataType.Currency)]
        public float Price { get; set; }
    }
}