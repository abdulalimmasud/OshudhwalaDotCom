using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OshudhwalaDotCom.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please, Select a Category")]
        public int Category { get; set; }
        [Required(ErrorMessage = "Please, Select a Sub Category")]
        [DisplayName("Sub Category")]
        public int SubCategory { get; set; }
        [Required(ErrorMessage = "Please, Select a Sub Sub Category")]
        [DisplayName("Sub Sub Category")]
        public int SubSubCategory { get; set; }
        [Required(ErrorMessage ="Please, Give your medicine title")]
        public string Title { get; set; }
        [DisplayName("Picture")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
        [Required(ErrorMessage ="Please, Give medicine price")]
        public double Price { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please, Select Yes or No")]
        [DisplayName("Is Medicine Danger")]
        public int IsDanger { get; set; }
    }
}