using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFM.Web.Models
{
    public class ItemModel
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public string ItemSubCategoryName { get; set; }

        public string ItemCategoryName { get; set; }

        public string ItemQuantity { get; set; }

        public decimal ItemPrice { get; set; }

        public DateTime PurchaseDate { get; set; }

        public ItemModel GetItemModel()
        {
            var data = new ItemModel();
            return data;
        }

        //private ItemModel GetItemModelData()
        //{
        //    var data = new ItemModel()
        //    {
        //        ItemId = 1,
        //        ItemName = ,
        //        ItemSubCategoryName = 1,
        //        ItemCategoryName = 1,
        //        ItemQuantity = 1,
        //        ItemPrice = 1,
        //    }

        //    return data;
        //}
    }
}