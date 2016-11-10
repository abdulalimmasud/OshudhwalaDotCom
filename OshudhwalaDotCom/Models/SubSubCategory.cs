using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OshudhwalaDotCom.Models
{
    public class SubSubCategory
    {
        public int Id { get; set; }
        public string SubSubCategoryName { get; set; }
        public int SubCategoryId { get; set; }
    }
}