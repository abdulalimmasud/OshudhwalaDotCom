using OshudhwalaDotCom.Core.BLL;
using OshudhwalaDotCom.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OshudhwalaDotCom.Controllers
{
    public class AdminController : Controller
    {
        MedicineManager medicineManger = new MedicineManager();
        ItemManager itemManger = new ItemManager();
        // GET: Admin
        public ActionResult AddItem()
        {
            ViewBag.CategoryList = CategoryList();
            return View();
        }
        [HttpPost]
        public ActionResult AddItem(Item item,int categoryId, int sCategoryId, int ssCategoryid, HttpPostedFileBase  file)
        {
            ////var file = item.Photo as HttpPostedFileBase;

            //[Bind(Include = "CategoryId, SubCategoryId, SubSubCategoryId, ItemName, Photo, Price, Details, IsDanger")]
            if (ModelState.IsValid)
            {
                string imageUrl = @"E:\Study\Project\OshudhwalaDotCom\OshudhwalaDotCom\Image\Upload"+item.Photo;
                //item.CategoryId = Convert.ToInt32(form["CategoryId"]);
                if (file != null)
                {
                    file.SaveAs(imageUrl);
                    item.Photo = imageUrl;

                }
                else
                {
                    imageUrl = "";
                }
                if (itemManger.IsItemInserted(item))
                {
                    ViewBag.Message = "Successful";
                }
                else
                {
                    ViewBag.ErrorMessage = "Sorry";
                }
            }
            ViewBag.CategoryList = CategoryList();
            return View();
        }
        private List<SelectListItem> CategoryList()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem { Value = "", Text = "Please Select", Selected = true });
            foreach (Category item in medicineManger.GetAllCategory())
            {
                selectList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.CategoryName });
            }
            return selectList;
        }
        public JsonResult SubCategoryList(int id)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem { Value = "", Text = "Please Select", Selected = true });
            foreach (SubCategory item in medicineManger.GetSubCategory(id))
            {
                selectList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.SubCategoryName });
            }
            return Json(new SelectList(selectList, "Value", "Text"));
        }
        public JsonResult SubSubCategoryList(int id)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem { Value = "", Text = "Please Select", Selected = true });
            foreach (SubSubCategory item in medicineManger.GetSubSubCategory(id))
            {
                selectList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.SubSubCategroyName });
            }
            return Json(new SelectList(selectList, "Value", "Text"));
        }
    }
}