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
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please, Select a Sub Category")]
        [DisplayName("Sub Category")]
        public int SubCategoryId { get; set; }
        [Required(ErrorMessage = "Please, Select a Sub Sub Category")]
        [DisplayName("Sub Sub Category")]
        public int SubSubCategoryId { get; set; }
        [Required(ErrorMessage ="Please, Give your medicine title")]
        [DisplayName("Item")]
        public string ItemName { get; set; }
        [DisplayName("Picture")]
        [DataType(DataType.Upload)]
        public string Photo { get; set; }
        [Required(ErrorMessage ="Please, Give medicine price")]
        public double Price { get; set; }
        [DisplayName("Description")]
        public string Details { get; set; }
        [Required(ErrorMessage = "Please, Select Yes or No")]
        [DisplayName("Is Medicine Danger")]
        public int IsDanger { get; set; }
    }
}