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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddItem([Bind(Include = "CategoryId, SubCategoryId, SubSubCategoryId, ItemName,Photo, Price, Details, IsDanger")] Item item)
        {
            if (ModelState.IsValid)
            {
                string imageUrl = "";
                if(item.Photo != string.Empty)
                {
                    //var uploadDir = "/uploads";
                    //var imagePath = Path.Combine(Server.MapPath(uploadDir), file.FileName);
                    //imageUrl = Path.Combine(uploadDir, file.FileName);
                    //file.SaveAs(imagePath);
                    //item.Photo = imageUrl; 
                    foreach (string file in Request.Files)
                    {
                        var postedFile = Request.Files[file];
                        var uploadDir = "/uploads";
                        var imagePath = Path.Combine(Server.MapPath(uploadDir), postedFile.FileName);
                        imageUrl = Path.Combine(uploadDir, postedFile.FileName);
                        postedFile.SaveAs(imagePath);                        
                    }
                }
                item.Photo = imageUrl;
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
            selectList.Add(new SelectListItem { Value = "0", Text = "Please Select", Selected = true });
            foreach (SubCategory item in medicineManger.GetSubCategory(id))
            {
                selectList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.SubCategoryName });
            }
            return Json(new SelectList(selectList, "Value", "Text"));
        }
        public JsonResult SubSubCategoryList(int id)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem { Value = "0", Text = "Please Select", Selected = true });
            foreach (SubSubCategory item in medicineManger.GetSubSubCategory(id))
            {
                selectList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.SubSubCategroyName });
            }
            return Json(new SelectList(selectList, "Value", "Text"));
        }
    }
}