using OshudhwalaDotCom.Core.DAL;
using OshudhwalaDotCom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OshudhwalaDotCom.Core.BLL
{
    public class MedicineManager
    {
        MedicineGateway medicineGateway = new MedicineGateway();
        public List<Category> GetAllCategory()
        {
            return medicineGateway.GetAllCategory();
        }
        public List<SubCategory> GetSubCategory(int id)
        {
            return medicineGateway.GetSubCategory(id);
        }
        public List<SubSubCategory> GetSubSubCategory(int id)
        {
            return medicineGateway.GetSubSubCategory(id);
        }
    }
}