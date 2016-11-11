using OshudhwalaDotCom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Dapper;

namespace OshudhwalaDotCom.Core.DAL
{
    public class ItemGateway:BaseGateway
    {
        public int InsertItem(Item item)
        {
            int rowAffected = 0;
            try
            {
                SqlConnection.Open();
                SqlCommand.CommandText = "spInsertItems";
                SqlCommand.CommandType = CommandType.StoredProcedure;
                SqlCommand.Parameters.AddWithValue("@ItemName", item.ItemName);
                SqlCommand.Parameters.AddWithValue("@Photo", item.Photo);
                SqlCommand.Parameters.AddWithValue("@Price", item.Price);
                SqlCommand.Parameters.AddWithValue("@Details", item.Details);
                SqlCommand.Parameters.AddWithValue("@SubSubCategoryId", item.SubSubCategoryId);
                SqlCommand.Parameters.AddWithValue("@SubCategoryId", item.SubCategoryId);
                SqlCommand.Parameters.AddWithValue("@CategoryId", item.CategoryId);
                SqlCommand.Parameters.AddWithValue("@IsDanger", item.IsDanger);
                rowAffected = SqlCommand.ExecuteNonQuery();
            }
            //try
            //{
            //    SqlConnection.Open();
            //    rowAffected= SqlConnection.Execute("spInsertItems", item, commandType: CommandType.StoredProcedure);
            //}
            catch (Exception ex)
            {

            }
            finally
            {
                SqlConnection.Close();
            }
            return rowAffected;
        }
    }
}