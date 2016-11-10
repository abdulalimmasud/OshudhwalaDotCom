using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using OshudhwalaDotCom.Models;
using System.Data;

namespace OshudhwalaDotCom.Core.DAL
{
    public class MedicineGateway : BaseGateway
    {
        public void InsertCategory(Category category)
        {
            try
            {
                SqlConnection.Open();
                //SqlCommand.Parameters.AddWithValue("@name", category.Name);
                SqlConnection.Execute("spInsertCategory", category, commandType: CommandType.StoredProcedure);
                SqlConnection.Close();
            }
            catch(Exception ex)
            {

            }
        }

        public List<Category> GetAllCategory()
        {
            List<Category> categoryList = new List<Category>();
            try
            {
                SqlConnection.Open();
                categoryList = SqlMapper.Query<Category>(SqlConnection, "spGetCategory").ToList();                
            }
            catch(Exception ex)
            {

            }
            finally
            {
                SqlConnection.Close();
            }
            return categoryList;
        }
        public List<SubCategory> GetSubCategory(int id)
        {
            List<SubCategory> subCategoryList = new List<SubCategory>();
            try
            {
                SqlConnection.Open();
                
                subCategoryList = SqlConnection.Query<SubCategory>("spGetSubCategory '"+id+"'").ToList();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                SqlConnection.Close();
            }
            return subCategoryList;
        }
        public List<SubSubCategory> GetSubSubCategory(int id)
        {
            List<SubSubCategory> subSubCategoryList = new List<SubSubCategory>();
            try
            {
                SqlConnection.Open();
                subSubCategoryList = SqlConnection.Query<SubSubCategory>("spGetSubSubCategory '" + id+"'").ToList();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                SqlConnection.Close();
            }
            return subSubCategoryList;
        }
    }
}