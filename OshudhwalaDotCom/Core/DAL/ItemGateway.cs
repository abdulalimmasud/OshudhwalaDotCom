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
            //try
            //{
            //    SqlConnection.Open();
            //    rowAffected= SqlConnection.Execute("spInsertItems", item, commandType: CommandType.StoredProcedure);
            //}
            //catch(Exception ex)
            //{

            //}
            //finally
            //{
            //    SqlConnection.Close();
            //}
            return rowAffected;
        }
    }
}