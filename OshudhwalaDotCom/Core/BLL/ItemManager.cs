using OshudhwalaDotCom.Core.DAL;
using OshudhwalaDotCom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OshudhwalaDotCom.Core.BLL
{
    public class ItemManager
    {
        ItemGateway itemGateway = new ItemGateway();
        public bool IsItemInserted(Item item)
        {
            return itemGateway.InsertItem(item) > 0 ? true : false;
        }

        public List<Item> GetItemsByText(string text)
        {
            return itemGateway.GetItemsByText(text);
        }
    }
}